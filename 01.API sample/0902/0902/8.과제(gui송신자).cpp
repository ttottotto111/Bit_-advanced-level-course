//0902�ǽ�(������) - ������ ����

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 

//[�۽���] ���콺 Ŭ��
#define WM_MSGPOINT  WM_USER + 100 //     wParam x��ǥ   lParam y��ǥ

//[�۽���] Ű����
#define WM_MSGSIZE   WM_USER+ 200   //   wParam size���� lParam 0
#define WM_MSGTYPE   WM_USER+ 210   //   wParma  Ÿ������ lParam 0
#define WM_MSGCOLOR  WM_USER +220   //   wParam �������� lParam 0

int g_type = 1;

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_KEYDOWN:
	{
		//������ �����츦 ã��
		//������ �޽��� ����
		HWND targethwnd = FindWindow(TEXT("First"), 0);
		if (targethwnd == 0)
		{
			MessageBox(0, TEXT("����"), TEXT("�˸�"), MB_OK);
			return 0;
		}

		switch (wParam)
		{
			//curshape.size
			//F1 : 25, F2 : 50, F3 : 75, F4 : 100  		
		case VK_F1:	SendMessage(targethwnd, WM_MSGSIZE, 25, 0);		break;
		case VK_F2:	SendMessage(targethwnd, WM_MSGSIZE, 50, 0);		break;
		case VK_F3:	SendMessage(targethwnd, WM_MSGSIZE, 75, 0);		break;
		case VK_F4:	SendMessage(targethwnd, WM_MSGSIZE, 100, 0);	break;
			//curshape.color
			//R : RGB(255,0,0), G : RGB(0,255,0), B : RGB(0,0,255)
		case 'R':	SendMessage(targethwnd, WM_MSGCOLOR, RGB(255, 0, 0), 0);	break;
		case 'G':	SendMessage(targethwnd, WM_MSGCOLOR, RGB(0, 255, 0), 0);	break;
		case 'B':	SendMessage(targethwnd, WM_MSGCOLOR, RGB(0, 0, 255), 0);	break;
		case 'I':	SendMessage(targethwnd, WM_MSGCOLOR,
			RGB(rand() % 256, rand() % 256, rand() % 256), 0);		break;
			//curshape.type  : 1 2 3
			//Up : ++ , DOWN : --
		case VK_UP: g_type++;
			if (g_type > 3)	g_type = 1;
			SendMessage(targethwnd, WM_MSGTYPE, g_type, 0);		break;
		case VK_DOWN:	g_type--;
			if (g_type < 1)	g_type = 3;
			SendMessage(targethwnd, WM_MSGTYPE, g_type, 0);		break;
		default:		break;
		}
		return 0;
	}
	case WM_LBUTTONDOWN:
	{
		//������ �����츦 ã��
		//������ �޽��� ����
		HWND targethwnd = FindWindow(TEXT("First"), 0);
		if (targethwnd == 0)
		{
			MessageBox(0, TEXT("����"), TEXT("�˸�"), MB_OK);
			return 0;
		}
		SendMessage(targethwnd, WM_MSGPOINT, LOWORD(lParam), HIWORD(lParam));

		return 0;
	}
	case WM_CREATE:
		return 0;
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
	wc.lpszClassName = _TEXT("First1");
	wc.lpszMenuName = 0;
	wc.style = 0;  //CS_DBLCLKS;

				   // 2. ���(������Ʈ����)
	RegisterClass(&wc);

	// 3. ������ â ����� 
	HWND hwnd = CreateWindowEx(0,			// WS_EX_TOPMOST
		_TEXT("First1"), _TEXT("������"),
		WS_OVERLAPPEDWINDOW,				//  &~WS_MAXIMIZEBOX,	
		CW_USEDEFAULT, 0, 300, 300,
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