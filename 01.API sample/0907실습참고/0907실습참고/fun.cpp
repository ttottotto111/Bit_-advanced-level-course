//fun.cpp
#include <Windows.h>
#include <tchar.h>
#include "resource.h"
#include <vector>
using namespace std;
#include <commctrl.h>		//listview
#include "resource.h"

#include "fun.h"
#include "modaldlg.h"
#include "member.h"
#include "modalless.h"


HWND g_hDlg = 0;
TCHAR g_name[20];

extern vector<MEMBER> memlist;
extern HWND g_hView;

void fun_ListViewHeader(HWND hDlg, HWND g_hView)
{
	LVCOLUMN COL;

	// 헤더를 추가한다.
	COL.mask = LVCF_FMT | LVCF_WIDTH | LVCF_TEXT | LVCF_SUBITEM;
	COL.fmt = LVCFMT_LEFT;
	COL.cx = 80;
	COL.pszText = TEXT("회원번호");				// 첫 번째 헤더
	COL.iSubItem = 0;
	SendMessage(g_hView, LVM_INSERTCOLUMN, 0, (LPARAM)&COL);

	COL.pszText = TEXT("회원이름");			// 두 번째 헤더
	COL.cx = 120;
	COL.iSubItem = 1;
	SendMessage(g_hView, LVM_INSERTCOLUMN, 1, (LPARAM)&COL);

	COL.cx = 90;
	COL.pszText = TEXT("성별");				// 세 번째 헤더
	COL.iSubItem = 2;
	SendMessage(g_hView, LVM_INSERTCOLUMN, 2, (LPARAM)&COL);

	COL.cx = 150;
	COL.pszText = TEXT("전화번호");				// 네 번째 헤더
	COL.iSubItem = 3;
	SendMessage(g_hView, LVM_INSERTCOLUMN, 3, (LPARAM)&COL);

	ListView_SetExtendedListViewStyle(g_hView, 
		LVS_EX_FULLROWSELECT| LVS_EX_GRIDLINES| LVS_EX_HEADERDRAGDROP);
}

void fun_ListViewPrint(HWND hDlg)
{	
	//리스트박스전체 삭제
	ListView_DeleteAllItems(g_hView);

	//전체 저장정보를 출력
	TCHAR temp[20];
	for (int i = 0; i < (int)memlist.size(); i++)
	{
		MEMBER mem = memlist[i];

		// 텍스트와 이미지를 가진 아이템들을 등록한다.
		LVITEM LI;

		LI.mask = LVIF_TEXT | LVIF_IMAGE;

		LI.iImage = 0;
		LI.iItem = i;	//행의 개념
		LI.iSubItem = 0;//동일행의 컬럼인덱스
		wsprintf(temp, TEXT("%d"), mem.number);
		LI.pszText = temp;			// 첫 번째 아이템
		SendMessage(g_hView, LVM_INSERTITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 1;	// 동일행의 컬럼인덱스 
		LI.pszText = mem.name;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 2;
		wsprintf(temp, TEXT("%s"), (mem.gender == 'm' ?  TEXT("남자") : TEXT("여자")) );
		LI.pszText = temp;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 3;
		LI.pszText = mem.phone;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);
	}
}

void fun_Insert(HWND hDlg)
{
	//모달
	MEMBER temp = { 0 };

	UINT ret = DialogBoxParam(GetModuleHandle(0),// hinstance
		MAKEINTRESOURCE(IDD_DIALOG2),
		hDlg, // 부모
		ModalDlgProc, // 메세지 함수.
		(LPARAM)&temp); // WM_INITDIALOG의 lParam로 전달된다.
	if (ret == IDOK)
	{
		//저장
		memlist.push_back(temp);

		//리스트뷰 갱신
		fun_ListViewPrint(hDlg);
	}
}

void fun_Select(HWND hDlg)
{
	//모달리스 생성
	if (g_hDlg == 0)
	{
		g_hDlg = CreateDialogParam(GetModuleHandle(0),// hinstance
			MAKEINTRESOURCE(IDD_DIALOG3),
			hDlg, // 부모
			ModallessDlgProc, // 메세지 함수.
			(LPARAM)g_name);

		ShowWindow(g_hDlg, SW_SHOW);
	}
	else
	{
		SetFocus(g_hDlg);
	}
}

