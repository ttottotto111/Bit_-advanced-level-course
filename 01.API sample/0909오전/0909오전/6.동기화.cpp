//����ȭ : �����ڿ��� �ܼ�ȭ�鿡 2���� �����尡 ���ÿ� �����Ͽ� 
//         ��� ��û�� �ϴ� ����..

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
		cout << msg << "........." << "test ���ڿ�" << endl;
		Sleep(10);
	}
	return 0;
}

unsigned int __stdcall woo(void* p)
{
	char* msg = (char*)p;
	for (int i = 0; i < 20; i++)
	{
		cout << msg << "____________" << "�׽�Ʈ ���ڿ�" << endl;
		Sleep(10);
	}
	return 0;
}


int main()
{
	unsigned int h1 = _beginthreadex(0, 0, foo, (LPVOID)"A", 0, 0);
	unsigned int h2 = _beginthreadex(0, 0, woo, "\tB", 0, 0);


	unsigned int h[2] = { h1, h2 };
	//2���� Thread�� �� ����Ǿ�߸� ������ �ȴ�.
	WaitForMultipleObjects(2, (HANDLE*)h, TRUE, INFINITE);//TRUE;��ΰ� Signal�ɶ�����
	CloseHandle((HANDLE)h1);
	CloseHandle((HANDLE)h2);

	return 0;
}

