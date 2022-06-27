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
BOOL wb_dbInsertAccount(ACCOUNT* pacc)
{
	//�����Ǵ� ������ ID ȹ��
	TCHAR sql1[256];
	wsprintf(sql1, TEXT("SELECT LAST_NUMBER FROM USER_SEQUENCES where SEQUENCE_NAME = 'ACCID_SEQ'"));
	int id;
	SQLINTEGER lid;

	SQLBindCol(hStmt, 1, SQL_C_ULONG, &id, 0, &lid);

	if (SQLExecDirect(hStmt, (SQLTCHAR*)sql1, SQL_NTS) != SQL_SUCCESS)
		return -1;

	SQLFetch(hStmt);
	pacc->id = id;	//������ ID�� ����
	SQLFetch(hStmt);

	//���� ���� ������
	TCHAR sql[256];
	wsprintf(sql, TEXT("insert into account values(accid_seq.nextval,'%s' ,%d, sysdate)"),
		pacc->name, pacc->balance);
	if (SQLExecDirect(hStmt, (SQLTCHAR*)sql, SQL_NTS) != SQL_SUCCESS)
		return FALSE;
	else
		return TRUE;
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

//select accid from account where name = 'ȫ�浿';
BOOL wb_dbSelectNameToId(PACK_GETNAME* pdata)
{
	int id;
	SQLINTEGER lid;

	SQLBindCol(hStmt, 1, SQL_C_ULONG, &id, 0, &lid);

	TCHAR sql[256];
	wsprintf(sql, TEXT("select accid from  account where name = '%s'"),
		pdata->name);


	if (SQLExecDirect(hStmt, (SQLTCHAR*)sql, SQL_NTS) != SQL_SUCCESS)
	{
		return FALSE;
	}

	int i;
	for (int i = 0; SQLFetch(hStmt) != SQL_NO_DATA; i++)
	{
		pdata->id[i] = id;
	}
	pdata->count = i;

	return TRUE;
}

//select accid from account where accid = 1000;
BOOL wb_dbSelectAccount(PACK_ACCOUNTINFO* pacc)
{
	SQLTCHAR Name[20];
	int accid, balance;
	SQL_DATE_STRUCT NewDate;

	SQLINTEGER lName, lNewDate, laccid, lbalance;

	SQLBindCol(hStmt, 1, SQL_C_CHAR, &accid, 0, &laccid);
	SQLBindCol(hStmt, 3, SQL_C_CHAR, Name, sizeof(Name), &lName);
	SQLBindCol(hStmt, 2, SQL_C_ULONG, &balance, 0, &lbalance);
	SQLBindCol(hStmt, 4, SQL_C_TYPE_DATE, &NewDate, 0, &lNewDate);

	TCHAR sql[256];
	wsprintf(sql, TEXT("select * from account where accid = %d"),
		pacc->id);


	if (SQLExecDirect(hStmt, (SQLTCHAR*)sql, SQL_NTS) != SQL_SUCCESS)
	{
		return FALSE;
	}

	SQLFetch(hStmt);
	_tcscpy_s(pacc->name, _countof(pacc->name), Name);
	pacc->balance = balance;
	pacc->stime.wYear = NewDate.year;
	pacc->stime.wMonth = NewDate.month;
	pacc->stime.wDay = NewDate.day;

	SQLCloseCursor(hStmt);

	return TRUE;
}

