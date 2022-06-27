//자동이벤트

#pragma comment (linker, "/subsystem:console")

#include <iostream>
#include <windows.h>
using namespace std;

HANDLE hEvent1, hEvent2;
BOOL bContinue = TRUE;
int g_x, sum;

//쓰레드 함수
DWORD WINAPI ServerThread(LPVOID p)
{
	while (bContinue)
	{
		WaitForSingleObject(hEvent1, INFINITE);
		sum = 0;
		for (int i = 0; i < g_x; i++)
			sum += i;
		SetEvent(hEvent2);
	}
	cout << "Server종료" << endl;
	return 0;
}

void main()
{
	hEvent1 = CreateEvent(0, 0, 0, TEXT("e1"));
	hEvent2 = CreateEvent(0, 0, 0, TEXT("e2"));

	HANDLE hThread = CreateThread(NULL, NULL, ServerThread, 0, 0, 0);

	while (1)
	{
		cin >> g_x;
		if (g_x == -1) break;
		SetEvent(hEvent1); // Signal 발생...
						   // ... 다른 일 수행
		WaitForSingleObject(hEvent2, INFINITE);
		cout << "결과 : " << sum << endl;
	}

	// 먼저 ServerThread 종료
	bContinue = FALSE;
	SetEvent(hEvent1);

	WaitForSingleObject(hThread, INFINITE);
	CloseHandle(hThread);
}


//page43 MMF( 파일을 메모리처럼 사용할 수 있는 기술 )
//            프로세스와 프로세스간 데이터를 공유 

//page53 WM_COPYDATA ( 프로세스에서 프로세스간 데이터 전송)
//   
