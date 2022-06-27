//�ҽ�.cpp

#include <stdio.h>
#include <Windows.h>
//�Լ������� Ÿ���� ���� 
//FUNC : Ÿ�� Ű����
//void (*)(int, int) : ����Ÿ��- ����float, �Ű�������int,int�� �Լ��� �ּ�
typedef float(*FUNC)(int, int);

int main()
{
	//�ʿ��� �� DLL�ε�
	HMODULE hDll = LoadLibrary(TEXT("1012_dll.dll"));
	if (hDll == 0)
	{
		printf("dll �� ã������ �����ϴ�.\n");
		return 0;
	}

	//=========================================
	FUNC f_add = (FUNC)GetProcAddress(hDll, "add");
	FUNC f_sub = (FUNC)GetProcAddress(hDll, "sub");
	FUNC f_mul = (FUNC)GetProcAddress(hDll, "mul");
	FUNC f_div = (FUNC)GetProcAddress(hDll, "div");

	printf("%1f\n", f_add(10, 20));
	printf("%1f\n", f_sub(10, 20));
	printf("%1f\n", f_mul(10, 20));
	printf("%1f\n", f_div(10, 20));
	//=========================================

	//�ʿ���� �� DLL����
	FreeLibrary(hDll);
	return 0;
}
