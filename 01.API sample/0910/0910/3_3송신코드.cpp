//�۽� �ڵ� 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 

#define IDC_BUTTON1		10
#define IDC_EDIT1		20

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static HWND hEdit, hButton;

	switch (msg)
	{
	case WM_CREATE:
	{
		hEdit = CreateWindow(TEXT("edit"), TEXT(""),
			WS_CHILD | WS_VISIBLE | WS_BORDER,
			10, 10, 400, 30, hwnd, (HMENU)IDC_EDIT1, 0, 0);

		hButton = CreateWindow(TEXT("button"), TEXT("����"),
			WS_CHILD | WS_VISIBLE | WS_BORDER,
			420, 10, 100, 30, hwnd, (HMENU)IDC_BUTTON1, 0, 0);
		return 0;
	}
	case WM_COMMAND:
	{
		switch (LOWORD(wParam))
		{
		case IDC_BUTTON1:
		{
			HWND hwnd1 = FindWindow(0, TEXT("Badfads"));
			if (hwnd1 == 0)
			{
				MessageBox(0, TEXT("B �����츦 ���� ������ �ּ���"), TEXT("�˸�"), MB_OK);
				return 0;
			}
			TCHAR buf[256] = { 0 };
			GetDlgItemText(hwnd, IDC_EDIT1, buf, sizeof(buf));
			SetWindowText(hwnd, buf);
			// �������� Pointer�� �����ϱ� ���� �޼��� - WM_COPYDATA
			COPYDATASTRUCT cds = { 0 };
			cds.lpData = buf; // ������ Pointer
			cds.cbData = (_tcslen(buf) + 1) * 2; // ������ data ũ��
			cds.dwData = 1; // �ĺ���			
			SendMessage(hwnd1, WM_COPYDATA, 0, (LPARAM)&cds);
		}
		break;
		}
		return 0;
	}
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
		_TEXT("first"), _TEXT("B"),
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