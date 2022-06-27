#include <stdio.h>
//------------------------DLL 암시적 사용 가능하도록 코드 작성
#include "cal.h"	//DLL의 선언부
#pragma comment(lib, "1012_dll.lib")
//------------------------------------------------------------

int main()
{
	printf("%1f\n", add(10, 20));
	printf("%1f\n", sub(10, 20));
	printf("%1f\n", mul(10, 20));
	printf("%1f\n", div(10, 20));

	return 0;
}