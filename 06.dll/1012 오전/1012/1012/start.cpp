#include <stdio.h>
//선언부를 알기 때문에 바로 함수를 사용
#include "cal.h"

int main()
{
	printf("%1f\n", add(10, 20));
	printf("%1f\n", sub(10, 20));
	printf("%1f\n", mul(10, 20));
	printf("%1f\n", div(10, 20));
}