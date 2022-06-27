//GDI ������Ʈ ��� ����

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_LBUTTONDOWN:
	{
		HDC hdc = GetDC(hwnd);	//����Ʈ ��, ����Ʈ �귯���� ���õ� ����

		//----------- ���� ���� ---------------------------
		HPEN pen = CreatePen(PS_DOT, 5, RGB(255, 0, 0));   //��� ��

		HPEN oldpen = (HPEN)SelectObject(hdc, pen);	//���ο� ���� ��� �������� ���� ���´�.
		//--------------------------------------------------

		Rectangle(hdc, 0, 0, 100, 100);

		//--------- ���� ���� -----------------------------
		//�ٽ� ����Ʈ���� ���, ����� ���� �ı� 
		DeleteObject(SelectObject(hdc, oldpen));

		ReleaseDC(hwnd, hdc);

		return 0;
	}

	case WM_PAINT:
	{
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hwnd, &ps);		//����Ʈ

		HBRUSH brush = CreateSolidBrush(RGB(0, 255, 0));
		HBRUSH oldbr = (HBRUSH)SelectObject(hdc, brush);

		HPEN pen = CreatePen(PS_DASHDOTDOT, 3, RGB(0, 0, 255));
		HPEN oldpen = (HPEN)SelectObject(hdc, pen);

		Rectangle(hdc, 100, 100, 200, 200);

		DeleteObject(SelectObject(hdc, oldbr));
		DeleteObject(SelectObject(hdc, oldpen));

		EndPaint(hwnd, &ps);
		return 0;
	}


	//������ ��ȿȭ ���� �߻�
	case WM_RBUTTONDOWN:
	{
		//2��° ���� : ����, 0�̸� ��ü ������ ��ȿȭ 
		InvalidateRect(hwnd, 0, TRUE);

		RECT rc = { 0,0,50,50 };
		//InvalidateRect(hwnd, &rc, TRUE);
		return 0;
	}


	case WM_CREATE:
		//		MessageBox(0, TEXT("WM_CREATE"), TEXT("�˸�"), MB_OK);
		return 0;
	case WM_DESTROY:
		//		MessageBox(0, TEXT("WM_DESTROY"), TEXT("�˸�"), MB_OK);
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