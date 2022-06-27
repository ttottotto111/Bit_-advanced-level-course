//---------------------------------------------
// NotepadClone.cs (c) 2006 by Charles Petzold
//---------------------------------------------

/*************************************************
 * Ŭ���� �� : NotepadClone
 * ��     �� : string strAppTitle (���α׷��� Ÿ��Ʋ�� �̸�)
 *             string strAppData  (���� ������ ��ü ���� �̸�)
 *             NotepadCloneSettings settings (����)
 *             bool isFileDirty = false (���� ���� Ȯ���� ���� �÷���)
 *             Menu menu          (�޴� ��Ʈ��)         
               TextBox txtbox     (�ؽ�Ʈ�ڽ� ��Ʈ��)       
               StatusBar status   (���¹� ��Ʈ��)
 *             string strLoadedFile (�ҷ��� ������ ��ü �̸�)
 *             StatusBarItem statLineCol (�ٰ� �� ����)
 * ��     �� : ������ ���� �� �ҷ����� �� ���¹� ǥ��
**************************************************/

using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.NotepadClone
{
    public partial class NotepadClone : Window
    {

        // settings = ������ ����Ǹ鼭 �����س��� ����

        protected string strAppTitle;       // ���α׷��� Ÿ��Ʋ�� �̸�
        protected string strAppData;        // ���� ������ ��ü ���� �̸�
        protected NotepadCloneSettings settings;    // ����
        protected bool isFileDirty = false; // ���� ���� Ȯ���� ���� �÷���

        // ���� �����쿡�� ���Ǵ� ��Ʈ��
        protected Menu menu;                // �޴� ��Ʈ��
        protected TextBox txtbox;           // �ؽ�Ʈ�ڽ� ��Ʈ��
        protected StatusBar status;         // ���¹� ��Ʈ��

        string strLoadedFile;               // �ҷ��� ������ ��ü �̸�
        StatusBarItem statLineCol;          // �ٰ� �� ����

        [STAThread]
        public static void Main()
        {
            Application app = new Application();                // Application ����
            app.ShutdownMode = ShutdownMode.OnMainWindowClose;
            // ���â�� ���� ���� ShutdownMode�� ShutdownMode.OnMainWindowClose ���� �ϸ� ���â(Ȥ�� MessageBox ��)�� Ȯ�� ��ư�� ���� 
            // ���â�� �����ϸ� ���ٸ� Shutdown ����� ������ �ʾƵ� �ش� Application�� ����ȴ�.
            app.Run(new NotepadClone());
        }
        public NotepadClone()
        {
            // �Ӽ��� �����ϱ� ���� executing assembly�� ����
            Assembly asmbly = Assembly.GetExecutingAssembly();

            // strAppTitle(���α׷��� Ÿ��Ʋ�� �̸�) �ʵ带 �����ϱ� ���� AssemblyTitle �Ӽ��� ����
            // Assembly�� ����� ����� ���� Ư���� �迭�� �˻��� Title�� �ִ´�
            AssemblyTitleAttribute title = (AssemblyTitleAttribute)asmbly.
                GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0];
            strAppTitle = title.Title;  

            // strAppData(��ü�����̸�) ���� �̸��� �����ϱ� ���� AssemblyProduct �Ӽ��� ����
            AssemblyProductAttribute product = (AssemblyProductAttribute)asmbly.
                GetCustomAttributes(typeof(AssemblyProductAttribute), false)[0];
            // GetFolderPath�� ������ ���������� �ĺ��Ǵ� �ý��� Ư�� ������ ��θ� �������� Path.Combine���� ���ڿ� �迭�� �� ��η� ����
            strAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Petzold\\" + product.Product + "\\" + product.Product + ".Settings.xml");


            DockPanel dock = new DockPanel();   // DockPanel ����
            Content = dock;                     // Content ������Ƽ�� DockPanel ��ü �Ҵ�

            menu = new Menu();                  // �޴� ����
            dock.Children.Add(menu);            // DockPanel�� �ڽļӼ� ���� Menu �߰�
            DockPanel.SetDock(menu, Dock.Top);  // Menu�� ��ܺκп� ����
 
            status = new StatusBar();           // ���¹� ����
            dock.Children.Add(status);          // DockPanel�� �ڽļӼ� ���� ���¹� �߰�
            DockPanel.SetDock(status, Dock.Bottom); // ���¹ٸ� �ϴܺκп� ����

            statLineCol = new StatusBarItem();  // ���� ���� �����ֱ� ���� StatusBarItem ����
            statLineCol.HorizontalAlignment = HorizontalAlignment.Right;    // statLineCol�� ��ġ�� �θ��ҿ� �Ҵ�� ���̾ƿ� ������ �����ʿ� �����
            status.Items.Add(statLineCol);      // ���¹ٿ� statLineCol �߰�
            DockPanel.SetDock(statLineCol, Dock.Right); // statLineCol�� �����ʺκп� ����
 
           // Ŭ���̾�Ʈ ������ ���� �κ��� ä�� �ؽ�Ʈ �ڽ� ����
            txtbox = new TextBox();             // �ؽ�Ʈ�ڽ� ����
            txtbox.AcceptsReturn = true;        // �ؽ�Ʈ�ڽ��� �� �ٲ� ���ڸ� ����� �� �ִ�
            txtbox.AcceptsTab = true;           // TabŰ�� ���� �� �� ������ ���� ���� ��Ʈ�ѷ� ��Ŀ���� �̵��ϴ� ��� �ش� 
                                                // ��Ʈ�ѿ� �� ���ڸ� �Է����� ���θ� ��Ÿ���� �� ����
            txtbox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;  // ���� ��ũ�� ���븦 �ڵ����� ����
            txtbox.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto; // ���� ��ũ�� ���븦 �ڵ����� ����
            txtbox.TextChanged += TextBoxOnTextChanged; // �ؽ�Ʈ�ڽ��� �����Է��� �߻��ϸ� TextBoxOnTextChanged �̺�Ʈ ȣ��
            txtbox.SelectionChanged += TextBoxOnSelectionChanged;   // �ؽ�Ʈ ���� ������ ����� ��쿡 TextBoxOnSelectionChanged �̺�Ʈ ȣ��
            dock.Children.Add(txtbox);          // DockPanel�� �ڽļӼ� ���� �ؽ�Ʈ�ڽ� �߰�

            // ��� ž ���� �޴� �׸� ����
            AddFileMenu(menu);          // in NotepadClone.File.cs
            AddEditMenu(menu);          // in NotepadClone.Edit.cs
            AddFormatMenu(menu);        // in NotepadClone.Format.cs
            AddViewMenu(menu);          // in NotepadClone.View.cs
            AddHelpMenu(menu);          // in NotepadClone.Help.cs

            // ������ ����Ǹ鼭 �����س��� ������ �ҷ��ͼ� settings�� ����
            settings = (NotepadCloneSettings) LoadSettings();

            // ����� ������ Windowstate�� ����
            WindowState = settings.WindowState;
            
            if (settings.RestoreBounds != Rect.Empty)
            {
                Left = settings.RestoreBounds.Left;
                Top = settings.RestoreBounds.Top;
                Width = settings.RestoreBounds.Width;
                Height = settings.RestoreBounds.Height;
            }

            // Rect�� ������� ������ RestoreBounds(â�� ũ��� ��ġ)�� ����
            if (settings.RestoreBounds != Rect.Empty)
            {
                Left = settings.RestoreBounds.Left;
                Top = settings.RestoreBounds.Top;
                Width = settings.RestoreBounds.Width;
                Height = settings.RestoreBounds.Height;
            }

            txtbox.TextWrapping = settings.TextWrapping;                // �ؽ�Ʈ�ڽ��� settings�� �ٹٲ� ����� ����
            txtbox.FontFamily = new FontFamily(settings.FontFamily);    // �ؽ�Ʈ�ڽ��� �۲��йи��� settings�� �۲��йи��� ����
            txtbox.FontStyle = (FontStyle)new FontStyleConverter().    //  �ؽ�Ʈ�ڽ��� �۲ý�Ÿ���� settings�� �۲ý�Ÿ�Ϸ� ����
                                ConvertFromString(settings.FontStyle);
            txtbox.FontWeight = (FontWeight)new FontWeightConverter(). // �ؽ�Ʈ�ڽ��� �۲õβ��� settings�� �۲õβ��� ����
                                ConvertFromString(settings.FontWeight);
            txtbox.FontStretch = (FontStretch)new FontStretchConverter(). // �ؽ�Ʈ�ڽ��� �۲ô��̱⸦ settings�� �۲ô��̱�� ����   
                                ConvertFromString(settings.FontStretch);
            txtbox.FontSize = settings.FontSize;                            // �ؽ�Ʈ�ڽ��� �۲�ũ�⸦ settings�� �۲�ũ��� ����

            // Loaded �̺�Ʈ �ڵ鷯 ����
            Loaded += WindowOnLoaded;

            // �ؽ�Ʈ�ڽ��� ��Ŀ�� ����
            txtbox.Focus();
        }
        // �����ڸ� ȣ������ �� ������ �ҷ����̴� �޼ҵ带 �������̵�
        protected virtual object LoadSettings()
        {
            return NotepadCloneSettings.Load(typeof(NotepadCloneSettings),
                                             strAppData);
        }

        // Loaded �̺�Ʈ�� ���� �̺�Ʈ �ڵ鷯 : New Ŀ�ǵ�� ����  
        // ��� �࿡�� ������ �о� ���� �� ����
        void WindowOnLoaded(object sender, RoutedEventArgs args)
        {
            // ���� ����
            ApplicationCommands.New.Execute(null, this);

            // ��� �� ���ڸ� ����
            string[] strArgs = Environment.GetCommandLineArgs();

            if (strArgs.Length > 1)         // strArgs�� ���̰� 1���� ���� ���
            {
                if (File.Exists(strArgs[1]))    // strArgs[���α׷��̸�]�� ������ ������ �ִٸ�
                {
                    LoadFile(strArgs[1]);       // ���� �ε�
                }
                else
                {
                    // ���� ������ ���ٸ� �޼��� �ڽ��� �����
                    MessageBoxResult result = 
                        MessageBox.Show("Cannot find the " + 
                            Path.GetFileName(strArgs[1]) + " file.\r\n\r\n" +
                            "Do you want to create a new file?",
                            strAppTitle, MessageBoxButton.YesNoCancel,      // Yes , No , Cancle â
                            MessageBoxImage.Question);                      // ����ǥ ������ ǥ��
                    
                    // ����ڰ� Cancle�� Ŭ���ϸ� �����츦 ����
                    if (result == MessageBoxResult.Cancel)
                        Close();

                    
                    else if (result == MessageBoxResult.Yes)    // Yes�̸� �����̶��
                    {
                        try
                        {
                            // ������ �����ϰ� ����
                            File.Create(strLoadedFile = strArgs[1]).Close();
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Error on File Creation: " + 
                                            exc.Message, strAppTitle,
                                MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                        UpdateTitle();
                    }
                    // No�̸� �ƹ��۾� ����
                }
            }
        }
        
        // OnClosing �̺�Ʈ
        protected override void OnClosing(CancelEventArgs args)
        {
            base.OnClosing(args);
            args.Cancel = !OkToTrash();             // ������ ������ ������ Ȯ��
            settings.RestoreBounds = RestoreBounds; // ����â���� ����
        }
        // OnClosed �̺�Ʈ
        protected override void OnClosed(EventArgs args)
        {
            base.OnClosed(args);
            settings.WindowState = WindowState;                 // setting.WindowState�� �ּ�ȭ �Ǵ� �ִ�ȭ�ϱ� ���� â�� Ū��� ��ġ ����
            settings.TextWrapping = txtbox.TextWrapping;        // settings�� �ؽ�Ʈ�ڽ��� �ٹٲ� ����� ����

            settings.FontFamily = txtbox.FontFamily.ToString(); // �ؽ�Ʈ�ڽ��� ��Ʈ�йи��� string ������� settings�� ��Ʈ�йи��� ����
            settings.FontStyle = 
                new FontStyleConverter().ConvertToString(txtbox.FontStyle); // �ؽ�Ʈ�ڽ��� �ִ� �۲� ��Ÿ���� string������� settings�� �۲ý�Ÿ�Ϸ� ����
            settings.FontWeight = 
                new FontWeightConverter().ConvertToString(txtbox.FontWeight); // �ؽ�Ʈ�ڽ��� �ִ� �۲õβ��� string ������� settings�� �۲õβ��� ����
            settings.FontStretch = 
                new FontStretchConverter().ConvertToString(txtbox.FontStretch); // �ؽ�Ʈ�ڽ��� �ִ� �۲ô��̱⸦ string ������� settings�� �۲ô��̱�� ����
            settings.FontSize = txtbox.FontSize;                // �ؽ�Ʈ�ڽ��� �ִ� �۲�ũ�⸦ settings�� �۲�ũ��� ����

            SaveSettings(); // ����
        }

        // settings ��ü�� Savs�� ȣ���ϱ� ���� �޼ҵ带 �������̵�
        protected virtual void SaveSettings()
        {
            // ��ü�����̸��� ����
            settings.Save(strAppData);
        }
        
        // ���ϸ��̳� Untitled�� ���
        protected void UpdateTitle()
        {
            if (strLoadedFile == null)                  //  �ҷ��� ������ ���ٸ�
                Title = "Untitled - " + strAppTitle;    // Title�� Untitled+strAppTitle ���
            else
                Title = Path.GetFileName(strLoadedFile) + " - " + strAppTitle;  // �ε�� �����̸� +strAppTitle ���ͼ� ���
        }
        
        void TextBoxOnTextChanged(object sender, RoutedEventArgs args)
        {
            //�ؽ�Ʈ�ڽ��� �ؽ�Ʈ�� ����Ǹ� ���ϵ��͸��� true�� ����
            isFileDirty = true;
        }
       
        void TextBoxOnSelectionChanged(object sender, RoutedEventArgs args)
        {
            // selectionStart�� �ؽ�Ʈ�� �����Ѱ�� ������ ���۵� ��ġ
            int iChar = txtbox.SelectionStart;
            // iLine �� ���� Ŀ���� ��ġ���� ���� ������ġ�� �����ͼ� ����
            int iLine = txtbox.GetLineIndexFromCharacterIndex(iChar);

            // ���� �˻�
            if (iLine == -1)
            {
                statLineCol.Content = "";
                return;
            }

            //���� ���� ��ġ�� ���� �տ� �ִ� �ؽ�Ʈ�� ��ġ�� �˷��ְ�
            int iCol = iChar - txtbox.GetCharacterIndexFromLineIndex(iLine);
            // ���
            string str = String.Format("Line {0} Col {1}", iLine + 1, iCol + 1);

            if (txtbox.SelectionLength > 0)
            {
                iChar += txtbox.SelectionLength;
                iLine = txtbox.GetLineIndexFromCharacterIndex(iChar);
                iCol = iChar - txtbox.GetCharacterIndexFromLineIndex(iLine);
                str += String.Format(" - Line {0} Col {1}", iLine + 1, iCol + 1);
            }
            statLineCol.Content = str;
        }
    }
}
