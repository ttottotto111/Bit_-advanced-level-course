//[���� 5-3] Thread�� ����� �� page76
//Thread ��� 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 

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

//Thread�Լ�
//����		: DWORD -> unsigned int
//ȣ��Ծ�	: WINAPI -> __stdcall
//����      : LPVOID -> void* (4byte)
DWORD WINAPI ThreadFunc1(LPVOID temp) // LPVOID temp <--- hwnd 
{
	fun1(temp);

	return 0;
}

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static HANDLE hThread;
	static DWORD ThreadID;

	switch (msg)
	{
	case WM_LBUTTONDOWN:
	{
		//	fun1(hwnd);
		hThread = CreateThread(NULL, 0, ThreadFunc1, hwnd, 0, &ThreadID);

		CloseHandle(hThread);

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