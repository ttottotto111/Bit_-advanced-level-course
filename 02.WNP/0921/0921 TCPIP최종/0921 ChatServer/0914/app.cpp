//app.cpp

#include "std.h"

void app_init()
{
	con_init();
	logo();
}


void app_run()
{
	con_run();
}

void app_exit()
{
	con_exit();
	ending();
}

void logo()
{
	system("cls");	//ȭ�� ����� #include <stdlib.h>
	printf("***************************************************\n");
	printf(" ���� ����(������ �ۼ��� ����)\n");
	printf(" ���� IP   : 61.81.98.100\n");
	printf(" ���� PORT : 8000\n");
	printf("***************************************************\n\n");	
}

void ending()
{	
	printf("***************************************************\n");
	printf("������ �����մϴ�.\n");
	printf("***************************************************\n");
}

