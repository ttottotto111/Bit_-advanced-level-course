//사용자 정의 메시지

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 

/*
메시지
1) #define WM_LBUTTONDOWN 0x0201
2) 이벤트가 발생되게 되면 메시지가 전달
   비큐메시지(프로시저를 직접 호출) - 함수 호출개념과 동일..
   SendMessage(hwnd, WM_LBUTTONDOWN, ?, xy좌표 전달);
------------- 시스템에 의해 제공 ------------------------
3) 메시지 프로시저에서 해당 메시지를 약속된 형태로 사용
   WM_LBUTTONDOWN이 발생되었을때 xy좌표는 lParam에 있구나...
*/

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_LBUTTONDOWN:
	{
		POINTS pt = MAKEPOINTS(lParam);	//마우스 좌표 정보 획득

		int x = LOWORD(lParam);		//하위 2byte값을 획득
		int y = HIWORD(lParam);		//상위 2byte값을 획득

		TCHAR buf[50];
		wsprintf(buf, TEXT("%d:%d"), pt.x, pt.y);

		//hwnd가 갖고 있는 문자열 변경 
		SetWindowText(hwnd, buf);
	}
	return 0;

	case WM_CREATE:
		MessageBox(0, TEXT("WM_CREATE"), TEXT("알림"), MB_OK);
		return 0;
	case WM_DESTROY:
		MessageBox(0, TEXT("WM_DESTROY"), TEXT("알림"), MB_OK);
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