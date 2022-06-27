//--------------------------------------------------
// NotepadClone.Find.cs (c) 2006 by Charles Petzold
//--------------------------------------------------


/*************************************************************************************
 Ŭ������ : NotepadClone
 ��      �� : string            - strFindWhat, strReplaceWith
             StringComparison   - strcomp
             Direction          - dirFind
 ��      �� : �˻��� ���� �޴�(Find, Find Next, Replace) �߰� ���� �� ��� ����
              Find : ���ڿ� �˻�
              Find Next :�������� ���� ���ڿ� �˻�
              Replace : ã�� ���ڿ��� ���� �ۼ��� ���ڿ��� ����
**************************************************************************************/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Petzold.NotepadClone
{
    public partial class NotepadClone
    {
        string strFindWhat = "", strReplaceWith = "";                           // strFindWhat : �˻��� ���ڿ� , strReplaceWith : �˻��� ���ڿ�
        StringComparison strcomp = StringComparison.OrdinalIgnoreCase;          // StringComparison ������ ����
        // OrdinalIgnoreCase : ��ҹ��ڸ� �����ϰ� ���ڿ� ��
        Direction dirFind = Direction.Down;                                     // �˻��� ����
        // =======================================================================================================================
        // �޴� �ʱ�ȭ �� ������...
        void AddFindMenuItems(MenuItem itemEdit)
        {
            // Find �޴� �׸� �����...
            MenuItem itemFind = new MenuItem();                                 // itemFind �޴� �߰�
            itemFind.Header = "_Find...";                                       // Herder ����
            itemFind.Command = ApplicationCommands.Find;                        // Command�� Find ����
            itemEdit.Items.Add(itemFind);                                       // itemEdit�� itemFind �߰�
            CommandBindings.Add(new CommandBinding(
                ApplicationCommands.Find, FindOnExecute, FindCanExecute));      // FindOnExecute, FindCanExecute �̺�Ʈ ����
            // -------------------------------------------------------------------------------------------------------------------
            // Ŀ���� RoutedUICommand�� Find Next �׸��� �ʿ�
            InputGestureCollection coll = new InputGestureCollection();         // RoutedUICommand�� �߰��� coll ����
            coll.Add(new KeyGesture(Key.F3));                                   // coll�� F3 ����Ű ���
            RoutedUICommand commFindNext =
                new RoutedUICommand("Find _Next", "FindNext", GetType(), coll); // FindNext ����(text, name, type, gestures)

            MenuItem itemNext = new MenuItem();                                 // itemNext �޴� �߰�
            itemNext.Command = commFindNext;                                    // ������ ���� commFindNext ����
            itemEdit.Items.Add(itemNext);                                       // itemEdit�� itemNext �߰�
            CommandBindings.Add(
                new CommandBinding(commFindNext, FindNextOnExecute,
                                                 FindNextCanExecute));          // FindNextOnExecute, FindNextCanExecute �̺�Ʈ ����
            // -------------------------------------------------------------------------------------------------------------------
            MenuItem itemReplace = new MenuItem();                              // itemReplace �޴� �߰�
            itemReplace.Header = "_Replace...";                                 // Herder ����
            itemReplace.Command = ApplicationCommands.Replace;                  // Command�� Replace ����
            itemEdit.Items.Add(itemReplace);                                    // itemEdit�� itemReplace �߰�
            CommandBindings.Add(new CommandBinding(
                ApplicationCommands.Replace, ReplaceOnExecute, FindCanExecute));// ReplaceOnExecute, FindCanExecute �̺�Ʈ ����
        }
        // =======================================================================================================================
        // Find�� Replce�� ���� CanExecute �޼ҵ�
        void FindCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = (txtbox.Text.Length > 0 && OwnedWindows.Count == 0);  // Find �޴� Ȱ��ȭ ����
        }
        void FindNextCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = (txtbox.Text.Length > 0 && strFindWhat.Length > 0);   // Find Next �޴� Ȱ��ȭ ����
        }
        // =======================================================================================================================
        // Find �޴� �׸� ���� �̺�Ʈ �ڵ鷯
        void FindOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            // ��ȭ���� ����
            FindDialog dlg = new FindDialog(this);

            // ������Ƽ �ʱ�ȭ
            dlg.FindWhat = strFindWhat;                                         // �˻��� ���ڿ�
            dlg.MatchCase = strcomp == StringComparison.Ordinal;                // ���� ���� ��Ģ�� ����Ͽ� ���ڿ��� ��
            dlg.Direction = dirFind;                                            // �˻� ���� ����

            // �̺�Ʈ �ڵ鷯�� �����ϰ� ��ȭ���ڸ� ���
            dlg.FindNext += FindDialogOnFindNext;
            dlg.Show();
        }
        // Find Next �޴� �׸� ���� �̺�Ʈ �ڵ鷯
        // ���ڿ��� ���� ���ٸ� F3 Ű�δ� ��ȭ���ڸ� ȣ��
        void FindNextOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            if (strFindWhat == null || strFindWhat.Length == 0)                 // ���ڿ��� �ִ��� ��
                FindOnExecute(sender, args);                                    // ���ٸ� FindOnExecute ��ȭ���� ȣ��
            else
                FindNext();                                                     // �ִٸ� ���� ���ڿ� �˻�
        }
        

        //=======================================================================================================================
        // Replace �޴� �׸� ���� �̺�Ʈ �ڵ鷯
        void ReplaceOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            ReplaceDialog dlg = new ReplaceDialog(this);

            //dlg �ʱ�ȭ
            dlg.FindWhat = strFindWhat;                     // ���� strFindWhat������ ����ִ� ���ڿ��� dlg.FindWhat�� ����              
            dlg.ReplaceWith = strReplaceWith;               // ���� strReplaceWith������ ����ִ� ���ڿ� dlg.ReplaceWith�� ����                
            dlg.MatchCase = strcomp == StringComparison.Ordinal; 
            dlg.Direction = dirFind;                        // ���� ��ư�� ���� �˻� ���� ����Ʈ�� Down

            // Install �̺�Ʈ �ڵ鷯
            dlg.FindNext += FindDialogOnFindNext;           // FindDialogOnFindNext �̺�Ʈ ����
            dlg.Replace += ReplaceDialogOnReplace;          // ReplaceDialogOnReplace �̺�Ʈ ����
            dlg.ReplaceAll += ReplaceDialogOnReplaceAll;    // ReplaceDialogOnReplaceAll �̺�Ʈ ����

            dlg.Show();                                     // ��޸��� ���̾�α� ����
        }

        // Find/Replace ��ȭ������ "Find Next" ��ư�� ���� �̺�Ʈ �ڵ鷯�� ����
        void FindDialogOnFindNext(object sender, EventArgs args)
        {
            FindReplaceDialog dlg = sender as FindReplaceDialog;    //sender�� FindReplaceDialog���� ����ȯ

            // ��ȭ������ ������Ƽ�� ����
            strFindWhat = dlg.FindWhat;                             //strFindWhat������ ���� dlg.FindWhat�� ����ִ� ���ڿ� ����
            strcomp = dlg.MatchCase ? StringComparison.Ordinal :    //���ڿ��� ���Ͽ� ������� strcomp�� ����
                                StringComparison.OrdinalIgnoreCase;
            dirFind = dlg.Direction;                                // ���� ��ư�� ���� �˻� ���� ����Ʈ�� Down   

            // ������ ã�� ���� FindNext�� ȣ��
            FindNext();
        }

        // Replace ��ȭ������ "Replace" ��ư�� ���� �̺�Ʈ �ڵ鷯�� ����
        void ReplaceDialogOnReplace(object sender, EventArgs args)
        {
            ReplaceDialog dlg = sender as ReplaceDialog;            //sender�� FindReplaceDialog���� ����ȯ

            // ��ȭ������ ������Ƽ�� ����
            strFindWhat = dlg.FindWhat;                             //strFindWhat������ ���� dlg.FindWhat�� ����ִ� ���ڿ� ����
            strReplaceWith = dlg.ReplaceWith;
            strcomp = dlg.MatchCase ? StringComparison.Ordinal :    //���ڿ��� ���Ͽ� ������� strcomp�� ����
                                StringComparison.OrdinalIgnoreCase;

            if (strFindWhat.Equals(txtbox.SelectedText, strcomp))
                txtbox.SelectedText = strReplaceWith;               // ���õ� ���ڿ��� strReplaceWith�� ���ڿ��� �ٲ�

            FindNext();
        }

        // Replace ��ȭ������ "Replace All" ��ư�� ���� �ڵ鷯 ����
        void ReplaceDialogOnReplaceAll(object sender, EventArgs args)
        {
            ReplaceDialog dlg = sender as ReplaceDialog;            //sender�� FindReplaceDialog���� ����ȯ
            string str = txtbox.Text;                               //str ������ texbox���ִ� �ؽ�Ʈ�� ����
            strFindWhat = dlg.FindWhat;                             //strFindWhat������ ���� dlg.FindWhat�� ����ִ� ���ڿ� ����
            strReplaceWith = dlg.ReplaceWith;                       //strReplaceWith������ ���� dlg.FindWhat�� ����ִ� ���ڿ� ����
            strcomp = dlg.MatchCase ? StringComparison.Ordinal :    //���ڿ��� ���Ͽ� ������� strcomp�� ����
                                StringComparison.OrdinalIgnoreCase;
            int index = 0;

            while (index + strFindWhat.Length < str.Length)         //ó�� ���õ� �ý�Ʈ���� �ؽ�Ʈ �ڽ��� ������
            {
                index = str.IndexOf(strFindWhat, index, strcomp);   //??

                if (index != -1)
                {
                    str = str.Remove(index, strFindWhat.Length);    //�����ִ� ���� �����
                    str = str.Insert(index, strReplaceWith);        //���ο� ���� �ְ�
                    index += strReplaceWith.Length;                 //strReplaceWith�� ���̸�ŭ �ε����� ����
                }
                else
                    break;
            }
            txtbox.Text = str;                                      //�ٲ� ������ txtbox�� �ٽ� ����
        }

        // �Ϲ����� FindNext �޼ҵ�
        void FindNext()
        {
            int indexStart, indexFind;

            //�˻��� ���� ��ġ�� �˻� ������ dirFind ������ ���� ������
            if (dirFind == Direction.Down)          //�˻������� DOWN�϶�
            {
                indexStart = txtbox.SelectionStart + txtbox.SelectionLength;
                indexFind = txtbox.Text.IndexOf(strFindWhat, indexStart, strcomp);
            }
            else                                    //�˻������� UP�϶�
            {
                indexStart = txtbox.SelectionStart;
                indexFind = txtbox.Text.LastIndexOf(strFindWhat, indexStart, strcomp);
            }

            //�߰��� �ؽ�Ʈ�� �����ϰ�, �׷��� ������ �޼��� �ڽ� ���
            if (indexFind != -1)
            {
                txtbox.Select(indexFind, strFindWhat.Length);
                txtbox.Focus();
            }
            else
                MessageBox.Show("Cannot find \"" + strFindWhat + "\"", Title,
                                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
