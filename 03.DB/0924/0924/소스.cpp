//�ҽ�.cpp

#include <windows.h>
#include <stdio.h>
#include <tchar.h>

#include "wb_db.h"

void init()
{
	printf("SQL*Plus: Release 11.2.0.1.0 Production on �� 9�� 24 08 : 26 : 13 2020\n");
	printf("\nCopyright(c) 1982, 2010, Oracle.All rights reserved.\n\n");

	//DB���� ó�� �ڵ� 
	TCHAR id[20], pw[20];
	while (true)
	{
		printf("����ڸ� �Է� : ");		gets_s(id, sizeof(id));
		printf("��й�ȣ �Է� : ");		gets_s(pw, sizeof(pw));

		//DB ���� ��û 
		if (wb_DBConnect(id, pw) == FALSE)
			printf("���� ���� �Դϴ�\n\n");
		else
			break;
	}
}

void run()
{
	//���� �� �α� 
	printf("\n������ ���ӵ� :\n");
	printf("Oracle Database 11g Enterprise Edition Release 11.2.0.1.0 - Production\n");
	printf("With the Partitioning, OLAP, Data Mining and Real Application Testing options\n");

	TCHAR msg[256];		//������ ��ü
	TCHAR flag[256];	//������ ù ����(Ű����)
	while (true)
	{
		printf("SQL> ");		gets_s(msg, sizeof(msg));
		//================= ��ū �и�================================
		// �ܹ��� : DDL��(create, drop...) DML(insert, update, delete)
		//--------------------------------------------------------------
		// ����� : DML-DQL(select)
		//----------------------------------------------------------
		//�Էµ� 0��° ���ں��� ���鹮�� ������ ȹ��... � ��ɾ����� �и�		
		TCHAR* next_token1 = NULL;
		_tcscpy_s(flag, sizeof(flag), msg);
		strtok_s(flag, " ", &next_token1);
		//===========================================================
		if (_tcscmp(msg, TEXT("exit")) == 0)
		{
			break;
		}
		else if (_tcscmp(flag, TEXT("select")) == 0)
		{
			wb_DBSendSelectData(msg);
		}
		else
		{
			wb_DBSendOtherData(msg);
		}
	}
}

void exit()
{
	//DB���� ����
	wb_DBDisConnect();

	printf("\nOracle Database 11g Enterprise Edition Release 11.2.0.1.0 - Production\n");
	printf("With the Partitioning, OLAP, Data Mining and Real Application Testing options���� �и��Ǿ����ϴ�.\n\n");
}

int main()
{
	init();
	run();
	exit();

	return 0;
}