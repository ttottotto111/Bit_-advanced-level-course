//MMF : 활용1. 대용량 메모리 사용 기법

#pragma comment(linker, "subsystem:console")

#include <stdio.h>
#include <windows.h>

int main()
{
	// 1. 화일 생성
	HANDLE hFile = CreateFile(TEXT("a.txt"), GENERIC_READ | GENERIC_WRITE,
		FILE_SHARE_READ | FILE_SHARE_WRITE, 0,
		CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0);

	// 2. 화일 매핑 KO 생성
	HANDLE hMap = CreateFileMapping(hFile, 0, // 매핑할 화일, KO 보안
		PAGE_READWRITE, // 접근 권한
		0, 100, // 매핑 객체 크기
		TEXT("map")); // 매핑 객체 이름

	   // 3. 매핑 객체를 사용해서 가상 주소와 파일 연결
	char* p = (char*)MapViewOfFileEx(hMap, FILE_MAP_WRITE,
		0, 0, // file offset
		0, // 크기.(0 매핑 객체 크기) 
		(void*)0x10000000); // 원하는 주소.

	if (p == NULL)
		printf("error");
	else {
		printf("매핑된 주소 : %p\n", p);
		strcpy_s(p, sizeof(10), "hello");
		p[0] = 'a';
		p[1] = 'b';
		p[99] = 'z';
	}

	//해지
	UnmapViewOfFile(p);
	CloseHandle(hMap);

	return 0;
}
