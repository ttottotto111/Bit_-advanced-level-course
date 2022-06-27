//wbchatchilent.cpp

#include "std.h"

#define SERVER_IP		"127.0.0.1" //(�ڽ��� IP)   (IT����) 61.81.98.100
#define SERVER_PORT		8000

SOCKET cc_socket;

void sockc_Close()
{
	closesocket(cc_socket);
}

void sockc_CreateSocket()
{
	//1. ���� ���� 
	cc_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (cc_socket == INVALID_SOCKET)
	{
		printf("���� ���� ����\n");
		exit(0);
	}

	//2. ���� ����
	//���� �ּ�(������ �ּ�)�� ����
	SOCKADDR_IN serveraddr;
	ZeroMemory(&serveraddr, sizeof(serveraddr));
	serveraddr.sin_family = AF_INET;
	serveraddr.sin_port = htons(SERVER_PORT);
	//	serveraddr.sin_addr.s_addr = inet_addr(SERVER_IP);
	char buf[50] = SERVER_IP;
	inet_pton(AF_INET, buf, (SOCKADDR*)&serveraddr.sin_addr);

	//������ ���� ��û
	int retval = connect(cc_socket, (SOCKADDR *)&serveraddr, sizeof(serveraddr));
	// ��� ����(�����ϸ� �ڵ����� ������Ʈ, �����ּҸ� �Ҵ�)
	if (retval == SOCKET_ERROR)
	{
		MessageBox(0, TEXT("���� �������\n���α׷��� �����մϴ�"),
			TEXT("�˸�"), MB_OK);
		exit(0);
	}

	printf("���� ���� ����\n");
	unsigned int hthread = _beginthreadex(0, 0, CRecvThread, 0, 0, 0);
	CloseHandle((HANDLE)hthread);
}

int sockc_Send(char *buf, int length)
{
	// ������ ������ ������
	//1. ���(�� ������ ũ��)
	int size = length;
	int retval = send(cc_socket, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("���� ���� : ������ �׾�����\n");
		return 0;
	}

	//2. ��������
	retval = send(cc_socket, buf, size, 0);
	if (retval == SOCKET_ERROR)
	{
		printf("���� ���� : ������ �׾�����\n");
		return 0;
	}
	printf("%d����Ʈ�� ����, %s\n", retval, buf);
	return retval;
}

unsigned int __stdcall CRecvThread(void * value)
{
	char buf[1024];

	while (true)
	{
		if (CRecv(cc_socket, buf) == 0)
			break;
		//=== ���� ���� ���� ��ġ =============================
		//������ ó���� control���� ����...
		con_RecvData(buf);	//<=======================================
	}

	closesocket(cc_socket);

	return 0;
}

int CRecv(SOCKET sock, char* buf)
{
	int retval;

	//1. ���
	int size;
	retval = crecvn(sock, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("����  ����\n");
		return 0;
	}

	//2. ��������
	retval = crecvn(sock, buf, size, 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("����  ����\n");
		return 0;
	}
	else
	{
		//		buf[retval] = '\0';
		//		printf("[���ŵ�����] %s\n", buf);
		//==================================================================
		return 1;
	}
}

int crecvn(SOCKET s, char *buf, int len, int flags)
{
	int received;
	char *ptr = buf;
	int left = len;
	while (left > 0) {
		received = recv(s, ptr, left, flags);
		if (received == SOCKET_ERROR)
			return SOCKET_ERROR;
		else if (received == 0)
			break;
		left -= received;
		ptr += received;
	}
	return (len - left);
}

