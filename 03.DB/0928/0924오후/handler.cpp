//handler.cpp

#include "std.h"

BOOL OnInitDialog(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	con_Init(hDlg);

	return TRUE;
}

BOOL OnCommand(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	switch (LOWORD(wParam))
	{
		//�ӽ� ���ӹ�ư
	case IDC_BUTTON1:	con_Connect(hDlg);			break;
		//�����̸����� ���� id�˻�
	case IDC_BUTTON6:	con_SelectAccount(hDlg);	break;
		//���� ����
	case IDC_BUTTON2:	con_InsertAccount(hDlg);	break;
		//�ߺ��ڽ� ������
	case IDC_COMBO1:	con_NotifyComboBox(hDlg, wParam);	break;
	case IDCANCEL:		con_Exit(hDlg);				return 0;
	}
	return TRUE;
}