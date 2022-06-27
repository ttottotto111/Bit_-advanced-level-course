//동기화 (공유자원 문제 해결) : 
// 크리티컬섹션

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 

int x;	//전역변수

CRITICAL_SECTION g_cs;


//쓰레드함수
DWORD WINAPI ThreadFun1(LPVOID param) //윈도우핸들
{
	HDC hdc = GetDC((HWND)param);

	for (int i = 0; i < 100; i++)
	{
		EnterCriticalSection(&g_cs);

		x = 100;
		TextOut(hdc, x, 100, TEXT("강아지"), 3);

		LeaveCriticalSection(&g_cs);

		Sleep(1);
	}

	ReleaseDC((HWND)param, hdc);

	return 0;
}

DWORD WINAPI ThreadFun2(LPVOID param)
{
	HDC hdc = GetDC((HWND)param);
	for (int i = 0; i < 100; i++)
	{
		EnterCriticalSection(&g_cs);

		x = 200;
		TextOut(hdc, x, 200, TEXT("고양이"), 3);

		LeaveCriticalSection(&g_cs);

		Sleep(1);

	}
	ReleaseDC((HWND)param, hdc);
	return 0;
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_LBUTTONDOWN:
	{
		DWORD ThreadID;
		HANDLE hThread = CreateThread(NULL, 0, ThreadFun1, hwnd, 0, &ThreadID);
		CloseHandle(hThread);

		hThread = CreateThread(NULL, 0, ThreadFun2, hwnd, 0, &ThreadID);
		CloseHandle(hThread);

		return 0;
	}
	case WM_CREATE:
	{
		InitializeCriticalSection(&g_cs);
		return 0;
	}
	case WM_DESTROY:
		DeleteCriticalSection(&g_cs);
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
	wc.lpszClassName = _TEXT("First");
	wc.lpszMenuName = 0;
	wc.style = 0;  //CS_DBLCLKS;

				   // 2. 등록(레지스트리에)
	RegisterClass(&wc);

	// 3. 윈도우 창 만들기 
	HWND hwnd = CreateWindowEx(0,			// WS_EX_TOPMOST
		_TEXT("first"), _TEXT("Hello"),
		WS_OVERLAPPEDWINDOW,				//  &~WS_MAXIMIZEBOX,	
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
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