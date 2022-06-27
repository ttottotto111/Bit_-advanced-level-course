//윈도우 핸들 제어
#pragma comment (linker, "/subsystem:console")

#include <iostream>
using namespace std;
//윈도우 API사용가능
#include<Windows.h>

int main()
{
	//윈도우 핸들 얻기 : 윈도우 핸들은 시스템에 전역적 성질을 갖고 있다.
	//1. 클래스명
	//2. 타이틀 이름

	HWND hwnd = FindWindow(0, TEXT("계산기"));
	if (hwnd == 0)
	{
		MessageBox(0, TEXT("계산기 실행 전"), TEXT("알림"), MB_YESNO | MB_ICONQUESTION);
		return 0;
	}

	printf("계산기 핸들 값 : %d\n", (int)hwnd);

	MoveWindow(hwnd, 0, 0, 100, 100, FALSE);

		return 0;
}