//fun.cpp

#include <Windows.h>
#include <commctrl.h>		
#include "resource.h"
#include "fun.h"
#include "account.h"
#include <vector>
using namespace std;

extern vector<ACCOUNT> acclist;	//참조 선언 

HWND hinputname, hinputid, hinputbalance;
HWND hidlistbox, hupdatecombo;

void fun_GetControlHandle(HWND hDlg)
{
	hinputid		= GetDlgItem(hDlg, IDC_EDIT1);
	hinputname		= GetDlgItem(hDlg, IDC_EDIT2);
	hinputbalance	= GetDlgItem(hDlg, IDC_EDIT3);	
	hidlistbox		= GetDlgItem(hDlg, IDC_LIST1);
	hupdatecombo	= GetDlgItem(hDlg, IDC_COMBO1);

	//콤보박스 초기화
	SendMessage(hupdatecombo, CB_ADDSTRING, 0, (LPARAM)TEXT("입금"));
	SendMessage(hupdatecombo, CB_ADDSTRING, 0, (LPARAM)TEXT("출금"));

	SendMessage(hupdatecombo, CB_SETCURSEL, 0, 0);
}

void fun_Insert(HWND hDlg)
{
	//---------------- 저장 ---------------------------------------------
	ACCOUNT acc;

	acc.id = GetDlgItemInt(hDlg, IDC_EDIT1, 0, 0);
	GetDlgItemText(hDlg, IDC_EDIT2, acc.name, sizeof(acc.name));
	acc.balance = GetDlgItemInt(hDlg, IDC_EDIT3, 0, 0);

	acclist.push_back(acc);

	//저장개수 출력 ------------------------------------------------------
	TCHAR buf[100];
	wsprintf(buf, TEXT("저장개수:%d개"), acclist.size());
	SetDlgItemText(hDlg, IDC_STATIC1, buf);

	//리스트박스에 ID만 출력  -----------------------------------------------
	//리스트박스 전체 삭제
	for (int i = 0; i < (int)acclist.size()-1; i++)
	{
		SendMessage(hidlistbox, LB_DELETESTRING, (WPARAM)0, 0);
	}

	//리스트박스에 전체 추가 
	for (int i = 0; i < (int)acclist.size(); i++)
	{
		ACCOUNT acc = acclist[i];
		TCHAR buf[10];
		wsprintf(buf, TEXT("%d"), acc.id);

		SendMessage(hidlistbox, LB_ADDSTRING, 0, (LPARAM)buf);
	}
}

void fun_ListSelect(HWND hDlg, WPARAM wParam)
{
	switch (HIWORD(wParam))
	{
		case LBN_SELCHANGE:
		{
			TCHAR str[50];
			int i = SendMessage(hidlistbox, LB_GETCURSEL, 0, 0);
			SendMessage(hidlistbox, LB_GETTEXT, i, (LPARAM)str);
			
			//str에 저장된 문자열(id)을 숫자로 변환해서 검색
			int id = _ttoi(str);

			for (int i = 0; i < (int)acclist.size(); i++)
			{
				ACCOUNT acc = acclist[i];
				if (acc.id == id)
				{
					SetDlgItemInt(hDlg, IDC_EDIT4, acc.id, 0);
					SetDlgItemText(hDlg, IDC_EDIT5, acc.name);
					SetDlgItemInt(hDlg, IDC_EDIT6, acc.balance, 0);
					break;
				}
			}
			break;
		}
	}
}

void fun_Update(HWND hDlg)
{
	//input  0 :입금 , 1 : 출금
	int input = SendMessage(hupdatecombo, CB_GETCURSEL, 0, 0);
	int money = GetDlgItemInt(hDlg, IDC_EDIT7, 0, 0);
	int id = GetDlgItemInt(hDlg, IDC_EDIT4, 0, 0);

	for (int i = 0; i < (int)acclist.size(); i++)
	{
		if (acclist[i].id == id)
		{
			if (input == 0)		//입금
				acclist[i].balance = acclist[i].balance + money;
			else				//출금
				acclist[i].balance = acclist[i].balance - money;
	
			//--- 화면에 출력된 에디트 수정
			SetDlgItemInt(hDlg, IDC_EDIT6, acclist[i].balance, 0);

			break;
		}
	}
}

void fun_Delete(HWND hDlg)
{
	//데이터 삭제 : acclist
	//UI도 삭제   : listbox

	int id = GetDlgItemInt(hDlg, IDC_EDIT4, 0, 0);

	for (int i = 0; i < (int)acclist.size(); i++)
	{
		ACCOUNT acc = acclist[i];
		if (acc.id == id)
		{
			// 벡터에 저장된 첫번째 데이터 위치값 획득 
			vector<ACCOUNT>::iterator itr = acclist.begin();

			//erase : 삭제 함수 - 인자로 삭제할 위치를 전달.
			acclist.erase(itr + i);

			//저장개수 출력 ------------------------------------------------------
			TCHAR buf[100];
			wsprintf(buf, TEXT("저장개수:%d개"), acclist.size());
			SetDlgItemText(hDlg, IDC_STATIC1, buf);

			//리스트박스 전체 삭제
			for (int i = 0; i < (int)acclist.size()+1 ; i++)
			{
				SendMessage(hidlistbox, LB_DELETESTRING, (WPARAM)0, 0);
			}

			//리스트박스에 전체 추가 
			for (int i = 0; i < (int)acclist.size(); i++)
			{
				ACCOUNT acc = acclist[i];
				TCHAR buf[10];
				wsprintf(buf, TEXT("%d"), acc.id);

				SendMessage(hidlistbox, LB_ADDSTRING, 0, (LPARAM)buf);
			}


			break;
		}
	}

}