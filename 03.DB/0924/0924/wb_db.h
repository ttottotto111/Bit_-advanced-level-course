//wb_db.h

#pragma once

//DB ���� �� ���� ����
BOOL wb_DBConnect(TCHAR* id, TCHAR* pw);
void wb_DBDisConnect();

//������ ����
void wb_DBSendOtherData(TCHAR* msg);
void wb_DBSendSelectData(TCHAR* msg);