//wb_db.h
#pragma once

//DB 연결 및 연결 해제
BOOL wb_DBConnect(TCHAR* id, TCHAR* pw);
void wb_DBDisConnect();

BOOL wb_dbInsertAccount(ACCOUNT* pacc);

int GetAccid(TCHAR* name);

BOOL wb_dbSelectNameToId(PACK_GETNAME* pdata);
BOOL wb_dbSelectAccount(PACK_ACCOUNTINFO* pacc);