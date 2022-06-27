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

enum { IDC_NAME=1,IDC_TEL,IDC_ADDR,IDC_MALE,IDC_ADD,IDC_DEL,IDC_EDIT,IDC_FIND };
LRESULT CALLBACK WndProc(HWND hWnd,UINT iMessage,WPARAM wParam,LPARAM lParam)
{
	LVCOLUMN COL;
	LVITEM LI;
	int i;
	HIMAGELIST hImgSm, hImgLa;
	static HWND hList;
	int idx;
	TCHAR szName[255], szTel[255], szAddr[255];

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
		// ������ �Է¹ޱ� ���� ��Ʈ�ѵ��� �����.
		CreateWindow("static","�̸�",WS_CHILD | WS_VISIBLE,
			10,220,50,25,hWnd,(HMENU)-1,g_hInst,NULL);
		CreateWindow("edit",NULL,WS_CHILD | WS_VISIBLE | WS_BORDER | 
			ES_AUTOHSCROLL,60,220,90,25,hWnd,(HMENU)IDC_NAME,g_hInst,NULL);
		CreateWindow("static","��ȭ",WS_CHILD | WS_VISIBLE,
			160,220,50,25,hWnd,(HMENU)-1,g_hInst,NULL);
		CreateWindow("edit",NULL,WS_CHILD | WS_VISIBLE | WS_BORDER | 
			ES_AUTOHSCROLL,210,220,90,25,hWnd,(HMENU)IDC_TEL,g_hInst,NULL);
		CreateWindow("static","�ּ�",WS_CHILD | WS_VISIBLE,
			310,220,50,25,hWnd,(HMENU)-1,g_hInst,NULL);
		CreateWindow("edit",NULL,WS_CHILD | WS_VISIBLE | WS_BORDER | 
			ES_AUTOHSCROLL,360,220,190,25,hWnd,(HMENU)IDC_ADDR,g_hInst,NULL);
		CreateWindow("button","����",WS_CHILD | WS_VISIBLE | 
			BS_AUTOCHECKBOX,560,220,100,25,hWnd,(HMENU)IDC_MALE,g_hInst,NULL);
		// ��� ��ư
		CreateWindow("button","�߰�",WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			110,250,90,25,hWnd,(HMENU)IDC_ADD,g_hInst,NULL);
		CreateWindow("button","����",WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			210,250,90,25,hWnd,(HMENU)IDC_DEL,g_hInst,NULL);
		CreateWindow("button","����",WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			310,250,90,25,hWnd,(HMENU)IDC_EDIT,g_hInst,NULL);
		CreateWindow("button","�˻�",WS_CHILD | WS_VISIBLE | BS_PUSHBUTTON,
			410,250,90,25,hWnd,(HMENU)IDC_FIND,g_hInst,NULL);
		return 0;
	case WM_NOTIFY:
		LPNMHDR hdr;
		LPNMLISTVIEW nlv;
		hdr=(LPNMHDR)lParam;
		nlv=(LPNMLISTVIEW)lParam;
		if (hdr->hwndFrom == hList) {
			switch (hdr->code) {
			// ���õ� �׸��� ����Ʈ�� �����ش�.
			case LVN_ITEMCHANGED:
				if (nlv->uChanged == LVIF_STATE && nlv->uNewState == 
					(LVIS_SELECTED | LVIS_FOCUSED)) {
					LI.mask=LVIF_IMAGE;
					LI.iItem=nlv->iItem;
					LI.iSubItem=0;
					ListView_GetItem(hList, &LI);
					CheckDlgButton(hWnd,IDC_MALE,LI.iImage==0);

					ListView_GetItemText(hList,nlv->iItem,0,szName,255);
					SetDlgItemText(hWnd,IDC_NAME,szName);
					ListView_GetItemText(hList,nlv->iItem,1,szTel,255);
					SetDlgItemText(hWnd,IDC_TEL,szTel);
					ListView_GetItemText(hList,nlv->iItem,2,szAddr,255);
					SetDlgItemText(hWnd,IDC_ADDR,szAddr);
				}
				return TRUE;
			}
		}
		break;
	case WM_COMMAND:
		switch (LOWORD(wParam)) {
		// �� �׸��� �߰��Ѵ�.
		case IDC_ADD:
			LI.mask=LVIF_TEXT | LVIF_IMAGE;
			LI.iImage=(IsDlgButtonChecked(hWnd,IDC_MALE) ? 0:1);
			LI.iSubItem=0;
			idx=ListView_GetItemCount(hList);
			LI.iItem=idx;
			GetDlgItemText(hWnd,IDC_NAME,szName,255);
			LI.pszText=szName;
			ListView_InsertItem(hList,&LI);

			GetDlgItemText(hWnd,IDC_TEL,szTel,255);
			ListView_SetItemText(hList,idx,1,szTel);
			GetDlgItemText(hWnd,IDC_ADDR,szAddr,255);
			ListView_SetItemText(hList,idx,2,szAddr);
			return TRUE;
		// ������ �׸��� �����Ѵ�.
		case IDC_DEL:
			idx=ListView_GetNextItem(hList,-1,LVNI_ALL | LVNI_SELECTED);
			if (idx == -1)  {
				MessageBox(hWnd,"������ �׸��� ���� �����Ͻʽÿ�.","�˸�",MB_OK);
			} else {
				ListView_DeleteItem(hList, idx);
			}
/* ���õ� ��� �׸��� �����Ѵ�.
			idx=ListView_GetNextItem(hList,-1,LVNI_ALL | LVNI_SELECTED);
			if (idx == -1)  {
				MessageBox(hWnd,"������ �׸��� ���� �����Ͻʽÿ�","�˸�",MB_OK);
			} else {
				do {
					ListView_DeleteItem(hList, idx);
					idx=ListView_GetNextItem(hList,idx-1,LVNI_ALL | LVNI_SELECTED);
				} while (idx != -1);
			}
//*/
			return TRUE;
		// ������ �׸��� �����Ѵ�.
		case IDC_EDIT:
			idx=ListView_GetNextItem(hList,-1,LVNI_ALL | LVNI_SELECTED);
			if (idx == -1)  {
				MessageBox(hWnd,"������ �׸��� ���� �����Ͻʽÿ�.","�˸�",MB_OK);
			} else {
				LI.mask=LVIF_IMAGE;
				LI.iItem=idx;
				LI.iSubItem=0;
				LI.iImage=(IsDlgButtonChecked(hWnd,IDC_MALE) ? 0:1);
				ListView_SetItem(hList, &LI);

				GetDlgItemText(hWnd,IDC_NAME,szName,255);
				ListView_SetItemText(hList,idx,0,szName);
				GetDlgItemText(hWnd,IDC_TEL,szTel,255);
				ListView_SetItemText(hList,idx,1,szTel);
				GetDlgItemText(hWnd,IDC_ADDR,szAddr,255);
				ListView_SetItemText(hList,idx,2,szAddr);
			}
			return TRUE;
		// �̸����� �׸��� �˻��Ѵ�.
		case IDC_FIND:
			LVFINDINFO fi;
			GetDlgItemText(hWnd,IDC_NAME,szName,255);
			fi.flags=LVFI_STRING;
			fi.psz=szName;
			fi.vkDirection=VK_DOWN;
			idx=ListView_FindItem(hList,-1,&fi);
			if (idx==-1) {
				MessageBox(hWnd,"������ �̸��� �׸��� �����ϴ�","�˸�",MB_OK);
			} else {
				ListView_SetItemState(hList,-1,0,LVIS_FOCUSED | LVIS_SELECTED);
				ListView_SetItemState(hList,idx,LVIS_FOCUSED | LVIS_SELECTED,
					LVIS_FOCUSED | LVIS_SELECTED);
				ListView_EnsureVisible(hList,idx,FALSE);
			}
			return TRUE;
		}
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}
	return(DefWindowProc(hWnd,iMessage,wParam,lParam));
}

