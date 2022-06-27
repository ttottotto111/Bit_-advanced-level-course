#include"Member.h"

extern vector<MEMBER> memlist;
extern HWND g_hView;
TCHAR g_name[20];

void fun_GetHandle(HWND hDlg)
{
	g_hView = GetDlgItem(hDlg, IDC_LIST1);
}

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
		LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES | LVS_EX_HEADERDRAGDROP);
}

void fun_DataSave(HWND hDlg, LPARAM lParam)
{
	COPYDATASTRUCT* ps = (COPYDATASTRUCT*)lParam;
	MEMBER* pData = (MEMBER*)ps->lpData;
	memlist.push_back(*pData);
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
		wsprintf(temp, TEXT("%d"), mem.id);
		LI.pszText = temp;			// 첫 번째 아이템
		SendMessage(g_hView, LVM_INSERTITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 1;	// 동일행의 컬럼인덱스 
		LI.pszText = mem.name;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 2;
		wsprintf(temp, TEXT("%s"), (mem.gender == 'm' ? TEXT("남자") : TEXT("여자")));
		LI.pszText = temp;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 3;
		LI.pszText = mem.phone;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);
	}

	
}

void fun_Update(HWND hDlg)
{
	

	for (int i = 0; i < (int)memlist.size(); i++)
	{
		MEMBER mem = memlist[i];
		TCHAR upphone[20];
		GetDlgItemText(hDlg, (TCHAR)mem.phone, upphone, sizeof(upphone));
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