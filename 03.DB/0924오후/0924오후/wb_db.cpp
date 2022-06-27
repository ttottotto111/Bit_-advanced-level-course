//wb_db.cpp

#include "std.h"

#define DBNAME	TEXT("wb32")

SQLHENV hEnv;		//환경 핸들
SQLHDBC hDbc;		//오라클에 접속할 핸들
SQLHSTMT hStmt;		//오라클에 쿼리문을 보낼 수 있는 명령 핸들


BOOL wb_DBConnect(TCHAR* ID, TCHAR* PW)
{

	// 연결 설정을 위한 변수들
	SQLRETURN Ret;

	// 1, 환경 핸들을 할당하고 버전 속성을 설정한다.(p1741)
	if (SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &hEnv) != SQL_SUCCESS)
		return false;
	if (SQLSetEnvAttr(hEnv, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, SQL_IS_INTEGER) != SQL_SUCCESS)
		return false;

	// 2. 연결 핸들을 할당하고 연결한다.
	if (SQLAllocHandle(SQL_HANDLE_DBC, hEnv, &hDbc) != SQL_SUCCESS)
		return false;
	// 오라클 서버에 연결하기
	Ret = SQLConnect(hDbc, (SQLTCHAR*)DBNAME, SQL_NTS, (SQLTCHAR*)ID, SQL_NTS, (SQLTCHAR*)PW, SQL_NTS);

	if ((Ret != SQL_SUCCESS) && (Ret != SQL_SUCCESS_WITH_INFO))
		return false;

	// 명령 핸들을 할당한다.
	if (SQLAllocHandle(SQL_HANDLE_STMT, hDbc, &hStmt) != SQL_SUCCESS)
		return false;

	return true;
}

void wb_DBDisConnect()
{
	// 뒷정리
	if (hStmt) SQLFreeHandle(SQL_HANDLE_STMT, hStmt);
	if (hDbc) SQLDisconnect(hDbc);
	if (hDbc) SQLFreeHandle(SQL_HANDLE_DBC, hDbc);
	if (hEnv) SQLFreeHandle(SQL_HANDLE_ENV, hEnv);
}

//insert into account values(accid_seq.nextval, '이길동', 10000, sysdate);
int wb_InsertAccout(TCHAR* name, int money)
{
	TCHAR sql[256];
	wsprintf(sql, TEXT("insert into account values(accid_seq.nextval,'%s' ,%d, sysdate)"),
		name, money);
	if (SQLExecDirect(hStmt, (SQLTCHAR*)sql, SQL_NTS) != SQL_SUCCESS)
		return 0;
	else
	{
		return GetAccid(name);
	}
}

//select accid from account where name = '이길동';
int GetAccid(TCHAR* name)
{
	TCHAR sql[256];
	wsprintf(sql, TEXT("select accid from account where name = '%s'"), name);

	int id;
	SQLINTEGER lid;

	SQLBindCol(hStmt, 1, SQL_C_ULONG, &id, 0, &lid);

	if (SQLExecDirect(hStmt, (SQLTCHAR*)sql, SQL_NTS) != SQL_SUCCESS)
		return -1;

	SQLFetch(hStmt);
	return id;
}
