//������ �ڵ� ����
#pragma comment (linker, "/subsystem:console")

#include <iostream>
using namespace std;
//������ API��밡��
#include<Windows.h>

int main()
{
	//������ �ڵ� ��� : ������ �ڵ��� �ý��ۿ� ������ ������ ���� �ִ�.
	//1. Ŭ������
	//2. Ÿ��Ʋ �̸�

	HWND hwnd = FindWindow(0, TEXT("����"));
	if (hwnd == 0)
	{
		MessageBox(0, TEXT("���� ���� ��"), TEXT("�˸�"), MB_YESNO | MB_ICONQUESTION);
		return 0;
	}

	printf("���� �ڵ� �� : %d\n", (int)hwnd);

	MoveWindow(hwnd, 0, 0, 100, 100, FALSE);

		return 0;
}