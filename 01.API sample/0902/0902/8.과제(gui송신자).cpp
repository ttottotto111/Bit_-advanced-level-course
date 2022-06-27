//0902실습(리모컨) - 설정값 변경

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 

//[송신자] 마우스 클릭
#define WM_MSGPOINT  WM_USER + 100 //     wParam x좌표   lParam y좌표

//[송신자] 키보드
#define WM_MSGSIZE   WM_USER+ 200   //   wParam size정보 lParam 0
#define WM_MSGTYPE   WM_USER+ 210   //   wParma  타입정보 lParam 0
#define WM_MSGCOLOR  WM_USER +220   //   wParam 색상정보 lParam 0

int g_type = 1;

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_KEYDOWN:
	{
		//전송할 윈도우를 찾기
		//적절한 메시지 전송
		HWND targethwnd = FindWindow(TEXT("First"), 0);
		if (targethwnd == 0)
		{
			MessageBox(0, TEXT("없다"), TEXT("알림"), MB_OK);
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
		//전송할 윈도우를 찾기
		//적절한 메시지 전송
		HWND targethwnd = FindWindow(TEXT("First"), 0);
		if (targethwnd == 0)
		{
			MessageBox(0, TEXT("없다"), TEXT("알림"), MB_OK);
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
	// 1. 윈도우 클래스 만들기 
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

				   // 2. 등록(레지스트리에)
	RegisterClass(&wc);

	// 3. 윈도우 창 만들기 
	HWND hwnd = CreateWindowEx(0,			// WS_EX_TOPMOST
		_TEXT("First1"), _TEXT("리모컨"),
		WS_OVERLAPPEDWINDOW,				//  &~WS_MAXIMIZEBOX,	
		CW_USEDEFAULT, 0, 300, 300,
		0, 0, hInst, 0);

	// 4. 윈도우 보여주기
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