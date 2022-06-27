//control.h
#pragma once

void con_init();
void con_run();
void con_exit();

//wbserver에서 데이터가 수신되면 수신된 데이터의 주소값을 전달 
void con_RecvData(char* buf, int *size);

//전달된 데이터를 분석한 후 맴버등록 패킷을 처리하는 함수
void RecvTextMessage(COPYPASTMSG *pmsg);
void RecvShortMessage(SHORTMSG *pmsg);