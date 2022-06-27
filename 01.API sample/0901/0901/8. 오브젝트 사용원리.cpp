//GDI 오브젝트 사용 원리

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_LBUTTONDOWN:
	{
		HDC hdc = GetDC(hwnd);	//디폴트 펜, 디폴트 브러쉬가 선택된 상태

		//----------- 도구 변경 ---------------------------
		HPEN pen = CreatePen(PS_DOT, 5, RGB(255, 0, 0));   //사온 것

		HPEN oldpen = (HPEN)SelectObject(hdc, pen);	//새로운 펜을 들고 기존펜은 내려 놓는다.
		//--------------------------------------------------

		Rectangle(hdc, 0, 0, 100, 100);

		//--------- 원상 복귀 -----------------------------
		//다시 디폴트펜을 들고, 들었던 펜은 파괴 
		DeleteObject(SelectObject(hdc, oldpen));

		ReleaseDC(hwnd, hdc);

		return 0;
	}

	case WM_PAINT:
	{
		PAINTSTRUCT ps;
		HDC hdc = BeginPaint(hwnd, &ps);		//디폴트

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


	//강제로 무효화 영역 발생
	case WM_RBUTTONDOWN:
	{
		//2번째 인자 : 영역, 0이면 전체 영역을 무효화 
		InvalidateRect(hwnd, 0, TRUE);

		RECT rc = { 0,0,50,50 };
		//InvalidateRect(hwnd, &rc, TRUE);
		return 0;
	}


	case WM_CREATE:
		//		MessageBox(0, TEXT("WM_CREATE"), TEXT("알림"), MB_OK);
		return 0;
	case WM_DESTROY:
		//		MessageBox(0, TEXT("WM_DESTROY"), TEXT("알림"), MB_OK);
		PostQuitMessage(0);
		return 0;
	}
	return DefWindowProc(hwnd, msg, wParam, lParam);
}


int WINAPI _tWinMain(HINSTANCE hInst, HINSTANCE hPrev, LPTSTR lpCmd, int nShow)
{
	// 1. 윈도우 클래스 만들기 
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

	// 2. 등록(레지스트리에)
	RegisterClass(&wc);

	// 3. 윈도우 창 만들기 
	HWND hwnd = CreateWindowEx(0,			// WS_EX_TOPMOST
		_TEXT("first"), _TEXT("Hello"),
		WS_OVERLAPPEDWINDOW,				//  &~WS_MAXIMIZEBOX,	
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0,
		0, 0, hInst, 0);

	// 4. 윈도우 보여주기
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