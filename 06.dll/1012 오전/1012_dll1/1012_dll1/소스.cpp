#include <stdio.h>
//------------------------DLL �Ͻ��� ��� �����ϵ��� �ڵ� �ۼ�
#include "cal.h"	//DLL�� �����
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