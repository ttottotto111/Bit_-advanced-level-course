//동기화 : 공유자원인 콘솔화면에 2개의 쓰레드가 동시에 접근하여 
//         출력 요청을 하는 과정..

#pragma comment (linker, "/subsystem:console")

#include <windows.h>
#include <iostream>
using namespace std;
#include <process.h>


unsigned int __stdcall foo(void* p)
{
	char* msg = (char*)p;
	for (int i = 0; i < 20; i++)
	{
		cout << msg << "........." << "test 문자열" << endl;
		Sleep(10);
	}
	return 0;
}

unsigned int __stdcall woo(void* p)
{
	char* msg = (char*)p;
	for (int i = 0; i < 20; i++)
	{
		cout << msg << "____________" << "테스트 문자열" << endl;
		Sleep(10);
	}
	return 0;
}


int main()
{
	unsigned int h1 = _beginthreadex(0, 0, foo, (LPVOID)"A", 0, 0);
	unsigned int h2 = _beginthreadex(0, 0, woo, "\tB", 0, 0);


	unsigned int h[2] = { h1, h2 };
	//2개의 Thread가 다 종료되어야만 리턴이 된다.
	WaitForMultipleObjects(2, (HANDLE*)h, TRUE, INFINITE);//TRUE;모두가 Signal될때까지
	CloseHandle((HANDLE)h1);
	CloseHandle((HANDLE)h2);

	return 0;
}

