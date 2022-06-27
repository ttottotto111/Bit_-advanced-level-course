//wb_db.cpp

#include <Windows.h>
#include <stdio.h>
#include <sql.h>
#include <sqlext.h>
#include "wb_db.h"

#define DBNAME	TEXT("wb32")
//#define ID		TEXT("ccmid")
//#define PW		TEXT("ccmpw")

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
	Ret = SQLConnect(hDbc, (SQLCHAR*)DBNAME, SQL_NTS, (SQLCHAR*)ID, SQL_NTS, (SQLCHAR*)PW, SQL_NTS);

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

void wb_DBSendOtherData(TCHAR* msg)
{
	if (SQLExecDirect(hStmt, (SQLCHAR*)msg, SQL_NTS) != SQL_SUCCESS)
	{
		printf("쿼리문 실패\n");
		return;
	}
	printf("쿼리문 성공\n");
}

void wb_DBSendSelectData(TCHAR* msg)  //select * from subject;
{
	int id;
	SQLCHAR Name[50], Build[50];

	SQLINTEGER lid, lname, lbuild;

	SQLBindCol(hStmt, 1, SQL_C_ULONG, &id, 0, &lid);
	SQLBindCol(hStmt, 2, SQL_C_CHAR, Name, sizeof(Name), &lname);
	SQLBindCol(hStmt, 3, SQL_C_CHAR, Build, sizeof(Build), &lbuild);

	if (SQLExecDirect(hStmt, (SQLCHAR*)msg, SQL_NTS) != SQL_SUCCESS)
	{
		printf("\n쿼리문 실패\n\n");
		return;
	}

	//리턴 값을 처리....
//	int d_id;
//	TCHAR d_name[20], d_build[20];

	while (SQLFetch(hStmt) != SQL_NO_DATA)
	{
		printf("%d\t", id);
		printf("%s\t", Name);
		printf("%s\n", Build);
	}
}
