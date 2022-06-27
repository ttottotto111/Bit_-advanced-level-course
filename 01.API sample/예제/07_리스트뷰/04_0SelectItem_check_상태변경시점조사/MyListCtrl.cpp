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

LRESULT CALLBACK WndProc(HWND hWnd,UINT iMessage,WPARAM wParam,LPARAM lParam)
{
	LVCOLUMN COL;
	LVITEM LI;
	int i;
	HIMAGELIST hImgSm, hImgLa;
	static HWND hList;
	static TCHAR Mes[255]="���õ� �׸��� �����ϴ�";
	HDC hdc;
	PAINTSTRUCT ps;
	TCHAR Caption[255];

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
		return 0;
	case WM_NOTIFY:
		LPNMHDR hdr;
		LPNMLISTVIEW nlv;
		LPNMITEMACTIVATE nia;
		hdr=(LPNMHDR)lParam;
		nlv=(LPNMLISTVIEW)lParam;
		if (hdr->hwndFrom == hList) {
			switch (hdr->code) {
//* ���õ� �׸��� �����ش�.
			case LVN_ITEMCHANGED:
				if (nlv->uChanged == LVIF_STATE && nlv->uNewState == 
						(LVIS_SELECTED | LVIS_FOCUSED)) {
					ListView_GetItemText(hList,nlv->iItem,0,Caption,255);
					wsprintf(Mes, "���� ���õ� �׸� = %s", Caption);
					InvalidateRect(hWnd, NULL, TRUE);
				}
				break;
//*/
/* �� ��° �׸� ���� ����
			case LVN_ITEMCHANGING:
				if (nlv->uChanged == LVIF_STATE && nlv->iItem == 2 && 
					nlv->uNewState == (LVIS_SELECTED | LVIS_FOCUSED)) {
					wsprintf(Mes, "�� �׸��� ������ �� �����ϴ�");
					InvalidateRect(hWnd, NULL, TRUE);
					return TRUE;
				} else {
					return FALSE;
				}
//*/
/*
			case NM_CLICK:
				nia=(LPNMITEMACTIVATE)lParam;
				ListView_GetItemText(hList,nia->iItem,0,Caption,255);
				wsprintf(Mes, "Ŭ����ǥ=(%d,%d), �׸�=(%d,%d), �ؽ�Ʈ=%s",
					nia->ptAction.x, nia->ptAction.y, nia->iItem, nia->iSubItem, Caption);
				InvalidateRect(hWnd, NULL, TRUE);
				break;
//*/
			}
		}
		return 0;
	case WM_LBUTTONDOWN:
		int idx;
		idx=ListView_GetNextItem(hList,-1,LVNI_ALL | LVNI_SELECTED);
		if (idx == -1)  {
			MessageBox(hWnd,"���õ� �׸��� ����","�˸�",MB_OK);
		} else {
			do {
				ListView_GetItemText(hList, idx, 0, Caption, 255);
				MessageBox(hWnd,Caption,"���õ� �׸�",MB_OK);
				idx=ListView_GetNextItem(hList,idx,LVNI_ALL | LVNI_SELECTED);
			} while (idx != -1);
		}
		return 0;
	case WM_RBUTTONDOWN:
		ListView_SetItemState(hList,-1,0,LVIS_FOCUSED | LVIS_SELECTED);
		ListView_SetItemState(hList,1,LVIS_FOCUSED | LVIS_SELECTED,
			LVIS_FOCUSED | LVIS_SELECTED);
		return 0;
	case WM_PAINT:
		hdc=BeginPaint(hWnd, &ps);
		SetBkMode(hdc,TRANSPARENT);
		TextOut(hdc,10,220,Mes,lstrlen(Mes));
		EndPaint(hWnd, &ps);
		return 0;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return(DefWindowProc(hWnd,iMessage,wParam,lParam));
}

