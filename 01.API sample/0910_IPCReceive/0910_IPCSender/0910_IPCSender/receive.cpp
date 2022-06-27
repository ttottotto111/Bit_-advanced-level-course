//��ȭ ���� ���
#pragma comment (linker, "/subsystem:windows")

#include"Member.h"
extern vector<MEMBER> memlist;

BOOL CALLBACK DlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_COPYDATA: return OnCopyDataStruct(hDlg, msg, wParam, lParam);
	case WM_INITDIALOG: return OnReceiveInitDialog(hDlg, msg, wParam, lParam);
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case IDCANCEL: EndDialog(hDlg, IDCANCEL); return 0;//����
		}
		return TRUE;
	}
	//return  true�� �ϸ� �⺻���� ������
	return FALSE;//�⺻�����Ǵ� ���ν����� ����
}


int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, PSTR lpCmdLine, int nShowCmd)
{
	UINT ret = DialogBox(hInst,// instance 
		MAKEINTRESOURCE(IDD_DIALOG2), // ���̾�α� ���� 
		0, // �θ� ������ 
		DlgProc); // Proc.. 
	return 0;
}
