//--------------------------------------------------
// NotepadClone.File.cs (c) 2011 by ������, �̱�ȣ
//--------------------------------------------------

/*************************************************
 * Ŭ���� �� : NotepadClone
 * ��     �� : string strFilter(���� ����, ���忡�� ���̴� ��������)
 * ��     �� : �ش� ���α׷��� MainMenu �� File�� �����޴��� ���θ����,����, ����, 
 *             �ٸ��̸����� ����, ����������, �μ�, ���� ����� �����Ѵ�.
**************************************************/


using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Printing;

namespace Petzold.NotepadClone
{
    public partial class NotepadClone : Window
    {
        // Filter for File Open and Save dialog boxes.
        // ��ȭ���ڿ��� ���� ����� ������ ���� ����
        protected string strFilter =
                        "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";

        // File �޴� �ʱ�ȭ
        void AddFileMenu(Menu menu)
        {
            //============================================================
            // ž ���� ���� �׸� ����
            //============================================================
            MenuItem itemFile = new MenuItem();
            // ��� ����
            itemFile.Header = "_File";
            // Main �޴��� ������(Top Menu) ����
            menu.Items.Add(itemFile);

            // New �޴� �׸� ���� �� Top�޴� File�� �߰�
            MenuItem itemNew = new MenuItem();
            itemNew.Header = "_New";
            itemNew.Command = ApplicationCommands.New;
            itemFile.Items.Add(itemNew);
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.New, NewOnExecute));

