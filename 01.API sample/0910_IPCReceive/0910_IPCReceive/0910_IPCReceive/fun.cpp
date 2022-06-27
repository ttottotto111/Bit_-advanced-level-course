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

	// ����� �߰��Ѵ�.
	COL.mask = LVCF_FMT | LVCF_WIDTH | LVCF_TEXT | LVCF_SUBITEM;
	COL.fmt = LVCFMT_LEFT;
	COL.cx = 80;
	COL.pszText = TEXT("ȸ����ȣ");				// ù ��° ���
	COL.iSubItem = 0;
	SendMessage(g_hView, LVM_INSERTCOLUMN, 0, (LPARAM)&COL);

	COL.pszText = TEXT("ȸ���̸�");			// �� ��° ���
	COL.cx = 120;
	COL.iSubItem = 1;
	SendMessage(g_hView, LVM_INSERTCOLUMN, 1, (LPARAM)&COL);

	COL.cx = 90;
	COL.pszText = TEXT("����");				// �� ��° ���
	COL.iSubItem = 2;
	SendMessage(g_hView, LVM_INSERTCOLUMN, 2, (LPARAM)&COL);

	COL.cx = 150;
	COL.pszText = TEXT("��ȭ��ȣ");				// �� ��° ���
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
	//����Ʈ�ڽ���ü ����
	ListView_DeleteAllItems(g_hView);

	//��ü ���������� ���
	TCHAR temp[20];
	for (int i = 0; i < (int)memlist.size(); i++)
	{
		MEMBER mem = memlist[i];

		// �ؽ�Ʈ�� �̹����� ���� �����۵��� ����Ѵ�.
		LVITEM LI;

		LI.mask = LVIF_TEXT | LVIF_IMAGE;

		LI.iImage = 0;
		LI.iItem = i;	//���� ����
		LI.iSubItem = 0;//�������� �÷��ε���
		wsprintf(temp, TEXT("%d"), mem.id);
		LI.pszText = temp;			// ù ��° ������
		SendMessage(g_hView, LVM_INSERTITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 1;	// �������� �÷��ε��� 
		LI.pszText = mem.name;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 2;
		wsprintf(temp, TEXT("%s"), (mem.gender == 'm' ? TEXT("����") : TEXT("����")));
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
			//����ҿ��� ����
			_tcscpy_s(memlist[i].phone, _countof(memlist[i].phone), upphone);

			//����Ʈ�並 �ٽ� ���
			fun_ListViewPrint(hDlg);

			break;
		}
	}
}