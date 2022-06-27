//������ - GUI

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 


#define WM_MESSAGEADD  WM_USER+100
#define WM_MESSAGEDRAW WM_USER + 200

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_MESSAGEDRAW:
	{
		HDC hdc = GetDC(hwnd);	//hwnd ȭ�鿡 �׸��� �׸� �� �ִ� ��ü ȹ��

		Rectangle(hdc, wParam, lParam, wParam + 100, lParam + 100);	//�簢�� �׸��� �Լ�

		ReleaseDC(hwnd, hdc);	//���� ��ü ����

		return 0;
	}

	case WM_MESSAGEADD:
	{
		MessageBox(0, TEXT("�޽��� ����"), TEXT("�˸�"), MB_OK);
		int sum = wParam + lParam;
		return sum;
	}

	case WM_CREATE:
		MessageBox(0, TEXT("WM_CREATE"), TEXT("�˸�"), MB_OK);
		return 0;
	case WM_DESTROY:
		MessageBox(0, TEXT("WM_DESTROY"), TEXT("�˸�"), MB_OK);
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