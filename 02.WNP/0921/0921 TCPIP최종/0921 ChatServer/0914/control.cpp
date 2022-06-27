//control.cpp

#include "std.h"

void con_init()
{
	sock_LibInit();
	sock_CreateSocket();
}

void con_run()
{
	printf("���� ���� ���̴�(61.81.98.100:8000).....\n");
	unsigned int hthread = _beginthreadex(0, 0, sock_ListenThread, 0, 0, 0);

	WaitForSingleObject((HANDLE)hthread, INFINITE);
	CloseHandle((HANDLE)hthread);
}

void con_exit()
{
	sock_LibExit();
}


//Ŭ���̾�Ʈ���� ���� ������ -=============================
void con_RecvData(char* buf, int *size)
{
	int *flag = (int*)buf;	//????
	if (*flag == PACK_TEXTMESSAGE)
	{
		RecvTextMessage((COPYPASTMSG*)buf);
		*size = sizeof(COPYPASTMSG);
	}
	else if (*flag == PACK_SHORTMESSAGE)
	{
		RecvShortMessage((SHORTMSG*)buf);
		*size = sizeof(SHORTMSG);
	}
}

void RecvTextMessage(COPYPASTMSG *pmsg)
{
	pmsg->flag = ACK_TEXTMESSAGE;
}

void RecvShortMessage(SHORTMSG *pmsg)
{
	pmsg->flag = ACK_SHORTMESSAGE;
}
