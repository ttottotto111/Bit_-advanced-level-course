//control.h
#pragma once

void con_init();
void con_run();
void con_exit();

//wbserver���� �����Ͱ� ���ŵǸ� ���ŵ� �������� �ּҰ��� ���� 
void con_RecvData(char* buf, int *size);

void RecvInsertAccount(PACK_ACCOUNTINFO* accinfo);
void RecvSelectNameToId(PACK_GETNAME* accdata);

void RecvSelectAccount(PACK_ACCOUNTINFO* accinfo);