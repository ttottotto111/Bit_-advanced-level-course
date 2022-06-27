//4. Thread����

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 
#include <CommCtrl.h>	//PBM_SETPOS

//Thread �Լ�
DWORD WINAPI foo(void* p)
{
	HWND hPrg = (HWND)p;
	for (int i = 0; i < 1000; ++i)
	{
		SendMessage(hPrg, PBM_SETPOS, i, 0); // ���α׷��� ����
		for (int k = 0; k < 5000000; ++k); // 0 6�� - some work.!!
	}
	return 0;
}



LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
	static HWND hPrg;			//���α׷����� �ڵ�(GUI)
	static HWND hprg;
	static HANDLE hThread;		//������ �ڵ�(KERNEL)
	static HANDLE hthread;		//������ �ڵ�(KERNEL)


	switch (msg)
	{
	case WM_CREATE:
	{
		//���α׷�����1 
		hPrg = CreateWindow(PROGRESS_CLASS, TEXT(""),
			WS_CHILD | WS_VISIBLE | WS_BORDER | PBS_SMOOTH,
			10, 10, 500, 30, hwnd, (HMENU)1, 0, 0);
		//����:0 ~1000 �ʱ���ġ:0���� �ʱ�ȭ.
		SendMessage(hPrg, PBM_SETRANGE32, 0, 1000);
		SendMessage(hPrg, PBM_SETPOS, 0, 0);

		//���α׷�����2
		hprg = CreateWindow(PROGRESS_CLASS, TEXT(""),
			WS_CHILD | WS_VISIBLE | WS_BORDER | PBS_SMOOTH,
			10, 50, 500, 30, hwnd, (HMENU)2, 0, 0);
		//����:0 ~1000 �ʱ���ġ:0���� �ʱ�ȭ.
		SendMessage(hprg, PBM_SETRANGE32, 0, 1000);
		SendMessage(hprg, PBM_SETPOS, 0, 0);


		return 0;
	}
	case WM_KEYDOWN:
	{
		if (wParam == 'Q')		//Thread����
		{
			DWORD tid;
			hThread = CreateThread(0, 0,
				foo, (void*)hPrg,
				CREATE_SUSPENDED,// ���������� ������ ���� �ʴ´�.
				&tid);
		}
		else if (wParam == 'A')	//������ ������ Thread�� ����/���� ���
		{
			static BOOL bRun = FALSE;
			bRun = !bRun; // Toggle

			if (bRun)
				ResumeThread(hThread); // ������ �簳
			else
				SuspendThread(hThread); // ������ �Ͻ� ����
		}
		else if (wParam == 'W')
		{
			DWORD tid;
			hthread = CreateThread(0, 0,
				foo, (void*)hprg,
				CREATE_SUSPENDED,// ���������� ������ ���� �ʴ´�.
				&tid);

			CloseHandle(hthread); //�ڵ��� �ݾҴ�. -> ���̻� ���� �Ұ���
		}
		else if (wParam == 'S')
		{
			static BOOL bRun = FALSE;
			bRun = !bRun; // Toggle

			if (bRun)
				ResumeThread(hthread); // ������ �簳
			else
				SuspendThread(hthread); // ������ �Ͻ� ����
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