#include <windows.h>

LRESULT CALLBACK WndProc(HWND,UINT,WPARAM,LPARAM);
HINSTANCE g_hInst;
HWND hWndMain;
LPCTSTR lpszClass=TEXT("ListCtrl");

int APIENTRY WinMain(HINSTANCE hInstance,HINSTANCE hPrevInstance
	  ,LPSTR lpszCmdParam,int nCmdShow)
{
	HWND hWnd;
	MSG Message;
	WNDCLASS WndClass;
	g_hInst=hInstance;

	WndClass.cbClsExtra=0;
	WndClass.cbWndExtra=0;
	WndClass.hbrBackground=(HBRUSH)(COLOR_BTNFACE+1);
	WndClass.hCursor=LoadCursor(NULL,IDC_ARROW);
	WndClass.hIcon=LoadIcon(NULL,IDI_APPLICATION);
	WndClass.hInstance=hInstance;
	WndClass.lpfnWndProc=WndProc;
	WndClass.lpszClassName=lpszClass;
	WndClass.lpszMenuName=NULL;
	WndClass.style=0;
	RegisterClass(&WndClass);

	hWnd=CreateWindow(lpszClass,lpszClass,WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,
		NULL,(HMENU)NULL,hInstance,NULL);
	ShowWindow(hWnd,nCmdShow);

	while (GetMessage(&Message,NULL,0,0)) {
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}
	return (int)Message.wParam;
}

#include <commctrl.h>
#include "resource.h"
HWND hList;
HIMAGELIST hImgSm, hImgLa;
LRESULT CALLBACK WndProc(HWND hWnd,UINT iMessage,WPARAM wParam,LPARAM lParam)
{
	LVCOLUMN COL;
	LVITEM LI;
	switch (iMessage) {
	case WM_CREATE:
		InitCommonControls();

		// ����Ʈ ��Ʈ���� �ڼ��� ����� �����.
		hList=CreateWindow(WC_LISTVIEW,NULL,WS_CHILD | WS_VISIBLE | WS_BORDER |
			LVS_REPORT,10,10,500,200,hWnd,NULL,g_hInst,NULL);

		// ũ�⺰�� �� ������ �̹��� ����Ʈ�� ����� ����Ʈ ��Ʈ�ѿ� �����Ѵ�.
		hImgSm=ImageList_LoadBitmap(g_hInst, MAKEINTRESOURCE(IDB_BIT16), 
			16, 1, RGB(255,255,255));
		hImgLa=ImageList_LoadBitmap(g_hInst, MAKEINTRESOURCE(IDB_BIT32), 
			32, 1, RGB(255,255,255));
		SendMessage(hList, LVM_SETIMAGELIST, (WPARAM)LVSIL_SMALL, (LPARAM)hImgSm);
		SendMessage(hList, LVM_SETIMAGELIST, (WPARAM)LVSIL_NORMAL, (LPARAM)hImgLa);

		// ����� �߰��Ѵ�.
		COL.mask=LVCF_FMT | LVCF_WIDTH | LVCF_TEXT |LVCF_SUBITEM;
		COL.fmt=LVCFMT_LEFT;
		COL.cx=150;
		COL.pszText="�̸�";				// ù ��° ���
		COL.iSubItem=0;
		SendMessage(hList, LVM_INSERTCOLUMN, 0,(LPARAM)&COL);

		COL.pszText="��ȭ��ȣ";			// �� ��° ���
		COL.iSubItem=1;
		SendMessage(hList, LVM_INSERTCOLUMN, 1,(LPARAM)&COL);

		COL.cx=300;
		COL.pszText="�ּ�";				// �� ��° ���
		COL.iSubItem=2;
		SendMessage(hList, LVM_INSERTCOLUMN, 2,(LPARAM)&COL);

		// �ؽ�Ʈ�� �̹����� ���� �����۵��� ����Ѵ�.
		LI.mask=LVIF_TEXT | LVIF_IMAGE;
		
		LI.iImage=0;
		LI.iSubItem=0;
		LI.iItem=0;
		LI.pszText="�ڹ̿�";			// ù ��° ������
		SendMessage(hList, LVM_INSERTITEM, 0, (LPARAM)&LI);

		LI.iImage=-1;
		LI.iSubItem=1;
		LI.pszText="123-4567";
		SendMessage(hList, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem=2;
		LI.pszText="����� ������";
		SendMessage(hList, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iImage=0;
		LI.iItem=1;
		LI.iSubItem=0;
		LI.pszText="������";			// �� ��° ������
		SendMessage(hList, LVM_INSERTITEM, 0, (LPARAM)&LI);

		LI.iImage=-1;
		LI.iSubItem=1;
		LI.pszText="543-9876";
		SendMessage(hList, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem=2;
		LI.pszText="�λ�� ��ŵ�";
		SendMessage(hList, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iImage=1;
		LI.iItem=2;
		LI.iSubItem=0;
		LI.pszText="�����";			// �� ��° ������
		SendMessage(hList, LVM_INSERTITEM, 0, (LPARAM)&LI);

		LI.iImage=-1;
		LI.iSubItem=1;
		LI.pszText="101-0920";
		SendMessage(hList, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem=2;
		LI.pszText="�λ�� ������";
		SendMessage(hList, LVM_SETITEM, 0, (LPARAM)&LI);

		return 0;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return(DefWindowProc(hWnd,iMessage,wParam,lParam));
}

