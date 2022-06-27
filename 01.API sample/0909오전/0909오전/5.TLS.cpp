//TLS
#pragma comment (linker, "/subsystem:console")

#include <windows.h>
#include <stdio.h>


void goo(char* name)		//6번 호출
{
	// TLS 공간에 변수를 생성한다.
	__declspec(thread) static int c = 0;	//쓰레드별로 만들어 지니깐 총 2개
	++c;

	static int sc = 0;		//정적전역공간 1개
	++sc;
	printf("%s : %d : %d\n", name, c, sc); // 함수가 몇번 호출되었는지 알고 싶다.
}


DWORD WINAPI foo(void* p)
{
	char* name = (char*)p;
	goo(name);
	goo(name);
	goo(name);

	return 0;
}

void main()
{
	HANDLE h1 = CreateThread(0, 0, foo, "A", 0, 0);
	HANDLE h2 = CreateThread(0, 0, foo, "\tB", 0, 0);


	HANDLE h[2] = { h1, h2 };
	//2개의 Thread가 다 종료되어야만 리턴이 된다.
	WaitForMultipleObjects(2, h, TRUE, INFINITE);//TRUE;모두가 Signal될때까지
	CloseHandle(h1);
	CloseHandle(h2);
}

