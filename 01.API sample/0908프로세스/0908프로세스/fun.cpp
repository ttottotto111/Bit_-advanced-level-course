//fun.cpp

#include <Windows.h>
#include "fun.h"
#include "resource.h"
#include <vector>
using namespace std;
#include "myprocess.h"
#include <CommCtrl.h>

vector<MYPROCESS> plist;

//프로그램 실행 -> 프로세스 생성 
//WinExec 함수는 내부적으로 CreateProcess 함수를 호출...
void fun_WinExec(HWND hDlg)
{
	WinExec("notepad.exe", SW_SHOW);	//calc.exe
}

void fun_CreateProcess(HWND hDlg)
{
//	TCHAR name[] = TEXT("calc.exe");
	TCHAR name[20];
	GetDlgItemText(hDlg, IDC_EDIT1, name, sizeof(name));

	PROCESS_INFORMATION pi;
	STARTUPINFO si = { sizeof(si) };

	BOOL b = CreateProcess(0, name,	//보통 2번째 인자로 생성할 프로세스명을 넣는다.
		0, 0,						//보안속성(커널오브젝트는 모두 인자로 전달)
		0,							//자신의 커널오브젝트핸들테이블에 저장된
									//핸들값을 자식프로세스에 전달할 것인가?
		NORMAL_PRIORITY_CLASS,		//우선순위:보통 NORMAL로(6단계가 있다.)
		0, 0,						//옵션
		&si, &pi);					//pi :  Pid, Tid, PHandle, Thandle

	//벡터에 저장하고, ListBox 출력함수를 호출
	MYPROCESS myp;
	_tcscpy_s(myp.name, _countof(myp.name), name);
	myp.phandle = pi.hProcess;
	myp.pid = pi.dwProcessId;

	plist.push_back(myp);

	fun_ListBoxPrint(hDlg);
}

void fun_ListBoxPrint(HWND hDlg)
{
	HWND hList = GetDlgItem(hDlg, IDC_LIST1);

	//전체 삭제
	for (int i = 0; i < (int)plist.size() + 1; i++)
	{
		SendMessage(hList, LB_DELETESTRING, (WPARAM)0, 0);
	}

	for (int i = 0; i < (int)plist.size(); i++)
	{
		MYPROCESS myp = plist[i];
		TCHAR buf[10];
		wsprintf(buf, TEXT("%d"), myp.pid);
		SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)buf);
	}
}

void fun_List(HWND hDlg, WPARAM wParam)
{
	HWND hList = GetDlgItem(hDlg, IDC_LIST1);

	switch (HIWORD(wParam))
	{
		case LBN_SELCHANGE:
		{
			TCHAR buf[20];	//pid가 문자열 형태로 저장 
			int i = SendMessage(hList, LB_GETCURSEL, 0, 0);			
			SendMessage(hList, LB_GETTEXT, i, (LPARAM)buf);

			SetDlgItemText(hDlg, IDC_EDIT2, buf);

			fun_ProcessInfoPrint(hDlg, _ttoi(buf));	//<=======문자열->숫자
			break;
		}
	}
}

void fun_ProcessInfoPrint(HWND hDlg, int pid)
{
	//벡터 이름으로 검색 -> 해당 프로세스정보 획득 -> 컨트롤 출력 
	for (int i = 0; i < (int)plist.size(); i++)
	{
		MYPROCESS myp = plist[i];

		if ( myp.pid == pid)
		{
			SetDlgItemInt(hDlg, IDC_EDIT3, myp.pid, 0);
			SetDlgItemText(hDlg, IDC_EDIT4, myp.name);
			SetDlgItemInt(hDlg, IDC_EDIT5, (int)myp.phandle, 0);
			fun_ExitCodeProcess(hDlg, myp.phandle);
			break;
		}
	}
}

void fun_TerminateProcess(HWND hDlg)
{
	HANDLE handle;
	handle = (HANDLE)GetDlgItemInt(hDlg, IDC_EDIT5, 0, 0);

	TerminateProcess(handle, -1);

	//vector에서 제거 & 리스트박스를 갱신
	for (int i = 0; i < (int)plist.size(); i++)
	{
		MYPROCESS myp = plist[i];
		if (myp.phandle == handle)
		{
			vector<MYPROCESS>::iterator itr = plist.begin();
			plist.erase(itr + i);

			fun_ListBoxPrint(hDlg);
			break;
		}
	}
}


void fun_ExitCodeProcess(HWND hDlg, HANDLE phandle)
{
	DWORD code;
	GetExitCodeProcess(phandle, &code);

	if (code == STILL_ACTIVE)	//살아있다.
	{
		SetDlgItemText(hDlg, IDC_EDIT6, TEXT("살아있다"));
	}
	else
	{
		SetDlgItemText(hDlg, IDC_EDIT6, TEXT("죽었다"));
	}
}