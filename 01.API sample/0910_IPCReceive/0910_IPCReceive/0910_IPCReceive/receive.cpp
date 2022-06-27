//���ź� 
#pragma comment (linker, "/subsystem:windows")

#include"Member.h"
extern vector<MEMBER> memlist;

BOOL CALLBACK DlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_INITDIALOG: return OnInitDialog(hDlg, wParam, lParam);
	case WM_COMMAND:	return OnCommand(hDlg, wParam, lParam);
	case WM_COPYDATA:	return OnCopyData(hDlg, wParam, lParam);		
	}
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
