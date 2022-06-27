//wbserver.h
#pragma once

void sock_LibInit();
void sock_LibExit();

void sock_CreateSocket();

unsigned int __stdcall sock_ListenThread(void * value);
unsigned int __stdcall WorkThread(void * value);

int Recv(SOCKET sock, SOCKADDR_IN clientaddr, char* buf);
int Send(SOCKET sock, const char* buf, int datasize);
int recvn(SOCKET s, char *buf, int len, int flags);

SOCKET Accept(SOCKADDR_IN *addr);
void DisplayMessage();


