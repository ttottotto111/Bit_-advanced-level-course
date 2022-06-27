//IPC ������ 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 

#define WM_MESSAGE		WM_USER+100	//  wParam : x��ǥ, lParam : y��ǥ
#define WM_RECTANGLE	WM_USER+101	//  wParam : RGB��,  lParam : ��ǥ
#define WM_ELLIPSE		WM_USER+102	//  wParam : RGB��,  lParam : ��ǥ
#define WM_LINE			WM_USER+103 //  wParam : RGB��, lParam : ��ǥ


LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_MESSAGE:
	{
		TCHAR buf[50];
		wsprintf(buf, TEXT("[%d:%d]"), wParam, lParam);

		HDC hdc = GetDC(hwnd);
		TextOut(hdc, wParam, lParam, buf, _tcslen(buf));
		ReleaseDC(hwnd, hdc);

		return 0;
	}
	case WM_RECTANGLE:
	{
		POINTS pt = MAKEPOINTS(lParam);  //����4byte : Y, ����4byte : X

		HDC hdc = GetDC(hwnd);

		HBRUSH hbr = CreateSolidBrush((COLORREF)wParam);
		HBRUSH oldbr = (HBRUSH)SelectObject(hdc, hbr);

		Rectangle(hdc, pt.x, pt.y, pt.x + 100, pt.y + 100);

		DeleteObject(SelectObject(hdc, oldbr));

		ReleaseDC(hwnd, hdc);

		return 0;
	}
	case WM_ELLIPSE:
	{
		POINTS pt = MAKEPOINTS(lParam);  //����4byte : Y, ����4byte : X

		HDC hdc = GetDC(hwnd);

		HBRUSH hbr = CreateSolidBrush((COLORREF)wParam);
		HBRUSH oldbr = (HBRUSH)SelectObject(hdc, hbr);

		Ellipse(hdc, pt.x, pt.y, pt.x + 100, pt.y + 100);

		DeleteObject(SelectObject(hdc, oldbr));

		ReleaseDC(hwnd, hdc);

		return 0;
	}
	case WM_LINE:
	{
		POINTS pt = MAKEPOINTS(lParam);  //����4byte : Y, ����4byte : X

		HDC hdc = GetDC(hwnd);

		HPEN pen = CreatePen(PS_SOLID, 1, (COLORREF)wParam);
		HPEN oldpen = (HPEN)SelectObject(hdc, pen);

		MoveToEx(hdc, pt.x, pt.y, 0);
		LineTo(hdc, pt.x + 200, pt.y + 200);

		DeleteObject(SelectObject(hdc, oldpen));

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
	wc.style = 0;

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