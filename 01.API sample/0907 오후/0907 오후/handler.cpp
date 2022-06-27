//handler.cpp

#include <Windows.h>
#include "handler.h"
#include "resource.h"
#include "childproc.h"
#include "data.h"

HWND g_hDlg = 0;
DATA g_data;

LRESULT OnCreate(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	g_data.type = 1;
	g_data.x = 10;
	g_data.y = 10;
	g_data.color = RGB(255, 0, 0);

	return 0;
}

LRESULT OnLButtonDown(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//모달리스 생성
	if (g_hDlg == 0)
	{
		g_hDlg = CreateDialogParam(GetModuleHandle(0),// hinstance
			MAKEINTRESOURCE(IDD_DIALOG1),
			hwnd, // 부모
			ChildDlgProc, // 메세지 함수.
			(LPARAM)&g_data);

		ShowWindow(g_hDlg, SW_SHOW);
	}
	else
	{
		SetFocus(g_hDlg);
	}

	return 0;
}


LRESULT OnPaint(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hwnd, &ps);

	HBRUSH br = CreateSolidBrush(g_data.color);
	HBRUSH oldbr = (HBRUSH)SelectObject(hdc, br);

	if (g_data.type == 1)
	{
		Rectangle(hdc, g_data.x, g_data.y, g_data.x + 100, g_data.y + 100);
	}
	else if (g_data.type == 2)
	{
		Ellipse(hdc, g_data.x, g_data.y, g_data.x + 100, g_data.y + 100);
	}

	EndPaint(hwnd, &ps);

	return 0;
}

LRESULT OnApply_Position(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	InvalidateRect(hwnd, 0, TRUE);
	return 0;
}

LRESULT OnApply_Color(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	InvalidateRect(hwnd, 0, TRUE);
	return 0;
}