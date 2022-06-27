//���콺 Ŭ���� �ΰ����� ȹ��

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 
#include <vector>
using namespace std;

#define WM_RECTANGLE	WM_USER+100

vector<POINT> pointlist;

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_NCHITTEST:
	{
		DWORD code = DefWindowProc(hwnd, msg, wParam, lParam);
		if (code == HTCLIENT && GetKeyState(VK_CONTROL) < 0)
			code = HTCAPTION;
		if (code == HTLEFT) code = HTRIGHT;
		return code;

	}
		case WM_LBUTTONDOWN :
		{
			//��ǥ ȹ�� (Ŭ���̾�Ʈ ��ǥ)
			POINTS pt1 = MAKEPOINTS(lParam);
			POINT pt2 = { LOWORD(lParam), HIWORD(lParam) };

			//����
			if (wParam & MK_CONTROL) {
				if (pointlist.size() <= 0)
					return 0;
				pointlist.pop_back();	//������������ ����
			}
			// ����
			else { 
				pointlist.push_back(pt2);
			}

			//��ȿȭ�����߻�
			InvalidateRect(hwnd, 0, TRUE); // 3���� ����
			//ȭ���� ������ΰ� (TRUE)? �����ΰ�(FALSE)?

			return 0;
		}

		case WM_PAINT:
		{
			PAINTSTRUCT ps;
			HDC hdc = BeginPaint(hwnd, &ps);

			for (int i = 0; i < (int)pointlist.size(); i++)
			{
				POINT pt = pointlist[i];
				Rectangle(hdc, pt.x - 50, pt.y - 50, pt.x + 50, pt.y + 50);
			}

			EndPaint(hwnd, &ps);
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