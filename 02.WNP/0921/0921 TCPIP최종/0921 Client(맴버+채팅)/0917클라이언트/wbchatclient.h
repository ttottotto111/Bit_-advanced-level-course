//wbchatchilent.h
/*
1. Ŭ���̾�Ʈ�� �α����� �����ϸ� Chat ������ ����
-> ����? control �Լ�
-> ������ ȣ���ұ�? wbchatclient�Լ� :sockc_CreateSocket

2. Ŭ���̾�Ʈ�� �α׾ƿ��ϸ� Chat ���� ���� ����

3. short�޽��� ����  -----------------> ��Ƽ���θ޽��� ����
-> ����   : ���۹�ư Ŭ��
-> ������ : sockc_Send()

4. short�޽��� ����		--------------> ��Ƽ���μ���
-> ��� : 
*/

#pragma once

void sockc_Close();
void sockc_CreateSocket();	// RcvThread ȣ�� 
int sockc_Send(char *buf, int length);

unsigned int __stdcall CRecvThread(void * value);	//sock_RecvThread
int CRecv(SOCKET sock, char* buf);		//sock_Recv
int crecvn(SOCKET s, char *buf, int len, int flags);
