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
	WndClass.lpszMenuName=MAKEINTRESOURCE(IDR_MENU1);
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
	TCHAR name[20];
	TCHAR tel[20];
	TCHAR addr[50];
	BOOL male;
} people[]={
	{"�����","123-4567","����� ������ ������",TRUE},
	{"�̼ۿ�","543-9876","����� ���ǵ�",TRUE},
	{"�ڴ���","111-3333","��⵵ �����",FALSE},
	{"���ü�","236-1818","����� ������ ������",TRUE},
	{"�����","358-2277","����� �б�����",FALSE},
	{"������","548-1109","����� �Ż絿",TRUE},
};

void SetListViewStyle(HWND hList, DWORD dwView)
{
	DWORD dwStyle;

	dwStyle=GetWindowLong(hList, GWL_STYLE);
	if ((dwStyle & LVS_TYPEMASK) != dwView) {
		SetWindowLong(hList, GWL_STYLE, (dwStyle & ~LVS_TYPEMASK) | dwView);
	}
}

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
/* ���� �����ϱ�
		ListView_SetTextColor(hList, RGB(0xff,0x00,0x00));
		ListView_SetTextBkColor(hList, RGB(0x99,0xff,0x99));
		ListView_SetBkColor(hList, RGB(0xff,0xff,0x00));
//*/
		return 0;
	case WM_COMMAND:
		switch (LOWORD(wParam)) {
		case IDM_ICON:
			SetListViewStyle(hList, LVS_ICON);
			break;
		case IDM_SMALLICON:
			SetListViewStyle(hList, LVS_SMALLICON);
			break;
		case IDM_LIST:
			SetListViewStyle(hList, LVS_LIST);
			break;
		case IDM_REPORT:
			SetListViewStyle(hList, LVS_REPORT);
			break;
		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return(DefWindowProc(hWnd,iMessage,wParam,lParam));
}

