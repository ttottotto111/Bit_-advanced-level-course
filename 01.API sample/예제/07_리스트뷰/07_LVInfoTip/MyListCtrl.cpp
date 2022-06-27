#include <windows.h>
#include <commctrl.h>
#include "resource.h"

LRESULT CALLBACK WndProc(HWND,UINT,WPARAM,LPARAM);
HINSTANCE g_hInst;
HWND hWndMain;
LPCTSTR lpszClass=TEXT("MyListCtrl");

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

	hWnd=CreateWindow(lpszClass,lpszClass,WS_OVERLAPPEDWINDOW | WS_CLIPCHILDREN,
		CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,CW_USEDEFAULT,
		NULL,(HMENU)NULL,hInstance,NULL);
	ShowWindow(hWnd,nCmdShow);

	while (GetMessage(&Message,NULL,0,0)) {
		TranslateMessage(&Message);
		DispatchMessage(&Message);
	}
	return (int)Message.wParam;
}

struct tag_people {
	TCHAR name[80];
	TCHAR tel[80];
	TCHAR addr[50];
	BOOL male;
} people[]={
	{"�����=�� ���α׷��� ���� ���","���� �� ��ȭ��ȣ �׸� 123-4567","����� ������ ������",TRUE},
	{"�̼ۿ�=ASP�� ����","�� ����� ���� �ʹ� �����ؼ� ��ȭ�� �����ϴ�.","����� ���ǵ�",TRUE},
	{"�ڴ���=MFC�� ����","���� �ȵ��� ������ ��ȭ��ȣ�� �ǹ̰� �����ϴ�.","��⵵ �����",FALSE},
	{"���ü�=�ڶ����� �츮�� �����","��ȭ���� �ڵ����� �� ���� ����մϴ�.","����� ������ ������",TRUE},
	{"�����=��ġ ���α׷��� �밡","358-2277","����� �б�����",FALSE},
	{"������=SI�� ����","548-1109","����� �Ż絿",TRUE},
};

LRESULT CALLBACK WndProc(HWND hWnd,UINT iMessage,WPARAM wParam,LPARAM lParam)
{
	LVCOLUMN COL;
	LVITEM LI;
	int i;
	HIMAGELIST hImgSm, hImgLa;
	static HWND hList;

	switch (iMessage) {
	case WM_CREATE:
		InitCommonControls();

		// ����Ʈ ��Ʈ���� �ڼ��� ����� �����.
		hList=CreateWindow(WC_LISTVIEW,NULL,WS_CHILD | WS_VISIBLE | WS_BORDER |
			LVS_REPORT | LVS_SHOWSELALWAYS,
			10,10,600,200,hWnd,NULL,g_hInst,NULL);

		// ũ�⺰�� �� ������ �̹��� ����Ʈ�� ����� ����Ʈ ��Ʈ�ѿ� �����Ѵ�.
		hImgSm=ImageList_LoadBitmap(g_hInst, MAKEINTRESOURCE(IDB_BIT16), 
			16, 1, RGB(255,255,255));
		hImgLa=ImageList_LoadBitmap(g_hInst, MAKEINTRESOURCE(IDB_BIT32), 
			32, 1, RGB(255,255,255));
		ListView_SetImageList(hList, hImgSm, LVSIL_SMALL);
		ListView_SetImageList(hList, hImgLa, LVSIL_NORMAL);

		// ����� �߰��Ѵ�.
		COL.mask=LVCF_FMT | LVCF_WIDTH | LVCF_TEXT |LVCF_SUBITEM;
		COL.fmt=LVCFMT_LEFT;
		COL.cx=150;
		COL.pszText="�̸�";			// ù��° ���
		COL.iSubItem=0;
		ListView_InsertColumn(hList,0,&COL);

		COL.pszText="��ȭ��ȣ";		// �ι�° ���
		COL.iSubItem=1;
		ListView_InsertColumn(hList,1,&COL);

		COL.cx=300;
		COL.pszText="�ּ�";			// ����° ���
		COL.iSubItem=2;
		ListView_InsertColumn(hList,2,&COL);

		// �ؽ�Ʈ�� �̹����� ���� �����۵��� ����Ѵ�.
		for (i=0;i<sizeof(people)/sizeof(people[0]);i++) {
			LI.mask=LVIF_TEXT | LVIF_IMAGE;
			LI.iItem=i;
			LI.iSubItem=0;
			LI.pszText=people[i].name;
			LI.iImage=(people[i].male ? 0:1);
			ListView_InsertItem(hList,&LI);

			ListView_SetItemText(hList,i,1,people[i].tel);
			ListView_SetItemText(hList,i,2,people[i].addr);
		}
		ListView_SetExtendedListViewStyle(hList, LVS_EX_INFOTIP);
		return 0;
	case WM_NOTIFY:
		LPNMHDR hdr;
		LPNMLVGETINFOTIP ngt;
		hdr=(LPNMHDR)lParam;
		ngt=(LPNMLVGETINFOTIP)lParam;
		TCHAR str[255];
		if (hdr->hwndFrom == hList) {
			switch (hdr->code) {
			case LVN_GETINFOTIP:
				if (ngt->iItem == 0) {
					lstrcpy(ngt->pszText, "���� ���ְ� �ȶ��� ���\r\n�� ���α׷��� ���� ���");
				}
				wsprintf(str, "iItem=%d �׸� Text=%s",ngt->iItem, ngt->pszText);
				SetWindowText(hWnd,str);
				return 0;
			}
		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return(DefWindowProc(hWnd,iMessage,wParam,lParam));
}

