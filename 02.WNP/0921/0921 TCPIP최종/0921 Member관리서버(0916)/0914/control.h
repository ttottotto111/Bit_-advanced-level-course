//control.h
#pragma once

void con_init();
void con_run();
void con_exit();

//wbserver���� �����Ͱ� ���ŵǸ� ���ŵ� �������� �ּҰ��� ���� 
void con_RecvData(char* buf, int *size);

//���޵� �����͸� �м��� �� �ɹ���� ��Ŷ�� ó���ϴ� �Լ�
void RecvNewMember(MEMBER *pmem);
void RecvLogin(LOGIN* plogin);
void RecvLogOut(LOGIN* plogout);

void PrintMemberList();