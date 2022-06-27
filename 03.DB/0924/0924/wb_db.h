//wb_db.h

#pragma once

//DB 연결 및 연결 해제
BOOL wb_DBConnect(TCHAR* id, TCHAR* pw);
void wb_DBDisConnect();

//쿼리문 전송
void wb_DBSendOtherData(TCHAR* msg);
void wb_DBSendSelectData(TCHAR* msg);