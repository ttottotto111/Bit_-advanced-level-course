//MMF : Ȱ��1. ��뷮 �޸� ��� ���

#pragma comment(linker, "subsystem:console")

#include <stdio.h>
#include <windows.h>

int main()
{
	// 1. ȭ�� ����
	HANDLE hFile = CreateFile(TEXT("a.txt"), GENERIC_READ | GENERIC_WRITE,
		FILE_SHARE_READ | FILE_SHARE_WRITE, 0,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

	// 2. ȭ�� ���� KO ����
	HANDLE hMap = CreateFileMapping(hFile, 0, // ������ ȭ��, KO ����
		PAGE_READWRITE, // ���� ����
		0, 100, // ���� ��ü ũ��
		TEXT("map")); // ���� ��ü �̸�

	   // 3. ���� ��ü�� ����ؼ� ���� �ּҿ� ���� ����
	char* p = (char*)MapViewOfFileEx(hMap, FILE_MAP_WRITE,
		0, 0, // file offset
		0, // ũ��.(0 ���� ��ü ũ��) 
		(void*)0x10000000); // ���ϴ� �ּ�.

	if (p == NULL)
		printf("error");
	else {
		printf("���ε� �ּ� : %p\n", p);
		strcpy_s(p, sizeof(10), "hello");
		p[0] = 'a';
		p[1] = 'b';
		p[99] = 'z';
	}

	//����
	UnmapViewOfFile(p);
	CloseHandle(hMap);

	return 0;
}
