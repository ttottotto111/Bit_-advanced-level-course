//���콺 ĸó
/*
LButtonDown Ŭ���� : ĸó
LButtonUp Ŭ����  : ĸó ����
*/
//���콺 �̵��Ҷ����� ��ǥ��(��ũ����ǥ, Ŭ���̾�Ʈ��ǥ)�� ����ϰڴ�.
//ĸó ���¿����� ���콺 �̵��� �׸��� �׸��ڴ�.
#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 

POINT curPoint;

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_LBUTTONDOWN:
	{
		SetCapture(hwnd);
		curPoint = { LOWORD(lParam), HIWORD(lParam) };
		return 0;
	}
	case WM_LBUTTONUP:
	{
		ReleaseCapture();
		return 0;
	}
	case WM_MOUSEMOVE:	//Ŭ���̾�Ʈ ���� ���콺 �޽���
	{
		POINT pt = { LOWORD(lParam), HIWORD(lParam) };
		POINT pt1 = pt;
		ClientToScreen(hwnd, &pt1);

		TCHAR buf1[50], buf2[50];

		wsprintf(buf1, TEXT("Ŭ���̾�Ʈ ��ǥ : %d, %d"), pt.x, pt.y);
		wsprintf(buf2, TEXT("��  ũ  �� ��ǥ : %d, %d"), pt1.x, pt1.y);

		HDC hdc = GetDC(hwnd);

		TextOut(hdc, 10, 10, buf1, _tcslen(buf1));
		TextOut(hdc, 10, 30, buf2, _tcslen(buf2));
		//MoveToEx(hdc, curPoint.x, curPoint.y, 0);
		if (GetCapture() == hwnd)	//hwnd�� ���Ļ����̳�?
		{
			MoveToEx(hdc, curPoint.x, curPoint.y, 0);
			LineTo(hdc, pt.x, pt.y);
			curPoint = pt;
		}

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