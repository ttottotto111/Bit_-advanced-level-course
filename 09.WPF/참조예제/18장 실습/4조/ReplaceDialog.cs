//----------------------------------------------
// ReplaceDialog.cs (c) 2006 by Charles Petzold
//----------------------------------------------

/*************************************************************************************
 Ŭ������ : ReplaceDialog
 ��      �� : ����
 ��      �� : FindReplaceDialog�� Replace��ȭ ���ڷ� ����� ����
                 Replace������ ���� �ʴ� ���� ��ư�� 2�� ��
                 �׷�ڽ��� ����.
**************************************************************************************/

using System;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.NotepadClone
{
    class ReplaceDialog : FindReplaceDialog
    {
        public ReplaceDialog(Window owner): base(owner)
        {
            Title = "Replace";

            // �׷� �ڽ��� ����
			groupDirection.Visibility = Visibility.Hidden;	// FindReplaceDialog���� ������ �׷� �ڽ��� ����
        }
    }
}
