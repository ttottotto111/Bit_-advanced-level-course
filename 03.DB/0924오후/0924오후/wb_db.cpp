//wb_db.cpp

#include "std.h"

#define DBNAME	TEXT("wb32")

SQLHENV hEnv;		//ȯ�� �ڵ�
SQLHDBC hDbc;		//����Ŭ�� ������ �ڵ�
SQLHSTMT hStmt;		//����Ŭ�� �������� ���� �� �ִ� ��� �ڵ�


BOOL wb_DBConnect(TCHAR* ID, TCHAR* PW)
{

	// ���� ������ ���� ������
	SQLRETURN Ret;

	// 1, ȯ�� �ڵ��� �Ҵ��ϰ� ���� �Ӽ��� �����Ѵ�.(p1741)
	if (SQLAllocHandle(SQL_HANDLE_ENV, SQL_NULL_HANDLE, &hEnv) != SQL_SUCCESS)
		return false;
	if (SQLSetEnvAttr(hEnv, SQL_ATTR_ODBC_VERSION, (SQLPOINTER)SQL_OV_ODBC3, SQL_IS_INTEGER) != SQL_SUCCESS)
		return false;

	// 2. ���� �ڵ��� �Ҵ��ϰ� �����Ѵ�.
	if (SQLAllocHandle(SQL_HANDLE_DBC, hEnv, &hDbc) != SQL_SUCCESS)
		return false;
	// ����Ŭ ������ �����ϱ�
	Ret = SQLConnect(hDbc, (SQLTCHAR*)DBNAME, SQL_NTS, (SQLTCHAR*)ID, SQL_NTS, (SQLTCHAR*)PW, SQL_NTS);

	if ((Ret != SQL_SUCCESS) && (Ret != SQL_SUCCESS_WITH_INFO))
		return false;

	// ��� �ڵ��� �Ҵ��Ѵ�.
	if (SQLAllocHandle(SQL_HANDLE_STMT, hDbc, &hStmt) != SQL_SUCCESS)
		return false;

	return true;
}

void wb_DBDisConnect()
{
	// ������
	if (hStmt) SQLFreeHandle(SQL_HANDLE_STMT, hStmt);
	if (hDbc) SQLDisconnect(hDbc);
	if (hDbc) SQLFreeHandle(SQL_HANDLE_DBC, hDbc);
	if (hEnv) SQLFreeHandle(SQL_HANDLE_ENV, hEnv);
}

//insert into account values(accid_seq.nextval, '�̱浿', 10000, sysdate);
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

//select accid from account where name = '�̱浿';
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
