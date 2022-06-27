//TLS
#pragma comment (linker, "/subsystem:console")

#include <windows.h>
#include <stdio.h>


void goo(char* name)		//6�� ȣ��
{
	// TLS ������ ������ �����Ѵ�.
	__declspec(thread) static int c = 0;	//�����庰�� ����� ���ϱ� �� 2��
	++c;

	static int sc = 0;		//������������ 1��
	++sc;
	printf("%s : %d : %d\n", name, c, sc); // �Լ��� ��� ȣ��Ǿ����� �˰� �ʹ�.
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
	//2���� Thread�� �� ����Ǿ�߸� ������ �ȴ�.
	WaitForMultipleObjects(2, h, TRUE, INFINITE);//TRUE;��ΰ� Signal�ɶ�����
	CloseHandle(h1);
	CloseHandle(h2);
}

