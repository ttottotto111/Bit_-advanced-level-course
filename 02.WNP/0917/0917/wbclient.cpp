//wbclient.cpp

#include "std.h"

#define SERVER_IP		"61.81.98.100" //(�ڽ��� IP)127.0.0.1   (IT����) 61.81.98.100
#define SERVER_PORT		9000

SOCKET c_socket;

void sock_LibInit()
{
	WSADATA wsa;
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("������ ���� �ʱ�ȭ ����!\n");
		exit(0);	//���α׷� ����
	}
}

void sock_LibExit()
{
	WSACleanup();
}

void sock_CreateSocket()
{
	//1. ���� ���� 
	c_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (c_socket == INVALID_SOCKET)
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
	int retval = connect(c_socket, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	// ��� ����(�����ϸ� �ڵ����� ������Ʈ, �����ּҸ� �Ҵ�)
	if (retval == SOCKET_ERROR)
	{
		MessageBox(0, TEXT("���� �������\n���α׷��� �����մϴ�"),
			TEXT("�˸�"), MB_OK);
		exit(0);
	}

	printf("���� ���� ����\n");
	unsigned int hthread = _beginthreadex(0, 0, RecvThread, 0, 0, 0);
	CloseHandle((HANDLE)hthread);
}

int sock_Send(char* buf, int length)
{
	// ������ ������ ������
	//1. ���(�� ������ ũ��)
	int size = length;
	int retval = send(c_socket, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("���� ���� : ������ �׾�����\n");
		return 0;
	}

	//2. ��������
	retval = send(c_socket, buf, size, 0);
	if (retval == SOCKET_ERROR)
	{
		printf("���� ���� : ������ �׾�����\n");
		return 0;
	}
	printf("%d����Ʈ�� ����, %s\n", retval, buf);
	return retval;
}

int Recv(SOCKET sock, char* buf)
{
	int retval;

	//1. ���
	int size;
	retval = recvn(sock, (char*)&size, sizeof(int), 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("����  ����\n");
		return 0;
	}

	//2. ��������
	retval = recvn(sock, buf, size, 0);
	if (retval == SOCKET_ERROR || retval == 0)
	{
		printf("����  ����\n");
		return 0;
	}
	else
	{
		//buf[retval] = '\0';
		//printf("[���ŵ�����] %s\n", buf);
		//==================================================================
		return 1;
	}
}

int recvn(SOCKET s, char* buf, int len, int flags)
{
	int received;
	char* ptr = buf;
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

unsigned int __stdcall RecvThread(void* value)
{
	char buf[1024];

	while (true)
	{
		if (Recv(c_socket, buf) == 0)
			break;

		//���ż��� ������ġ
		con_RecvData(buf);
	}

	closesocket(c_socket);

	return 0;
}