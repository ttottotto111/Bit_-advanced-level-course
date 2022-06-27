//handler.cpp

#include <Windows.h>
#include <tchar.h>
#include "resource.h"

int g_type = 1;
//1
LRESULT OnCreate(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//아이디가1인 타이머가 1초 단위로 반복 실행
	SetTimer(hwnd, 1, 1000, 0);
	SendMessage(hwnd, WM_TIMER, 1, 0);	//1 : wParam 타이머의 ID

	return 0;
}
LRESULT OnDestroy(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	KillTimer(hwnd, 1);

	PostQuitMessage(0);
	return 0;
}
LRESULT OnTimer(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//타이틀바에 시간 출력
	SYSTEMTIME st;
	GetLocalTime(&st);

	TCHAR buf[100];
	wsprintf(buf, TEXT("%04d년%02d월%02d일 %02d:%02d:%02d"),
		st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond);

	SetWindowText(hwnd, buf);

	//도형 출력
	g_type++;
	if (g_type > 3)		g_type = 1;

	InvalidateRect(hwnd, 0, TRUE);

	return 0;
}
LRESULT OnPaint(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hwnd, &ps);

	if (g_type == 1)
	{
		Rectangle(hdc, 10, 10, 100, 100);   //90*90
	}
	else if (g_type == 2)
	{
		Ellipse(hdc, 10, 10, 100, 100);		//90*90
	}
	else if (g_type == 3)
	{
		POINT pts[] = { {55,10}, {10, 100}, {100, 100} };
		Polygon(hdc, pts, 3);
	}

	EndPaint(hwnd, &ps);

	return 0;
}
LRESULT OnLButtonDown(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	POINT pt = { LOWORD(lParam), HIWORD(lParam) };


	HDC hdc = GetDC(hwnd);

	POINT pts[] = { { pt.x,pt.y },{ pt.x - 50, pt.y + 100 },{ pt.x + 50, pt.y + 100 } };
	Polygon(hdc, pts, 3);

	ReleaseDC(hwnd, hdc);

	return 0;
}

//2
BOOL isCheck = TRUE;
COLORREF b_color = RGB(255, 0, 0);
LRESULT OnCommand(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))
	{
			//프로그램종료
		case ID_40001: SendMessage(hwnd, WM_CLOSE, 0, 0); break;
			//좌표출력 여부
		case ID_40002: isCheck = !isCheck; InvalidateRect(hwnd, 0, TRUE); break;
			//색상변경
		case ID_40003: b_color = RGB(255, 0, 0); InvalidateRect(hwnd, 0, FALSE); break;
		case ID_40004: b_color = RGB(0, 255, 0); InvalidateRect(hwnd, 0, FALSE); break;
		case ID_40005: b_color = RGB(0, 0, 255); InvalidateRect(hwnd, 0, FALSE); break;
		case ID_40006: b_color = RGB(rand()%256, rand() % 256, rand() % 256); InvalidateRect(hwnd, 0, FALSE); break;
	}
	return 0;
}
LRESULT OnMouseMove(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	if (isCheck)
	{
		HDC hdc = GetDC(hwnd);

		POINT pt = { LOWORD(lParam), HIWORD(lParam) };
		TCHAR buf[100];
		wsprintf(buf, TEXT("%06d:%06d"), pt.x, pt.y);

		TextOut(hdc, 10, 10, buf, _tcslen(buf));

		ReleaseDC(hwnd, hdc);
	}
	return 0;
}
LRESULT OnIninMenuPopup(HWND hwnd, WPARAM wParam, LPARAM lParam)
	{
	//윈도우에 부착되어 잇는 메뉴의 핸들 획득

	//HMENU hMenu = GetMenu(Hwnd)
	HMENU hMenu = (HMENU)wParam;

	CheckMenuItem(hMenu, ID_40002,
		isCheck == TRUE ? MF_CHECKED : MF_UNCHECKED);

	//색상
	EnableMenuItem(hMenu, ID_40003, b_color == RGB(255, 0, 0) ? MF_GRAYED : MF_ENABLED);
	EnableMenuItem(hMenu, ID_40004, b_color == RGB(0, 255, 0) ? MF_GRAYED : MF_ENABLED);
	EnableMenuItem(hMenu, ID_40005, b_color == RGB(0, 0, 255) ? MF_GRAYED : MF_ENABLED);
	return 0;
	}
LRESULT OnPaint1(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc = BeginPaint(hwnd, &ps);

	HBRUSH brush = CreateSolidBrush(b_color);
	HBRUSH oldbrush = (HBRUSH)SelectObject(hdc, brush);

	Rectangle(hdc, 10, 30, 100, 130);
	EndPaint(hwnd, &ps);

	return 0;
}
LRESULT OnContextMenu(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	HMENU hMenu = LoadMenu(GetModuleHandle(0), MAKEINTRESOURCE(IDR_MENU1));
	HMENU hSubMenu = GetSubMenu(hMenu, 2);
	POINT pt = { LOWORD(lParam), HIWORD(lParam) };
	// 스크린 좌표...
	TrackPopupMenu(hSubMenu, TPM_LEFTBUTTON, pt.x, pt.y, 0, hwnd, 0);

	return 0;
}

//3
#define IDC_EDIT1 1
#define IDC_BUTTON1 2
#define IDC_LISTBOX1 3
HWND hedit1, hbutton2, hListBox1;
LRESULT OnCreate1(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	CreateWindow(TEXT("static"), TEXT("이 름"),
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		10, 10, 90, 20, hwnd, (HMENU)0, 0, 0);

	hedit1 = CreateWindow(TEXT("Edit"), TEXT(""),
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		110, 10, 310, 20, hwnd, (HMENU)IDC_EDIT1, 0, 0);

	hbutton2 = CreateWindow(TEXT("button"), TEXT("클릭"),
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		430, 10, 60, 20, hwnd, (HMENU)IDC_BUTTON1, 0, 0);

	hListBox1 = CreateWindow(TEXT("listbox"), TEXT(""),
		WS_CHILD | WS_VISIBLE | WS_BORDER | LBS_NOTIFY,
		110, 40, 310, 100, hwnd, (HMENU)IDC_LISTBOX1, 0, 0);

	return 0;
}
LRESULT OnCommand1(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//통지 메시지 (자식------>부모)
	switch (LOWORD(wParam))
	{
		case IDC_BUTTON1:
			{
			TCHAR buf[100];
			GetWindowText(hedit1, buf, sizeof(buf));
			//SetWindowText(hwnd, buf);

			//에디트에 입력한 문자열을 리스트박스에 추가
			SendMessage(hListBox1, LB_ADDSTRING, 0, (LPARAM)buf);

			//에디트에서 문자열 제거
			SetWindowText(hedit1, TEXT(""));
	
			SetFocus(hedit1);

			break;
		}
		case IDC_LISTBOX1:
		{
			switch (HIWORD(wParam))
			{
				case LBN_SELCHANGE:
				{
					TCHAR str[50];
					int i = SendMessage(hListBox1, LB_GETCURSEL, 0, 0);
					SendMessage(hListBox1, LB_GETTEXT, i, (LPARAM)str);
					SetWindowText(hwnd, str);
					break;
				}
			}
			break;
		}

	}
	return 0;
}