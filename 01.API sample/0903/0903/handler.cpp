//handler.cpp

#include <Windows.h>
#include <tchar.h>
#include "resource.h"

int g_type = 1;
//1
LRESULT OnCreate(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//���̵�1�� Ÿ�̸Ӱ� 1�� ������ �ݺ� ����
	SetTimer(hwnd, 1, 1000, 0);
	SendMessage(hwnd, WM_TIMER, 1, 0);	//1 : wParam Ÿ�̸��� ID

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
	//Ÿ��Ʋ�ٿ� �ð� ���
	SYSTEMTIME st;
	GetLocalTime(&st);

	TCHAR buf[100];
	wsprintf(buf, TEXT("%04d��%02d��%02d�� %02d:%02d:%02d"),
		st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond);

	SetWindowText(hwnd, buf);

	//���� ���
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
			//���α׷�����
		case ID_40001: SendMessage(hwnd, WM_CLOSE, 0, 0); break;
			//��ǥ��� ����
		case ID_40002: isCheck = !isCheck; InvalidateRect(hwnd, 0, TRUE); break;
			//���󺯰�
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
	//�����쿡 �����Ǿ� �մ� �޴��� �ڵ� ȹ��

	//HMENU hMenu = GetMenu(Hwnd)
	HMENU hMenu = (HMENU)wParam;

	CheckMenuItem(hMenu, ID_40002,
		isCheck == TRUE ? MF_CHECKED : MF_UNCHECKED);

	//����
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
	// ��ũ�� ��ǥ...
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
	CreateWindow(TEXT("static"), TEXT("�� ��"),
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		10, 10, 90, 20, hwnd, (HMENU)0, 0, 0);

	hedit1 = CreateWindow(TEXT("Edit"), TEXT(""),
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		110, 10, 310, 20, hwnd, (HMENU)IDC_EDIT1, 0, 0);

	hbutton2 = CreateWindow(TEXT("button"), TEXT("Ŭ��"),
		WS_CHILD | WS_VISIBLE | WS_BORDER,
		430, 10, 60, 20, hwnd, (HMENU)IDC_BUTTON1, 0, 0);

	hListBox1 = CreateWindow(TEXT("listbox"), TEXT(""),
		WS_CHILD | WS_VISIBLE | WS_BORDER | LBS_NOTIFY,
		110, 40, 310, 100, hwnd, (HMENU)IDC_LISTBOX1, 0, 0);

	return 0;
}
LRESULT OnCommand1(HWND hwnd, WPARAM wParam, LPARAM lParam)
{
	//���� �޽��� (�ڽ�------>�θ�)
	switch (LOWORD(wParam))
	{
		case IDC_BUTTON1:
			{
			TCHAR buf[100];
			GetWindowText(hedit1, buf, sizeof(buf));
			//SetWindowText(hwnd, buf);

			//����Ʈ�� �Է��� ���ڿ��� ����Ʈ�ڽ��� �߰�
			SendMessage(hListBox1, LB_ADDSTRING, 0, (LPARAM)buf);

			//����Ʈ���� ���ڿ� ����
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