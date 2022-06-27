//���� ���� �Լ�
#include <stdio.h>
#include <WinSock2.h>	
#pragma comment(lib, "ws2_32.lib")  
#include <ws2tcpip.h>

#define SERVER_PORT		9000

void sock_LibInit();
void sock_LibExit();
void sock_CreateSocket();
void sock_Run();

SOCKET listen_socket = 0;

int main()
{
	sock_LibInit();

	//1. ���� ����, �ּҼ���, ����
	sock_CreateSocket();

	//2. ����ó�� �� ��� 
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
	listen_socket = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	if (listen_socket == INVALID_SOCKET)
	{
		printf("���� ���� ����\n");
		exit(0);
	}

	//2. �ּ� ����
	int retval;

	SOCKADDR_IN serveraddr;
	ZeroMemory(&serveraddr, sizeof(serveraddr)); //1��°������ �ּҺ��� 2��° ����ũ��
												// ��� ����Ʈ�� 0���� �ʱ�ȭ

	serveraddr.sin_family = AF_INET;				//�ּ�ü��
	serveraddr.sin_port = htons(SERVER_PORT);	//������Ʈ��ȣ
	serveraddr.sin_addr.s_addr = htonl(INADDR_ANY);	//����IP �ּ�

	retval = bind(listen_socket, (SOCKADDR*)&serveraddr, sizeof(serveraddr));
	if (retval == SOCKET_ERROR)
	{
		printf("�ּҰ� ����\n");
		exit(0);
	}


	//3. ����
	//���Ӵ�� ť�� ũ�� : TCP ���¸� LISTENING ����
	retval = listen(listen_socket, SOMAXCONN);
	// 
	if (retval == SOCKET_ERROR)
	{
		printf("���� ����\n");
		exit(0);
	}
}

void sock_Run()
{
	SOCKADDR_IN clientaddr;
	int addrlen = sizeof(clientaddr);		//�ݵ�� �ʱ�ȭ... 

	//1. ���� ó�� 
	printf("���� ���� ���̴�(61.81.98.100:9000).....\n");
	SOCKET sock = accept(listen_socket, (SOCKADDR*)&clientaddr, &addrlen);
	if (sock == SOCKET_ERROR)
	{
		printf("Ŭ���̾�Ʈ ���� ó�� ����\n");
		exit(0);
	}

	//2. ���� ��� ���
	//inset_ntoa : ���� -> ���ڿ��� ��ȯ(��Ʈ�p����Ʈ����->ȣ��Ʈ����Ʈ����)
	char buf[10];
	inet_ntop(AF_INET, &clientaddr.sin_addr, buf, sizeof(buf));

	printf("===================================================================\n");
	//	printf("Ŭ���̾�Ʈ ����: %s:%d\n",
	//		inet_ntoa(clientaddr.sin_addr), ntohs(clientaddr.sin_port));
	printf("Ŭ���̾�Ʈ ����: %s:%d\n", buf, ntohs(clientaddr.sin_port));
	printf("===================================================================\n");

	//3. ��ȭ(recv)
	int retval;
	char recv_buf[1024];
	int  buf_size = sizeof(recv_buf);
	while (true)
	{
		// ������ �ޱ�
		retval = recv(sock, recv_buf, buf_size, 0);
		if (retval == SOCKET_ERROR)
		{
			printf("���� ������ ����-������ ���α׷��� ������ �������� ���\n");
			break;
		}
		else if (retval == 0)
		{
			printf("���� ���� ����-������ closesocket�Լ��� ȣ������ ���");
			break;
		}
		else
		{
			// ���� ������ ���
			char buf1[10];
			inet_ntop(AF_INET, &clientaddr.sin_addr, buf1, sizeof(buf1));

			recv_buf[retval] = '\0';
			printf("[TCP ����] IP �ּ�=%s, ��Ʈ ��ȣ=%d�� ���� �޽���:%s\n",
				buf1, ntohs(clientaddr.sin_port), recv_buf);
		}

		closesocket(sock);				//��ż���
		closesocket(listen_socket);		//��������
	}
}