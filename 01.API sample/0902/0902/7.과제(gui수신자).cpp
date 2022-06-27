//0902_�ǽ����

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 
#include <vector>
using namespace std;
#include "shape.h"

//[�۽���] ���콺 Ŭ��
#define WM_MSGPOINT  WM_USER + 100 //     wParam x��ǥ   lParam y��ǥ

//[�۽���] Ű����
#define WM_MSGSIZE   WM_USER+ 200   //   wParam size���� lParam 0
#define WM_MSGTYPE   WM_USER+ 210   //   wParma  Ÿ������ lParam 0
#define WM_MSGCOLOR  WM_USER +220   //   wParam �������� lParam 0

//[�׸��׸���]
#define WM_MSGPRINT WM_USER + 900

vector<SHAPE> shapelist;
SHAPE curshape;

const TCHAR* TypeToString(int idx)
{
	if (idx == 1)
		return TEXT("�簢��");
	else if (idx == 2)
		return TEXT("Ÿ��");
	else if (idx == 3)
		return TEXT("�ﰢ��");
	else
		return TEXT("�߸��� �ε���");
}

//Ÿ��Ʋ�ٿ� ����ϴ� �Լ�
void PrintInfo(HWND hwnd)
{
	TCHAR buf[200];
	wsprintf(buf, TEXT("[��ǥ]%d,%d  [����]%d,%d,%d  [��]%d  [Ÿ��]%s"),
		curshape.pt.x, curshape.pt.y,
		GetRValue(curshape.b_color), GetGValue(curshape.b_color), GetBValue(curshape.b_color),
		curshape.size,
		TypeToString(curshape.type));

	SetWindowText(hwnd, buf);
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_MSGPRINT:
	{
		//����
		shapelist.push_back(curshape);

		//��ȿȭ
		InvalidateRect(hwnd, 0, FALSE);

		return 0;
	}
	case WM_MSGCOLOR:
	{
		curshape.b_color = curshape.p_color = (COLORREF)wParam;
		PrintInfo(hwnd);

		return 0;
	}
	case WM_MSGTYPE:
	{
		curshape.type = wParam;
		PrintInfo(hwnd);

		return 0;
	}
	case WM_MSGSIZE:
	{
		curshape.size = wParam;
		PrintInfo(hwnd);

		return 0;
	}
	case WM_MSGPOINT:
	{
		curshape.pt.x = wParam;
		curshape.pt.y = lParam;

		PrintInfo(hwnd);

		return 0;
	}
	case WM_CREATE:
	{
		curshape.pt.x = 0;
		curshape.pt.y = 0;
		curshape.b_color = RGB(255, 0, 0);
		curshape.p_color = RGB(255, 0, 0);
		curshape.size = 25; // 25
		curshape.type = 1; // �簢��

		PrintInfo(hwnd);
		return 0;
	}
	case WM_PAINT:
	{
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hwnd, &ps);

		for (int i = 0; i < (int)shapelist.size(); i++)
		{
			SHAPE s = shapelist[i];

			HBRUSH hbr = CreateSolidBrush(s.b_color);
			HBRUSH oldbr = (HBRUSH)SelectObject(hdc, hbr);

			HPEN pen = CreatePen(PS_SOLID, 1, s.p_color);
			HPEN oldpen = (HPEN)SelectObject(hdc, pen);

			if (s.type == 1)		//�簢��
			{
				Rectangle(hdc, s.pt.x, s.pt.y, s.pt.x + s.size, s.pt.y + s.size);
			}
			else if (s.type == 2)	//Ÿ��
			{
				Ellipse(hdc, s.pt.x, s.pt.y, s.pt.x + s.size, s.pt.y + s.size);
			}
			else if (s.type == 3)	//�ﰢ��
			{

			}

			DeleteObject(SelectObject(hdc, oldbr));
			DeleteObject(SelectObject(hdc, oldpen));
		}

		EndPaint(hwnd, &ps);

		return 0;
	}
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hwnd, msg, wParam, lParam);
}


int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPTSTR lpCmd, int nShow)
{
	// 1. ������ Ŭ���� ����� 
	WNDCLASS wc;
	wc.cbWndExtra = 0;
	wc.cbClsExtra = 0;
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.hCursor = LoadCursor(0, IDC_ARROW);
	wc.hIcon = LoadIcon(0, IDI_APPLICATION);
	wc.hInstance = hInst;
	wc.lpfnWndProc = WndProc;   //  DefWindowProc;
	wc.lpszClassName = _TEXT("First");
	wc.lpszMenuName = 0;
	wc.style = 0;  //CS_DBLCLKS;

				   // 2. ���(������Ʈ����)
	RegisterClass(&wc);

	// 3. ������ â ����� 
	HWND hwnd = CreateWindowEx(0,			// WS_EX_TOPMOST
		_TEXT("first"), _TEXT("GUIPRINT"),
		WS_OVERLAPPEDWINDOW,				//  &~WS_MAXIMIZEBOX,	
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		0, 0, hInst, 0);

	// 4. ������ �����ֱ�
	ShowWindow(hwnd, SW_SHOW);
	UpdateWindow(hwnd);

	// 5. Message
	MSG msg;
	while (GetMessage(&msg, 0, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return 0;
}