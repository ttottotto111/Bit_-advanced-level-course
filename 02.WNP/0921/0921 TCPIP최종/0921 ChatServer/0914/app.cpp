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
	system("cls");	//화면 지우기 #include <stdlib.h>
	printf("***************************************************\n");
	printf(" 서버 시작(데이터 송수신 서버)\n");
	printf(" 서버 IP   : 61.81.98.100\n");
	printf(" 서버 PORT : 8000\n");
	printf("***************************************************\n\n");	
}

void ending()
{	
	printf("***************************************************\n");
	printf("서버를 종료합니다.\n");
	printf("***************************************************\n");
}

