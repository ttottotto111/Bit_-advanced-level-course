//��ȭ ���� ���
#pragma comment (linker, "/subsystem:windows")
#include"Member.h"

BOOL CALLBACK DlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_INITDIALOG:		return OnInitDialog(hDlg, msg, wParam, lParam);
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDOK:			return OnOK(hDlg,msg,wParam,lParam);
		case IDCANCEL:	EndDialog(hDlg, IDCANCEL); return 0;//����
		}
		return TRUE;
	}
	//return  true�� �ϸ� �⺻���� ������
	return FALSE;//�⺻�����Ǵ� ���ν����� ����
}


int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, PSTR lpCmdLine, int nShowCmd)
{
	UINT ret = DialogBox(hInst,// instance 
		MAKEINTRESOURCE(IDD_DIALOG1), // ���̾�α� ���� 
		0, // �θ� ������ 
		DlgProc); // Proc.. 
	return 0;
}