void fun_ApplyName(HWND hDlg)
{
	for (int i = 0; i < (int)memlist.size(); i++)
	{
		MEMBER mem = memlist[i];

		if (_tcscmp(mem.name, g_name) == 0)
		{
			//컨트롤에 출력
			SetDlgItemInt(hDlg, IDC_EDIT1, mem.number, 0);
			SetDlgItemText(hDlg, IDC_EDIT2, mem.name);
			HWND hRadio = GetDlgItem(hDlg, IDC_RADIO1);
			HWND hRadio1 = GetDlgItem(hDlg, IDC_RADIO2);

			if(mem.gender == 'm')
			{ 
				SendMessage(hRadio, BM_SETCHECK, BST_CHECKED, 0);
				SendMessage(hRadio1, BM_SETCHECK, BST_UNCHECKED, 0);
			}
			else
			{
				SendMessage(hRadio, BM_SETCHECK, BST_UNCHECKED, 0);
				SendMessage(hRadio1, BM_SETCHECK, BST_CHECKED, 0);
			}

			SetDlgItemText(hDlg, IDC_EDIT3, mem.phone);

			break;
		}
	}
}

void fun_Delete(HWND hDlg)
{	
	for (int i = 0; i < (int)memlist.size(); i++)
	{
		MEMBER mem = memlist[i];
		if (_tcscmp(mem.name, g_name) == 0)
		{
			//저장소에서 삭제
			vector<MEMBER>::iterator itr = memlist.begin();
			memlist.erase(itr + i);

			//리스트뷰를 다시 출력
			fun_ListViewPrint(hDlg);

			break;
		}
	}	
}

void fun_Update(HWND hDlg)
{
	TCHAR upphone[20];
	GetDlgItemText(hDlg, IDC_EDIT4, upphone, sizeof(upphone));

	for (int i = 0; i < (int)memlist.size(); i++)
	{
		MEMBER mem = memlist[i];
		if (_tcscmp(mem.name, g_name) == 0)
		{
			//저장소에서 수정
			_tcscpy_s(memlist[i].phone, _countof(memlist[i].phone), upphone);

			//리스트뷰를 다시 출력
			fun_ListViewPrint(hDlg);

			break;
		}
	}
}

void fun_ListViewNotify(HWND hDlg, WPARAM wParam, LPARAM lParam)
{
	LPNMHDR hdr;
	LPNMLISTVIEW nlv;
	hdr = (LPNMHDR)lParam;
	nlv = (LPNMLISTVIEW)lParam;
	LVITEM LI;
	TCHAR Temp[20];

	if (hdr->hwndFrom == g_hView) 
	{
		switch (hdr->code) 
		{
			// 선택된 항목을 에디트에 보여준다.
		case LVN_ITEMCHANGED:
			if (nlv->uChanged == LVIF_STATE && nlv->uNewState ==
				(LVIS_SELECTED | LVIS_FOCUSED)) 
			{
				LI.mask = LVIF_IMAGE;
				LI.iItem = nlv->iItem;
				LI.iSubItem = 0;
				
				//회원번호
				ListView_GetItemText(g_hView, nlv->iItem, 0, Temp, sizeof(Temp));
				int number = _ttoi(Temp);
				SetDlgItemInt(hDlg, IDC_EDIT1, number, 0);
				
				//이름
				ListView_GetItemText(g_hView, nlv->iItem, 1, Temp, sizeof(Temp));
				SetDlgItemText(hDlg, IDC_EDIT2, Temp);
				
				HWND hRadio = GetDlgItem(hDlg, IDC_RADIO1);
				HWND hRadio1 = GetDlgItem(hDlg, IDC_RADIO2);

				ListView_GetItemText(g_hView, nlv->iItem, 2, Temp, sizeof(Temp));
				if ( _tcscmp(Temp, TEXT("남자"))== 0)
				{
					SendMessage(hRadio, BM_SETCHECK, BST_CHECKED, 0);
					SendMessage(hRadio1, BM_SETCHECK, BST_UNCHECKED, 0);
				}
				else
				{
					SendMessage(hRadio, BM_SETCHECK, BST_UNCHECKED, 0);
					SendMessage(hRadio1, BM_SETCHECK, BST_CHECKED, 0);
				}

				//전화번호
				ListView_GetItemText(g_hView, nlv->iItem, 3, Temp, sizeof(Temp));
				SetDlgItemText(hDlg, IDC_EDIT3, Temp);
			}
		}
	}
}