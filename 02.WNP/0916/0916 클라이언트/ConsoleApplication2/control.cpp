//control.cpp

#include "std.h"


void con_init()
{
	sock_LibInit();
	sock_CreateSocket();
}

void con_exit()
{
	sock_LibExit();
}


//Ŭ���̾�Ʈ --> ����
void con_netmember()
{
	MEMBER  mem;

	printf(">> ���̵� : ");
	gets_s(mem.id, sizeof(mem.id));

	printf(">> �н����� : ");
	gets_s(mem.pw, sizeof(mem.pw));

	printf(">> �̸� : ");
	gets_s(mem.name, sizeof(mem.name));

	printf(">> ���� : ");
	scanf_s("%d", &mem.age);

	getchar();

	//������ ����
	pack_SetNewMember(&mem);
	sock_Send((char*)&mem, sizeof(mem));

	printf("������ ȸ������ ������ ���½��ϴ�.\n");
}

void con_login()
{
	LOGIN  login;

	printf(">> ���̵� : ");
	gets_s(login.id, sizeof(login.id));

	printf(">> �н����� : ");
	gets_s(login.pw_name, sizeof(login.pw_name));

	getchar();

	//�˻� --> ������ ����
	pack_SetLogin(&login);
	sock_Send((char*)&login, sizeof(login));

	printf("������ �α��� ������ ���½��ϴ�.\n");
}

void con_logout()
{
	LOGIN  logout;

	printf(">> ���̵� : ");
	gets_s(logout.id, sizeof(logout.id));

	getchar();

	pack_SetLogout(&logout);
	sock_Send((char*)&logout, sizeof(logout));

	printf("������ �α׾ƿ� ������ ���½��ϴ�.\n");
}


//���� --> Ŭ���̾�Ʈ
void con_RecvData(char* buf)
{
	LOGIN login;
	int* flag = (int*)buf;
	if (*flag == ACK_NEWMEMBER_S)
	{
		MessageBox(0, TEXT("ȸ�����Լ���"),TEXT("�˸�"), MB_OK);
	}
	if (*flag == ACK_NEWMEMBER_F)
	{
		MessageBox(0, TEXT("�ߺ��� ID"), TEXT("�˸�"), MB_OK);
	}
	if (*flag == ACK_LOGIN_S)
	{
		MessageBox(0, TEXT("�α��� �Ǿ����ϴ�."), TEXT("�˸�"), MB_OK);
	}
	if (*flag == ACK_LOGIN_F)
	{
		MessageBox(0, TEXT("�α׾ƿ� �Ǿ����ϴ�."), TEXT("�˸�"), MB_OK);
	}
}