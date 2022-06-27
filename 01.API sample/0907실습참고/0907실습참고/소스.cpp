//��ȭ���� ��� skeleton �ڵ� 

#pragma comment (linker, "/subsystem:windows")

#include <Windows.h>
#include <tchar.h>		//����Ÿ�� ����� ���� h 
#include "resource.h"
#include "handler.h"
#include "member.h"

BOOL CALLBACK DlgProc(HWND hDlg, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_NOTIFY:		return OnNotify(hDlg, wParam, lParam);
	case WM_APPLY_NAME: return OnApplyName(hDlg, wParam, lParam);
	case WM_INITDIALOG:	return OnInitDialog(hDlg, wParam, lParam);
	case WM_COMMAND:	return OnCommand(hDlg, wParam, lParam);
	}

	return FALSE;	// �����Ǵ� �⺻ ���μ����� ȣ���ϰ� ��..... 
}


int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, PSTR lpCmdLine, int nShowCmd)
{
	UINT ret = DialogBox(hInst,// instance 
		MAKEINTRESOURCE(IDD_DIALOG1), // ���̾�α� ���� 
		0, // �θ� ������ 
		DlgProc); // Proc.. 

	return 0;
}
