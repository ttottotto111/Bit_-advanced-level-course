//skeleton �ڵ� 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 
#define WM_MYMESSAGE WM_USER + 100 

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static HWND hEdit;

	switch (msg)
	{
	case WM_MYMESSAGE:
	{
		MessageBox(0, TEXT(""), TEXT(""), MB_OK);
		return 0;
	}
	case WM_CREATE:
	{
		hEdit = CreateWindow(TEXT("edit"), TEXT(""),
			WS_CHILD | WS_VISIBLE | WS_BORDER | ES_MULTILINE,
			10, 10, 400, 400, hwnd, (HMENU)1, 0, 0);
		return 0;
	}
	case WM_COPYDATA:
	{
		COPYDATASTRUCT* p = (COPYDATASTRUCT*)lParam;
		if (p->dwData == 1) // �ĺ��� ����.
		{
			// Edit Box�� �߰� �Ѵ�.
			SendMessage(hEdit, EM_REPLACESEL, 0, (LPARAM)(p->lpData));
			SendMessage(hEdit, EM_REPLACESEL, 0, (LPARAM)"\r\n");
		}
		return 0;
	}
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
	wc.style = 0;  //CS_DBLCLKS;

				   // 2. ���(������Ʈ����)
	RegisterClass(&wc);

	// 3. ������ â ����� 
	HWND hwnd = CreateWindowEx(0,			// WS_EX_TOPMOST
		_TEXT("first"), _TEXT("Badfads"),
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