            // Open  �޴� �׸� ���� �� Top�޴� File�� �߰�
            MenuItem itemOpen = new MenuItem();
            itemOpen.Header = "_Open...";
            // Command ����
            itemOpen.Command = ApplicationCommands.Open;
            itemFile.Items.Add(itemOpen);
            // CommandBing�� ���� �̺�Ʈ ��� Open�� OpenOnExecute�Լ� ����
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Open, OpenOnExecute));

            // Save  �޴� �׸� ���� �� Top�޴� File�� �߰�
            MenuItem itemSave = new MenuItem();
            itemSave.Header = "_Save";
            itemSave.Command = ApplicationCommands.Save;
            itemFile.Items.Add(itemSave);
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Save, SaveOnExecute));

            // Save As  �޴� �׸� ���� �� Top�޴� File�� �߰�
            MenuItem itemSaveAs = new MenuItem();
            itemSaveAs.Header = "Save _As...";
            itemSaveAs.Command = ApplicationCommands.SaveAs;
            itemFile.Items.Add(itemSaveAs);
            CommandBindings.Add(
                new CommandBinding(ApplicationCommands.SaveAs, SaveAsOnExecute));

            // ������(Separators) ����
            itemFile.Items.Add(new Separator());
            
            // PrintMenu�� �߰��ϴ� �Լ� ȣ��(1������ �˾Ƽ�/ NotepadClone.Print.cs�� ����)
            AddPrintMenuItems(itemFile);
            itemFile.Items.Add(new Separator());

            // Exit  �޴� �׸� ���� �� Top�޴� File�� �߰�
            MenuItem itemExit = new MenuItem();
            itemExit.Header = "E_xit";
            itemExit.Click += ExitOnClick;
            itemFile.Items.Add(itemExit);
        }

        // '���θ����' �޴� �Լ�
        // File New command: Start with empty TextBox.
        protected virtual void NewOnExecute(object sender, 
                                            ExecutedRoutedEventArgs args)
        {
            // ������ ���� ������ ����� �Լ� ȣ��
            if (!OkToTrash())
                return;

            txtbox.Text = "";       // �ؽ�Ʈ ���� �ʱ�ȭ
            strLoadedFile = null;   // ���ϸ�(FullPath ����) �ʱ�ȭ
            isFileDirty = false;    // ���� ����Ȯ���� ���� �÷��׸� false�� ����
            
            UpdateTitle();          // Ÿ��Ʋ�� �����ϴ� �Լ� ȣ��(NotepadClone.cs�� ����)
        }

        // '����' �޴� �Լ�
        // File Open command: Display dialog box and load file.
        void OpenOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            if (!OkToTrash())
                return;


            OpenFileDialog dlg = new OpenFileDialog();      // ���Ͽ��� ���̾�α� ����
            dlg.Filter = strFilter;                         // �������� ����

            if ((bool)dlg.ShowDialog(this))                 // ���Ͽ��� ���̾�α� �����ֱ�
            {
                LoadFile(dlg.FileName);                     // ���� �ҷ����� �Լ� ȣ��
            }
        }

        // '����' �޴� �Լ�
        // File Save command: Possibly execute SaveAsExecute.
        void SaveOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            if (strLoadedFile == null || strLoadedFile.Length == 0)
                DisplaySaveDialog("");                      // ������̾�α� ���� �Լ� ȣ��
            else
                SaveFile(strLoadedFile);                    // ���� �����ϴ� ���Ͽ� �ٽ� �����ϴ� �Լ� ȣ��
        }

        // '�ٸ��̸����� ����' �޴� �Լ�
        // File Save As command; display dialog box and save file.
        void SaveAsOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            DisplaySaveDialog(strLoadedFile);               // ������̾󸣰� ���� �Լ� ȣ��
        }

        // �������� ���̾�α� ���� �Լ�(������ �� true����, ����ҽ� false����)
        // Display Save dialog box and return true if file is saved.
        bool DisplaySaveDialog(string strFileName)
        {
            SaveFileDialog dlg = new SaveFileDialog();      // �������� ���̾�α� ��ü ����
            dlg.Filter = strFilter;                         // �������� ����
            dlg.FileName = strFileName;                     // �����̸� ����

            if ((bool)dlg.ShowDialog(this))                 // ���̾�α� ����(����)������ true����)
            {
                SaveFile(dlg.FileName);                     // dlg�� ������ FileName���� Savefileȣ��
                return true;
            }
            return false;           // for OkToTrash.       // ��� ������ ��
        }

        // '����' �޴� �Լ�
        // File Exit command: Just close the window.
        void ExitOnClick(object sender, RoutedEventArgs args)
        {
            // ���α׷� ���� �Լ� ȣ��
            Close();
        }

        // ���θ���⳪ ���� ��� ���̴� �Լ�(�ؽ�Ʈ ������ ����Ǹ� isFileDirty�� false�� ����)
        // OkToTrash returns true if the TextBox contents need not be saved.
        bool OkToTrash()
        {
            if (!isFileDirty)   // ���丮�� �������� �ʴ´ٸ�
                return true;    // true ����

            // ���Ͽ� ��ȭ�� ������ �� MessageBox�� ����� MessageBoxResult�� ���ϰ� ����
            MessageBoxResult result =
                MessageBox.Show("The text in the file " + strLoadedFile + 
                                " has changed\n\n" +
                                "Do you want to save the changes?", 
                                strAppTitle,
                                MessageBoxButton.YesNoCancel,   // YesNoCancel ����
                                MessageBoxImage.Question,       // image�� Questin �̹���
                                MessageBoxResult.Yes);          //  ��(Y)�� Focus ����

            // MessageBoxResult - Cancel / ��� ��ư�� ������ ��
            if (result == MessageBoxResult.Cancel)
                return false;

            // MessageBoxResult - No / �ƴϿ� ��ư�� ������ ��
            else if (result == MessageBoxResult.No)
                return true;

                // MessageBoxResult - Yes / �� ��ư�� ������ ��
            else // result == MessageBoxResult.Yes
            {
                // ��������
                if (strLoadedFile != null && strLoadedFile.Length > 0)
                    return SaveFile(strLoadedFile);


                return DisplaySaveDialog("");
            }
        }

        // ���� ���ϸ����� Text�� �߰��ϴ� �Լ�
        // LoadFile method possibly displays message box if error. 
        void LoadFile(string strFileName)
        {
            try
            {
                txtbox.Text = File.ReadAllText(strFileName);
            }
            catch (Exception exc) // ����ó�� �߻���(*.*�� �ؼ� ���� ������ ������ ���..)
            {
                MessageBox.Show("Error on File Open: " + exc.Message, strAppTitle,
                                MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return;
            }
            strLoadedFile = strFileName;    // ��� ���
            UpdateTitle();                  // Ÿ��Ʋ ����
            txtbox.SelectionStart = 0;      // TextBox ������ 0���� ����
            txtbox.SelectionLength = 0;     // TextBox���ڿ� ���� 0���� ����
            isFileDirty = false;            // ���� ���� Ȯ�� �÷��� false�� ����
        }
        
        // ���� ���ϸ����� ���������� ȣ���ϴ� �Լ�
        // SaveFile method possibly displays message box if error.
        bool SaveFile(string strFileName)
        {
            try
            {
                // �ش� ����(���)�� ������ ����
                File.WriteAllText(strFileName, txtbox.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error on File Save" + exc.Message, strAppTitle,
                                MessageBoxButton.OK, MessageBoxImage.Asterisk);
                return false;
            }
            strLoadedFile = strFileName;
            UpdateTitle();
            isFileDirty = false;
            return true;
        }
    }
}
