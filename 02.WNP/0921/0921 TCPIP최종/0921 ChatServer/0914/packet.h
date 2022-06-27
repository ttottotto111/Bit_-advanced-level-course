//packet.h

#pragma once


//Ŭ���̾�Ʈ -> ����
#define	 PACK_TEXTMESSAGE	31
#define  PACK_SHORTMESSAGE  32

//���� -> Ŭ���̾�Ʈ
#define  ACK_TEXTMESSAGE	41		
#define  ACK_SHORTMESSAGE	42

/*
��� ��Ŷ ����ü�� ù��° �ɹ��� 4byte�� flag�̴�.
*/
//copy & past ��Ŷ ����ü
typedef struct tagCOPYPASTMSG
{
	int  flag;
	char id[20];
	char name[20];
	char msg[800];
	SYSTEMTIME dt;
}COPYPASTMSG;

//short ��Ŷ ����ü 
typedef struct tagSHORTMSG
{
	int  flag;
	char id[20];
	char name[20];
	char msg[100];
	SYSTEMTIME dt;
}SHORTMSG;
