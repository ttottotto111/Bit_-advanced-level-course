//������ ��� �ڵ�

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>

typedef struct _LINE {
	POINTS ptFrom;
	POINTS ptTo;
}LINE;

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static HANDLE hEvent, hMap;
	static LINE* pData;		//�����޸𸮿� �����ϴ� ������
	static POINTS ptFrom;

	switch (msg) {
	case WM_LBUTTONDOWN:
	{
		ptFrom = MAKEPOINTS(lParam);
		return 0;
	}
	case WM_MOUSEMOVE:
	{
		if (wParam & MK_LBUTTON)
		{
			POINTS pt = MAKEPOINTS(lParam);

			HDC hdc = GetDC(hwnd);
			MoveToEx(hdc, ptFrom.x, ptFrom.y, 0);
			LineTo(hdc, pt.x, pt.y);
			ReleaseDC(hwnd, hdc);

			// MMF �� �ִ´�.
			pData->ptFrom = ptFrom;
			pData->ptTo = pt;
			SetEvent(hEvent);		//�̺�Ʈ ����
			ptFrom = pt;
		}
		return 0;
	}
	case WM_CREATE:
	{
		hEvent = CreateEvent(0, 0, 0, TEXT("DRAW_SIGNAL"));
		//HWND hFile = CreateFile()
		hMap = CreateFileMapping((HANDLE)-1, // Paging ȭ���� ����ؼ� ����
			0, PAGE_READWRITE, 0, sizeof(LINE), TEXT("map"));
		pData = (LINE*)MapViewOfFile(hMap, FILE_MAP_WRITE, 0, 0, 0);
		if (pData == 0)
			MessageBox(0, TEXT("Fail"), TEXT(""), MB_OK);
		return 0;
	}
	case WM_DESTROY:
		UnmapViewOfFile(pData);
		CloseHandle(hMap);
		CloseHandle(hEvent);
		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hwnd, msg, wParam, lParam);
}

int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hprev, LPTSTR lpCmd, int nShow)
{
	// 1. ������ Ŭ���� ����� 
	WNDCLASS wc;
	wc.cbWndExtra = 0;
	wc.cbClsExtra = 0;
	wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
	wc.hCursor = LoadCursor(0, IDC_ARROW);
	wc.hIcon = LoadIcon(0, IDI_APPLICATION);
	wc.hInstance = hInst;
	wc.lpfnWndProc = WndProc;			// DefWindowProc;
	wc.lpszClassName = _TEXT("First");
	wc.lpszMenuName = 0;
	wc.style = 0;

	// 2. ���(������Ʈ����)
	RegisterClass(&wc);

	// 3. ������ â ����� 
	HWND hwnd = CreateWindowEx(0,					// WS_EX_TOPMOST
		_TEXT("first"),				// Ŭ���� ��
		_TEXT("Sender"),				// ĸ�ǹ� ����
		WS_OVERLAPPEDWINDOW & ~WS_MAXIMIZEBOX,		// ��Ÿ��
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,	// ����x, ����y, ��, ����(�ʱ� ��ġ) 
		0, 0,			// �θ� ������ �ڵ�, �޴� �ڵ�
		hInst,		// WinMain�� 1��° �Ķ���� (exe �ּ�)
		0);			// ���� ����

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