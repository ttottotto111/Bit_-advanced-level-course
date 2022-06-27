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
		LVS_EX_FULLROWSELECT| LVS_EX_GRIDLINES| LVS_EX_HEADERDRAGDROP);
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
		wsprintf(temp, TEXT("%d"), mem.number);
		LI.pszText = temp;			// ù ��° ������
		SendMessage(g_hView, LVM_INSERTITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 1;	// �������� �÷��ε��� 
		LI.pszText = mem.name;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 2;
		wsprintf(temp, TEXT("%s"), (mem.gender == 'm' ?  TEXT("����") : TEXT("����")) );
		LI.pszText = temp;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);

		LI.iSubItem = 3;
		LI.pszText = mem.phone;
		SendMessage(g_hView, LVM_SETITEM, 0, (LPARAM)&LI);
	}
}

void fun_Insert(HWND hDlg)
{
	//���
	MEMBER temp = { 0 };

	UINT ret = DialogBoxParam(GetModuleHandle(0),// hinstance
		MAKEINTRESOURCE(IDD_DIALOG2),
		hDlg, // �θ�
		ModalDlgProc, // �޼��� �Լ�.
		(LPARAM)&temp); // WM_INITDIALOG�� lParam�� ���޵ȴ�.
	if (ret == IDOK)
	{
		//����
		memlist.push_back(temp);

		//����Ʈ�� ����
		fun_ListViewPrint(hDlg);
	}
}

void fun_Select(HWND hDlg)
{
	//��޸��� ����
	if (g_hDlg == 0)
	{
		g_hDlg = CreateDialogParam(GetModuleHandle(0),// hinstance
			MAKEINTRESOURCE(IDD_DIALOG3),
			hDlg, // �θ�
			ModallessDlgProc, // �޼��� �Լ�.
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
			//��Ʈ�ѿ� ���
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
			//����ҿ��� ����
			vector<MEMBER>::iterator itr = memlist.begin();
			memlist.erase(itr + i);

			//����Ʈ�並 �ٽ� ���
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
			//����ҿ��� ����
			_tcscpy_s(memlist[i].phone, _countof(memlist[i].phone), upphone);

			//����Ʈ�並 �ٽ� ���
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
			// ���õ� �׸��� ����Ʈ�� �����ش�.
		case LVN_ITEMCHANGED:
			if (nlv->uChanged == LVIF_STATE && nlv->uNewState ==
				(LVIS_SELECTED | LVIS_FOCUSED)) 
			{
				LI.mask = LVIF_IMAGE;
				LI.iItem = nlv->iItem;
				LI.iSubItem = 0;
				
				//ȸ����ȣ
				ListView_GetItemText(g_hView, nlv->iItem, 0, Temp, sizeof(Temp));
				int number = _ttoi(Temp);
				SetDlgItemInt(hDlg, IDC_EDIT1, number, 0);
				
				//�̸�
				ListView_GetItemText(g_hView, nlv->iItem, 1, Temp, sizeof(Temp));
				SetDlgItemText(hDlg, IDC_EDIT2, Temp);
				
				HWND hRadio = GetDlgItem(hDlg, IDC_RADIO1);
				HWND hRadio1 = GetDlgItem(hDlg, IDC_RADIO2);

				ListView_GetItemText(g_hView, nlv->iItem, 2, Temp, sizeof(Temp));
				if ( _tcscmp(Temp, TEXT("����"))== 0)
				{
					SendMessage(hRadio, BM_SETCHECK, BST_CHECKED, 0);
					SendMessage(hRadio1, BM_SETCHECK, BST_UNCHECKED, 0);
				}
				else
				{
					SendMessage(hRadio, BM_SETCHECK, BST_UNCHECKED, 0);
					SendMessage(hRadio1, BM_SETCHECK, BST_CHECKED, 0);
				}

				//��ȭ��ȣ
				ListView_GetItemText(g_hView, nlv->iItem, 3, Temp, sizeof(Temp));
				SetDlgItemText(hDlg, IDC_EDIT3, Temp);
			}
		}
	}
}