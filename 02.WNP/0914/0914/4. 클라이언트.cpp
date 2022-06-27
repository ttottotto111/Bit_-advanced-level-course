//Client
#include <stdio.h>
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>

#define SERVER_IP		"127.0.0.1" //(�ڽ��� IP)   (IT����) 61.81.98.100
#define SERVER_PORT		9000

void sock_LibInit();
void sock_LibExit();
void sock_CreateSocket();
void sock_Run();
int sock_Send(SOCKET sock, char* buf);
int sock_Recv(SOCKET sock, char* buf);

int fun_Input(char* buf);

SOCKET c_socket;

int main()
{
	sock_LibInit();

	//1. ���� ���� �� ���� 
	sock_CreateSocket();

	//2. ��� 
	sock_Run();

	sock_LibExit();
	return 0;
}

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
		printf("���� �������\n");
		exit(0);
	}

	printf("���� ���� ����\n");
}

void sock_Run()
{
	char buf[1024];
	while (true)
	{
		if (fun_Input(buf) == 0)
			break;

		if (sock_Send(c_socket, buf) == 0)
			break;

		sock_Recv(c_socket, buf);
		printf("\n\n");
	}

	closesocket(c_socket);
}

int fun_Input(char* buf)
{
	ZeroMemory(buf, 1024);
	printf("[���ڿ� �Է�] ");
	gets_s(buf, 1024);
	if (strlen(buf) == 0)		//���� ����
		return 0;
	else
		return 1;
}

int sock_Send(SOCKET sock, char* buf)
{
	// ������ ������ ������
	int retval = send(c_socket, buf, strlen(buf), 0);
	if (retval == SOCKET_ERROR)
	{
		printf("���� ���� : ������ �׾�����\n");
		return 0;
	}
	printf("%d����Ʈ�� ����, %s\n", retval, buf);
	return retval;
}

int sock_Recv(SOCKET sock, char* buf)
{
	int retval;
	int buf_size = 1024;

	retval = recv(sock, buf, buf_size, 0);
	if (retval == SOCKET_ERROR) // -1
	{
		printf("���� ������ ����-������ ���α׷��� ������ �������� ���\n");
		return 0;
	}
	else if (retval == 0)
	{
		printf("���� ���� ����-������ closesocket�Լ��� ȣ������ ���");
		return 0;
	}
	else
	{
		buf[retval] = '\0';
		printf("[���ŵ�����] %s\n", buf);
		//==================================================================
		return 1;
	}
}