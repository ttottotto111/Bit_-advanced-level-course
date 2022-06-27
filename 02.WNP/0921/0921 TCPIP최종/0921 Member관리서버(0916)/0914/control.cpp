//control.cpp

#include "std.h"

vector<memberdata> g_memlist;

void con_init()
{
	sock_LibInit();
	sock_CreateSocket();
}

void con_run()
{
	printf("���� ���� ���̴�(61.81.98.100:9000).....\n");
	unsigned int hthread = _beginthreadex(0, 0, sock_ListenThread, 0, 0, 0);

	WaitForSingleObject((HANDLE)hthread, INFINITE);
	CloseHandle((HANDLE)hthread);
}

void con_exit()
{
	sock_LibExit();
}

void PrintMemberList()
{
	printf("-------------------------------------------------------------\n");
	for (int i = 0; i < (int)g_memlist.size(); i++)
	{
		memberdata mem = g_memlist[i];
		printf("[%s] %s\t%s\t%s\t%d\n", (mem.islogin? "O":"X"),
			mem.id, mem.pw, mem.name, mem.age);
	}
	printf("-------------------------------------------------------------\n");
}

//Ŭ���̾�Ʈ���� ���� ������ -=============================
void con_RecvData(char* buf, int *size)
{
	int *flag = (int*)buf;	//????
	if (*flag == PACK_NEWMEMBER)
	{
		RecvNewMember((MEMBER*)buf);
		*size = sizeof(MEMBER);
	}
	else if (*flag == PACK_LOGIN)
	{
		RecvLogin((LOGIN*)buf);
		*size = sizeof(LOGIN);
	}
	else if (*flag == PACK_LOGOUT)
	{
		RecvLogOut((LOGIN*)buf);
		*size = sizeof(LOGIN);
	}
}

void RecvNewMember(MEMBER *pmem)
{
	//����ó��:�ߺ�IDüũ
	for (int i = 0; i < (int)g_memlist.size(); i++)
	{
		memberdata mem = g_memlist[i];
		if (strcmp(mem.id, pmem->id) == 0)
		{
			strcpy_s(pmem->name, sizeof(pmem->name), "�ߺ�ID");
			pmem->flag = ACK_NEWMEMBER_F;
			return;
		}
	}

	memberdata mem;
	strcpy_s(mem.id, sizeof(mem.id), pmem->id);
	strcpy_s(mem.pw, sizeof(mem.pw), pmem->pw);
	strcpy_s(mem.name, sizeof(mem.name), pmem->name);
	mem.age = pmem->age;
	mem.islogin = false;

	g_memlist.push_back(mem);

	PrintMemberList();	//<================= ��� Ȯ��

	//========= ����޽����� ����� ���� ó�� ������ =============
	//ȸ�����Կ�û�� ���� ������Ŷ�� Ŭ���̾�Ʈ�� ���� ������ �״�� ����ְ�.
	//flag�� ������.
	pmem->flag = ACK_NEWMEMBER_S;
}

void RecvLogin(LOGIN* plogin)
{
	for (int i = 0; i < (int)g_memlist.size(); i++)
	{
		memberdata mem = g_memlist[i];
		if (strcmp(mem.id, plogin->id) == 0 && strcmp(mem.pw, plogin->pw_name) == 0)
		{
			g_memlist[i].islogin = true;
			PrintMemberList();	//<================= ��� Ȯ��

			//�α��� ���� ��Ŷ�� ����ACK_LOGIN_S
			plogin->flag = ACK_LOGIN_S;
			//#include <tchar.h>
			_tcscpy_s(plogin->pw_name, sizeof(plogin->pw_name), g_memlist[i].name);
			return;
		}
	}
	plogin->flag = ACK_LOGIN_F;
}

void RecvLogOut(LOGIN* plogout)
{
	for (int i = 0; i < (int)g_memlist.size(); i++)
	{
		memberdata mem = g_memlist[i];
		if (strcmp(mem.id, plogout->id) == 0)
		{
			g_memlist[i].islogin = false;
			PrintMemberList();	//<================= ��� Ȯ��
			return;
		}
	}
}