//Timer�� �̿��� ���� �۾�(page69) 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static int Blue = 0;

	switch (msg)
	{
	case WM_CREATE:
	{
		SetTimer(hwnd, 1, 10, NULL);
		return 0;
	}
	case WM_TIMER:
	{
		if (Blue >= 255)
			Blue = 0;
		Blue += 5;
		InvalidateRect(hwnd, NULL, FALSE);
		return 0;
	}
	case WM_PAINT:
	{
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hwnd, &ps);

		HBRUSH hbrush = CreateSolidBrush(RGB(0, 0, Blue));
		HBRUSH hOld = (HBRUSH)SelectObject(hdc, hbrush);

		Rectangle(hdc, 100, 100, 400, 400);

		DeleteObject(SelectObject(hdc, hOld));

		EndPaint(hwnd, &ps);
		return 0;
	}
	case WM_LBUTTONDOWN:
	{
		HDC hdc = GetDC(hwnd);
		POINTS pt = MAKEPOINTS(lParam);
		Rectangle(hdc, pt.x, pt.y, pt.x + 50, pt.y + 50);
		ReleaseDC(hwnd, hdc);
	}
	return 0;
	case WM_DESTROY:
	{
		KillTimer(hwnd, 1);
		PostQuitMessage(0);
		return 0;
	}
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
		_TEXT("first"), _TEXT("Hello"),
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