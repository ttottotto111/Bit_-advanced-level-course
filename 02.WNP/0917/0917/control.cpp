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
	//���
	UINT ret = DialogBoxParam(GetModuleHandle(0),// hinstance
		MAKEINTRESOURCE(IDD_DIALOG2),
		hDlg, // �θ�
		NewMemberDlgProc, // �޼��� �Լ�.
		(LPARAM)&data); // WM_INITDIALOG�� lParam�� ���޵ȴ�.

	if (ret == IDOK)
	{
		//�ش� ������ ����
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
����				:1		/2,3,4,5,6
���������� �Ǿ���	:2,3,4	/1,5,6
�α����� �Ǿ���		:2,5,6	/1,3,4
�α׾ƿ�			:2,3,4	/1,5,6
*/
void SetButtonState(HWND hDlg, BOOL b1, BOOL b2, BOOL b3, BOOL b4, BOOL b5, BOOL b6) 
{

	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON1), b1);//��������
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON2), b2);//������������
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON3), b3);//�α���
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON4), b4);//ȸ������
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON5), b5);//�α׾ƿ�
	EnableWindow(GetDlgItem(hDlg, IDC_BUTTON6), b6);//����
}

void con_RecvData(TCHAR* buf)
{
	int* flag = (int*)buf;
	if (*flag == ACK_NEWMEMBER_S)
	{
		MessageBox(0, TEXT("ȸ�����Լ���"), TEXT("�˸�"), MB_OK);
	}
	else if (*flag == ACK_NEWMEMBER_F)
	{
		MEMBER* pmem = (MEMBER*)buf;
		//pmem->name
		MessageBox(0, TEXT("ȸ�����Խ���"), TEXT("�˸�"), MB_OK);
	}
	else if (*flag == ACK_LOGIN_S)
	{
		LOGIN* plogin = (LOGIN*)buf;
		g_isLogin = TRUE;
		//2, 5,6    / 1,3, 4
		SetButtonState(g_hDlg, FALSE, TRUE, FALSE, FALSE, TRUE, TRUE);
		//��Ʈ�� ���
		SetDlgItemText(g_hDlg, IDC_EDIT3, plogin->id);
		SetDlgItemText(g_hDlg, IDC_EDIT5, plogin->pw_name);
		TCHAR temp[100];
		wsprintf(temp, TEXT("%s���� �α����ϼ̽��ϴ�."), plogin->pw_name);
		SetWindowText(g_hDlg, temp);
	}
	else if (*flag == ACK_LOGIN_F)
	{

	}
}