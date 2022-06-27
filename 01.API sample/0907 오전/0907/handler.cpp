//handler.cpp

#include <Windows.h>
#include "handler.h"
#include "data.h"
#include "resource.h"
#include "childproc.h"

DATA g_data;

LRESULT OnCreate(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	g_data.xcount = 30;
	g_data.ycount = 40;
	g_data.color = RGB(100, 100, 100);   // 50, 100, 150, 200
	return 0;
}

LRESULT OnLButtonDown(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//모달
	DATA temp = g_data;

	UINT ret = DialogBoxParam(GetModuleHandle(0),// hinstance
		MAKEINTRESOURCE(IDD_DIALOG1),
		hwnd, // 부모
		ChildDlgProc, // 메세지 함수.
		(LPARAM)&temp); // WM_INITDIALOG의 lParam로 전달된다.
	if (ret == IDOK)
	{
		g_data = temp;
		InvalidateRect(hwnd, 0, TRUE);
	}

	return 0;
}

LRESULT OnPaint(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hwnd, &ps);

	RECT rc;
	GetClientRect(hwnd, &rc);

	HPEN pen = CreatePen(PS_SOLID, 1, g_data.color);
	HPEN oldpen = (HPEN)SelectObject(hdc, pen);

	//세로줄을 그려보자
	double width = (double)rc.right / (g_data.xcount + 1);
	for (int i = 1; i < g_data.xcount + 1; i++)
	{
		MoveToEx(hdc, (int)width * i, 0, 0);
		LineTo(hdc, (int)width * i, rc.bottom);
	}

	//가로줄을 그려보자.
	double height = (double)rc.bottom / (g_data.ycount + 1);
	for (int i = 1; i < g_data.ycount + 1; i++)
	{
		MoveToEx(hdc, 0, (int)height * i, 0);
		LineTo(hdc, rc.right, (int)height * i);
	}

	DeleteObject(SelectObject(hdc, oldpen));


	//	TCHAR buf[20];
	//	wsprintf(buf, TEXT("%d, %d ~ %d, %d"), rc.top, rc.left, rc.bottom, rc.right);
	//	SetWindowText(hwnd, buf);

	EndPaint(hwnd, &ps);

	return 0;
}