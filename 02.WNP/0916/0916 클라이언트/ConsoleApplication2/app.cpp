//app.cpp

#include "std.h"


void app_init()
{
	con_init();
	logo();
}


void app_run()
{
	while (1)
	{
		system("cls");
		
		menuprint();
		char ch = _getch();		//#include <conio.h>
		switch (ch)
		{
		case '1':	con_netmember();		break;
		case '2':	con_login();			break;
		case '3':	con_logout();			break;
		case '4':   return;		// �Լ��� ���� Ű���� 
		}
		system("pause");
	}
}

void app_exit()
{
	ending();
	con_exit();
}

void logo()
{
	system("cls");	//ȭ�� ����� #include <stdlib.h>
	printf("***************************************************\n");
	printf(" ������ : ��Ʈ ��� 32\n");
	printf(" ��  �� : Window Network Programming\n");
	printf(" ��  �� : 2020�� 9�� 16��\n");
	printf(" ��  �� : TCP/IP ��� ����Ŭ���̾�Ʈ ��Ŷ �ۼ���\n");
	printf(" ������ : ȫ�浿\n");
	printf("***************************************************\n");
	system("pause");	//����
}

void ending()
{
	system("cls");
	printf("***************************************************\n");
	printf("���α׷��� �����մϴ�.\n");
	printf("***************************************************\n");
	system("pause");
}

void menuprint()
{
	printf("***************************************************\n");
	printf(" [1] ȸ������(insert)\n");
	printf(" [2] �α���(update)\n");
	printf(" [3] �α׾ƿ�(update)\n");
	printf(" [4] ���α׷� ����\n");
	printf("***************************************************\n");
}
