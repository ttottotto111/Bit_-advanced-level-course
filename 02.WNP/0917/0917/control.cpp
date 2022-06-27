//control.cpp

#include "std.h"

BOOL g_isConnect = FALSE;
BOOL g_isLogin	 = FALSE;
HWND g_hDlg;

void con_Init(HWND hDlg)
{
	g_hDlg = hDlg;

	sock_LibInit();
	SetButtonState(hDlg, TRUE, FALSE, FALSE, FALSE, FALSE, FALSE);
}

void con_exit()
{
	sock_LibExit();
}



void con_NewMember(HWND hDlg)
{
	MEMBER data = { 0 };
	//모달
	UINT ret = DialogBoxParam(GetModuleHandle(0),// hinstance
		MAKEINTRESOURCE(IDD_DIALOG2),
		hDlg, // 부모
		NewMemberDlgProc, // 메세지 함수.
		(LPARAM)&data); // WM_INITDIALOG의 lParam로 전달된다.

	if (ret == IDOK)
	{
		//해당 서버로 전송
		pack_SetNewMember(&data);
		sock_Send((char*)&data, sizeof(data));
	}
}

void con_Cancel(HWND hDlg)
{
	sock_LibExit();
	EndDialog(hDlg, IDCANCEL);
}

void con_Login(HWND hDlg)
{
	LOGIN data;
	GetDlgItemText(hDlg, IDC_EDIT1, data.id, sizeof(data.id));
	GetDlgItemText(hDlg, IDC_EDIT2, data.pw_name, sizeof(data.pw_name));

	pack_SetLogin(&data);
	sock_Send((char*)&data, sizeof(data));
}

void con_LogOut(HWND hDlg)
{
	LOGIN logout;
	g_isLogin = FALSE;

	pack_SetLogout(&logout);
	sock_Send((char*)&logout, sizeof(logout));

	SetButtonState(hDlg, FALSE, TRUE, TRUE, TRUE, FALSE, FALSE);
}

void con_ConnectServer(HWND hDlg)
{
	sock_CreateSocket();
	g_isConnect = TRUE;
	SetButtonState(hDlg, FALSE, TRUE, TRUE, TRUE, FALSE, FALSE);
}

void con_DisConnectServer(HWND hDlg)
{
	g_isConnect = FALSE;
	SetButtonState(hDlg, TRUE, FALSE, FALSE, FALSE, FALSE, FALSE);
}

void con_SendData(HWND hDlg)
{
	TCHAR msg[50];
	GetDlgItemText(hDlg, IDC_EDIT3, msg, sizeof(msg));
}

/*
최초				:1		/2,3,4,5,6
서버연결이 되었다	:2,3,4	/1,5,6
로그인이 되었다		:2,5,6	/1,3,4
로그아웃			:2,3,4	/1,5,6
*/
void SetButtonState(HWND hDlg, BOOL b1, BOOL b2, BOOL b3, BOOL b4, BOOL b5, BOOL b6) 
{

	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON1), b1);//서버연결
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON2), b2);//서버연결해제
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON3), b3);//로그인
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON4), b4);//회원가입
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON5), b5);//로그아웃
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON6), b6);//전송
}

void con_RecvData(TCHAR* buf)
{
	int* flag = (int*)buf;
	if (*flag == ACK_NEWMEMBER_S)
	{
		MessageBox(0, TEXT("회원가입성공"), TEXT("알림"), MB_OK);
	}
	else if (*flag == ACK_NEWMEMBER_F)
	{
		MEMBER* pmem = (MEMBER*)buf;
		//pmem->name
		MessageBox(0, TEXT("회원가입실패"), TEXT("알림"), MB_OK);
	}
	else if (*flag == ACK_LOGIN_S)
	{
		LOGIN* plogin = (LOGIN*)buf;
		g_isLogin = TRUE;
		//2, 5,6    / 1,3, 4
		SetButtonState(g_hDlg, FALSE, TRUE, FALSE, FALSE, TRUE, TRUE);
		//컨트롤 출력
		SetDlgItemText(g_hDlg, IDC_EDIT3, plogin->id);
		SetDlgItemText(g_hDlg, IDC_EDIT5, plogin->pw_name);
		TCHAR temp[100];
		wsprintf(temp, TEXT("%s님이 로그인하셨습니다."), plogin->pw_name);
		SetWindowText(g_hDlg, temp);
	}
	else if (*flag == ACK_LOGIN_F)
	{

	}
}