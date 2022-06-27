//[예제 5-2] Thread를 사용하지 않는 예 page74
//Thread 가 필요한 이유
//특정 작업이 오래걸리거나 무한시간을 사용한다면?
//- 프로시저가 종료하지 못하기 때문에 사용자 이벤트 처리 불가능하게 됨
//- GUI는 어떤경우라도 메시지루프가 정상적으로 동작을 해야 한다.
//  Primary Thread는 반드시 멈추지 않고 동작을 해야 한다.
//- 만약, 특정 작업이 오래걸리거나 무한시간을 사용한다면
//  별도의 쓰레드를 생성해서 해당 기능을 동작시킨다. 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 

void fun1(LPVOID temp)
{
	HWND h = (HWND)temp;

	HDC hdc = GetDC(h);

	while (1)
	{
		//		Sleep(1);
		HBRUSH hBrush = CreateSolidBrush(RGB(rand() % 256, rand() % 256, rand() % 256));
		HBRUSH hOldBrush = (HBRUSH)SelectObject(hdc, hBrush);

		Rectangle(hdc, 100, 100, 300, 400);

		SelectObject(hdc, hOldBrush);
		DeleteObject(hBrush);
	}
	ReleaseDC(h, hdc);
}


LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_LBUTTONDOWN:
	{
		fun1(hwnd);

		return 0;
	}
	case WM_RBUTTONDOWN:
	{
		HDC hdc = GetDC(hwnd);

		POINT pt = { LOWORD(lParam), HIWORD(lParam) };

		Ellipse(hdc, pt.x, pt.y, pt.x + 20, pt.y + 20);

		ReleaseDC(hwnd, hdc);

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