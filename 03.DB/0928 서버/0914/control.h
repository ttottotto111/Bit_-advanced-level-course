//control.h
#pragma once

void con_init();
void con_run();
void con_exit();

//wbserver에서 데이터가 수신되면 수신된 데이터의 주소값을 전달 
void con_RecvData(char* buf, int *size);

void RecvInsertAccount(PACK_ACCOUNTINFO* accinfo);
void RecvSelectNameToId(PACK_GETNAME* accdata);

void RecvSelectAccount(PACK_ACCOUNTINFO* accinfo);