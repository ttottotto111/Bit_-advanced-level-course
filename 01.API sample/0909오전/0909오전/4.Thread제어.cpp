//4. Thread제어

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//범용타입 사용을 위한 h 
#include <CommCtrl.h>	//PBM_SETPOS

//Thread 함수
DWORD WINAPI foo(void* p)
{
	HWND hPrg = (HWND)p;
	for (int i = 0; i < 1000; ++i)
	{
		SendMessage(hPrg, PBM_SETPOS, i, 0); // 프로그래스 전진
		for (int k = 0; k < 5000000; ++k); // 0 6개 - some work.!!
	}
	return 0;
}



LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static HWND hPrg;			//프로그래스바 핸들(GUI)
	static HWND hprg;
	static HANDLE hThread;		//쓰레드 핸들(KERNEL)
	static HANDLE hthread;		//쓰레드 핸들(KERNEL)


	switch (msg)
	{
	case WM_CREATE:
	{
		//프로그래스바1 
		hPrg = CreateWindow(PROGRESS_CLASS, TEXT(""),
			WS_CHILD | WS_VISIBLE | WS_BORDER | PBS_SMOOTH,
			10, 10, 500, 30, hwnd, (HMENU)1, 0, 0);
		//범위:0 ~1000 초기위치:0으로 초기화.
		SendMessage(hPrg, PBM_SETRANGE32, 0, 1000);
		SendMessage(hPrg, PBM_SETPOS, 0, 0);

		//프로그래스바2
		hprg = CreateWindow(PROGRESS_CLASS, TEXT(""),
			WS_CHILD | WS_VISIBLE | WS_BORDER | PBS_SMOOTH,
			10, 50, 500, 30, hwnd, (HMENU)2, 0, 0);
		//범위:0 ~1000 초기위치:0으로 초기화.
		SendMessage(hprg, PBM_SETRANGE32, 0, 1000);
		SendMessage(hprg, PBM_SETPOS, 0, 0);


		return 0;
	}
	case WM_KEYDOWN:
	{
		if (wParam == 'Q')		//Thread생성
		{
			DWORD tid;
			hThread = CreateThread(0, 0,
				foo, (void*)hPrg,
				CREATE_SUSPENDED,// 생성하지만 실행은 하지 않는다.
				&tid);
		}
		else if (wParam == 'A')	//위에서 생성된 Thread를 정지/동작 토글
		{
			static BOOL bRun = FALSE;
			bRun = !bRun; // Toggle

			if (bRun)
				ResumeThread(hThread); // 스레드 재개
			else
				SuspendThread(hThread); // 스레드 일시 중지
		}
		else if (wParam == 'W')
		{
			DWORD tid;
			hthread = CreateThread(0, 0,
				foo, (void*)hprg,
				CREATE_SUSPENDED,// 생성하지만 실행은 하지 않는다.
				&tid);

			CloseHandle(hthread); //핸들을 닫았다. -> 더이상 제어 불가능
		}
		else if (wParam == 'S')
		{
			static BOOL bRun = FALSE;
			bRun = !bRun; // Toggle

			if (bRun)
				ResumeThread(hthread); // 스레드 재개
			else
				SuspendThread(hthread); // 스레드 일시 중지
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
	wc.style = 0;  //CS_DBLCLKS;

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