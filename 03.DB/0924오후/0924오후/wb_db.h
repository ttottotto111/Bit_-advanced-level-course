//wb_db.h
#pragma once

//DB 연결 및 연결 해제
BOOL wb_DBConnect(TCHAR* id, TCHAR* pw);
void wb_DBDisConnect();

int wb_InsertAccout(TCHAR* name, int money);

int GetAccid(TCHAR* name);