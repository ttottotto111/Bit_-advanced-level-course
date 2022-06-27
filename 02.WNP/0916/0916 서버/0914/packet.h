//packet.h

#pragma once


//Ŭ���̾�Ʈ -> ����
#define	 PACK_NEWMEMBER		1
#define  PACK_LOGIN			2
#define  PACK_LOGOUT		3

//���� -> Ŭ���̾�Ʈ
#define  ACK_NEWMEMBER_S	11		
#define  ACK_NEWMEMBER_F	12
#define  ACK_LOGIN_S		13
#define  ACK_LOGIN_F		14

/*
��� ��Ŷ ����ü�� ù��° �ɹ��� 4byte�� flag�̴�.
*/
//ȸ������ ��Ŷ ����ü
typedef struct tagMEMBER
{
	int  flag;
	char id[20];
	char pw[20];
	char name[20];
	int  age;
}MEMBER;

//�α��� ��Ŷ ����ü 
typedef struct tagLOGIN
{
	int  flag;
	char id[20];
	char pw_name[20];	//pw ����
	int  age;
}LOGIN;
