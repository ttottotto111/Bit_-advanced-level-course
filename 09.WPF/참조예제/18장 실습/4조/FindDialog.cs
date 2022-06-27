//-------------------------------------------
// FindDialog.cs (c) 2006 by Charles Petzold
//-------------------------------------------

/*************************************************************************************
 Ŭ������ : FindDialog
 ��      �� : ����
 ��      �� : FindReplaceDialog�� Find��ȭ ���ڷ� ����� ����
                 Find������ ���� �ʴ� Label, TextBox, Replace ��ư, Replace All ��ư�� ����
**************************************************************************************/

using System;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.NotepadClone
{
    class FindDialog : FindReplaceDialog
    {
        public FindDialog(Window owner): base(owner)
        {
            Title = "Find";

            // ��Ʈ�� �� ���� ����
			lblReplace.Visibility = Visibility.Collapsed;		// FindReplaceDialog���� ������ Label
            txtboxReplace.Visibility = Visibility.Collapsed;	// �ؽ�Ʈ �ڽ�
            btnReplace.Visibility = Visibility.Collapsed;		// Replace ��ư
            btnAll.Visibility = Visibility.Collapsed;			// Replace All ��ư�� ����
        }
    }
}
