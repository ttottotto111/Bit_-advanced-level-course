//---------------------------------------------
// XamlCruncher.cs (c) 2006 by Charles Petzold
//---------------------------------------------
using System;
using System.IO;                            // StringReader�� ���� ������
using System.Text;                          // StringBuilder�� ���� ������
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;   // StatusBarItem�� ���� ������
using System.Windows.Input;
using System.Windows.Markup;                // XamlReader.Load�� ���� ������
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading;     // DispatcherUnhandledExceptionEventArgs�� ���� ������
using System.Xml;                           // XmlTextReader�� ���� ������

namespace Petzold.XamlCruncher
{
    class XamlCruncher : Petzold.NotepadClone.NotepadClone
    {
        Frame frameParent;          // XAML�� ���� ������ ��ü�� �����ֱ� ���� Frame
        Window win;                 // XAML�κ��� ������ Window
        StatusBarItem statusParse;  // �Ľ� ������ ������ ������
        int tabspaces = 4;          // �� Ű�� ������ ��

        // �ε�� ����
        XamlCruncherSettings settingsXaml;

        // �޴� �׸� ����
        XamlOrientationMenuItem itemOrientation;
        bool isSuspendParsing = false;

        [STAThread]
        public new static void Main()
        {
            Application app = new Application();
            app.ShutdownMode = ShutdownMode.OnMainWindowClose;
            app.Run(new XamlCruncher());
        }
        // �Ľ� �ߴ��� ���� public ������Ƽ
        public bool IsSuspendParsing
        {
            set { isSuspendParsing = value; }
            get { return isSuspendParsing; }
        }
        // ������
        public XamlCruncher()
        {
            // File Open�� Save ��ȭ���ڸ� ���� ����
            strFilter = "XAML Files(*.xaml)|*.xaml|All Files(*.*)|*.*";

            // DockPanel�� ã�� �� �װͿ��� TextBox�� ����
            DockPanel dock = txtbox.Parent as DockPanel;
            dock.Children.Remove(txtbox);

            // 3���� ���� ������ ������ Grid�� ����, ũ��� ��� 0
            Grid grid = new Grid();
            dock.Children.Add(grid);

            for (int i = 0; i < 3; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = new GridLength(0);
                grid.RowDefinitions.Add(rowdef);

                ColumnDefinition coldef = new ColumnDefinition();
                coldef.Width = new GridLength(0);
                grid.ColumnDefinitions.Add(coldef);
            }

            // ù° ���� ���� ũ�⸦ 100���� �ʱ�ȭ
            grid.RowDefinitions[0].Height = 
                        new GridLength(100, GridUnitType.Star);
            grid.ColumnDefinitions[0].Width = 
                        new GridLength(100, GridUnitType.Star);

            // 2���� GridSplitter ��Ʈ���� Grid�� �߰�
            GridSplitter split = new GridSplitter();
            split.HorizontalAlignment = HorizontalAlignment.Stretch;
            split.VerticalAlignment = VerticalAlignment.Center;
            split.Height = 6;
            grid.Children.Add(split);
            Grid.SetRow(split, 1);
            Grid.SetColumn(split, 0);
            Grid.SetColumnSpan(split, 3);

            split = new GridSplitter();
            split.HorizontalAlignment = HorizontalAlignment.Center;
            split.VerticalAlignment = VerticalAlignment.Stretch;
            split.Width = 6;
            grid.Children.Add(split);
            Grid.SetRow(split, 0);
            Grid.SetColumn(split, 1);
            Grid.SetRowSpan(split, 3);

            // XAML ��ü�� �����ֱ� ���� Frame ����
            frameParent = new Frame();
            frameParent.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            grid.Children.Add(frameParent);

            // TextBox�� Grid�� ����
            txtbox.TextChanged += TextBoxOnTextChanged;
            grid.Children.Add(txtbox);

            // �ε�� ������ XamlCruncherSettings�� �� ��ȯ
            settingsXaml = (XamlCruncherSettings)settings;

            // Xaml �޴��� �ֻ��� �޴��� ����
            MenuItem itemXaml = new MenuItem();
            itemXaml.Header = "_Xaml";
            menu.Items.Insert(menu.Items.Count - 1, itemXaml);

            // XamlOrientationMenuItem�� �����ϰ� �޴��� �߰�
            itemOrientation =
                new XamlOrientationMenuItem(grid, txtbox, frameParent);
            itemOrientation.Orientation = settingsXaml.Orientation;
            itemXaml.Items.Add(itemOrientation);

            // �ǿ� ������ �����ϱ� ���� �޴�
            MenuItem itemTabs = new MenuItem();
            itemTabs.Header = "_Tab Spaces...";
            itemTabs.Click += TabSpacesOnClick;
            itemXaml.Items.Add(itemTabs);

            // �Ľ��� �ߴ��ϱ� ���� �޴�
            MenuItem itemNoParse = new MenuItem();
            itemNoParse.Header = "_Suspend Parsing";
            itemNoParse.IsCheckable = true;
            itemNoParse.SetBinding(MenuItem.IsCheckedProperty,
                                        "IsSuspendParsing");
            itemNoParse.DataContext = this;
            itemXaml.Items.Add(itemNoParse);

            // Reparse�ϱ� ���� Ŀ�ǵ�
            InputGestureCollection collGest = new InputGestureCollection();
            collGest.Add(new KeyGesture(Key.F6));
            RoutedUICommand commReparse =
                new RoutedUICommand("_Reparse", "Reparse",
                                    GetType(), collGest);

            // Reparse�� ���� �޴�
            MenuItem itemReparse = new MenuItem();
            itemReparse.Command = commReparse;
            itemXaml.Items.Add(itemReparse);

            // Reparse�� ���� Ŀ�ǵ� ���ε�
            CommandBindings.Add(new CommandBinding(commReparse,
                                ReparseOnExecuted));

            // â�� �����ֱ� ���� Ŀ�ǵ�
            collGest = new InputGestureCollection();
            collGest.Add(new KeyGesture(Key.F7));
            RoutedUICommand commShowWin = 
                new RoutedUICommand("Show _Window", "ShowWindow",
                                    GetType(), collGest);

            // â�� �����ֱ� ���� �޴�
            MenuItem itemShowWin = new MenuItem();
            itemShowWin.Command = commShowWin;
            itemXaml.Items.Add(itemShowWin);

            // â�� �����ֱ� ���� Ŀ�ǵ� ���ε�
            CommandBindings.Add(new CommandBinding(commShowWin,
                            ShowWindowOnExecuted, ShowWindowCanExecute));

            // Save as Startup Document �޴�
            MenuItem itemTemplate = new MenuItem();
            itemTemplate.Header = "Save as Startup _Document";
            itemTemplate.Click += NewStartupOnClick;
            itemXaml.Items.Add(itemTemplate);

            // Help �޴� �� ������ ����
            MenuItem itemXamlHelp = new MenuItem();
            itemXamlHelp.Header = "_Help...";
            itemXamlHelp.Click += HelpOnClick;
            MenuItem itemHelp = (MenuItem)menu.Items[menu.Items.Count - 1];
            itemHelp.Items.Insert(0, itemXamlHelp);

            // ���ο� StatusBar �׸�
            statusParse = new StatusBarItem();
            status.Items.Insert(0, statusParse);
            status.Visibility = Visibility.Visible;

            // ��Ÿ ���� ��Ȳ�鿡 ���� �ڵ鷯�� ����
            // �ڵ尡 ��ġ�� ���ο� Ư¡�̳� ��ȭ�� ǥ��
            Dispatcher.UnhandledException += DispatcherOnUnhandledException;
        }
		// NewOnExecute �ڵ鷯�� �������̵��� TextBox�� StartupDocument�� ����
        protected override void NewOnExecute(object sender, 
                                             ExecutedRoutedEventArgs args)
        {
            base.NewOnExecute(sender, args);

            string str = ((XamlCruncherSettings)settings).StartupDocument;

            // ���� Replace �޼ҵ尡 \r\n�� �ùٸ��� �����ϰ� ��
            str = str.Replace("\r\n", "\n");

            // ���� �ǵ带 ĳ���� ����/���� �ǵ�� �ٲ�
            str = str.Replace("\n", "\r\n"); 
            txtbox.Text = str;
            isFileDirty = false;
        }
        // XamlCruncherSettings�� �ε��ϰ� LoadSettings�� �������̵�
        protected override object LoadSettings()
        {
            return XamlCruncherSettings.Load(typeof(XamlCruncherSettings), 
                                           strAppData);
        }
        // �޴����� Orientation�� �����ϴ� OnClosed �������̵�
        protected override void OnClosed(EventArgs args)
        {
            settingsXaml.Orientation = itemOrientation.Orientation; 
            base.OnClosed(args);
        }
        // XamlCruncherSettings ��ü�� �����ϴ� SaveSettings�� �������̵�
        protected override void SaveSettings()
        {
            ((XamlCruncherSettings)settings).Save(strAppData);
        }
        // Tab Spaces �޴� �ڵ鷯
        void TabSpacesOnClick(object sender, RoutedEventArgs args)
        {
            XamlTabSpacesDialog dlg = new XamlTabSpacesDialog();
            dlg.Owner = this;
            dlg.TabSpaces = settingsXaml.TabSpaces;

            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                settingsXaml.TabSpaces = dlg.TabSpaces;
            }
        }
        // Reparse �޴� �ڵ鷯
        void ReparseOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            Parse();
        }

        // Show Window �޴� �ڵ鷯
        void ShowWindowCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = (win != null);
        }
        void ShowWindowOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            if (win != null)
                win.Show();
        }
        // Save as New Startup Document �޴� �ڵ鷯
        void NewStartupOnClick(object sender, RoutedEventArgs args)
        {
            ((XamlCruncherSettings)settings).StartupDocument = txtbox.Text;
        }
        // Help �޴� �ڵ鷯
        void HelpOnClick(object sender, RoutedEventArgs args)
        {
            Uri uri = new Uri("pack://application:,,,/XamlCruncherHelp.xaml");
            Stream stream = Application.GetResourceStream(uri).Stream;

            Window win = new Window();
            win.Title = "XAML Cruncher Help";
            win.Content = XamlReader.Load(stream);
            win.Show();
        }
        // OnPreviewKeyDown�� �� Ű�� �������� ��ü
        protected override void OnPreviewKeyDown(KeyEventArgs args)
        {
            base.OnPreviewKeyDown(args);

            if (args.Source == txtbox && args.Key == Key.Tab)
            {
                string strInsert = new string(' ', tabspaces);
                int iChar = txtbox.SelectionStart;
                int iLine = txtbox.GetLineIndexFromCharacterIndex(iChar);

                if (iLine != -1)
                {
                    int iCol = iChar - txtbox.GetCharacterIndexFromLineIndex(iLine);
                    strInsert = new string(' ', 
                        settingsXaml.TabSpaces - iCol % settingsXaml.TabSpaces);
                }

                txtbox.SelectedText = strInsert;
                txtbox.CaretIndex = txtbox.SelectionStart + txtbox.SelectionLength;
                args.Handled = true;
            }
        }
        // TextBoxOnTextChanged �� XAML�� �Ľ��� ����
        void TextBoxOnTextChanged(object sender, TextChangedEventArgs args)
        {
            if (IsSuspendParsing)
                txtbox.Foreground = SystemColors.WindowTextBrush;
            else
                Parse();
        }

        // �Ϲ����� Parse �޼ҵ��̸�, Reparse �޴��� �� �޼ҵ带 ���� ȣ����
        void Parse()
        {
            StringReader strreader = new StringReader(txtbox.Text);
            XmlTextReader xmlreader = new XmlTextReader(strreader);

            try
            {
                object obj = XamlReader.Load(xmlreader);
                txtbox.Foreground = SystemColors.WindowTextBrush;

                if (obj is Window)
                {
                    win = obj as Window;
                    statusParse.Content = "Press F7 to display Window";
                }
                else
                {
                    win = null;
                    frameParent.Content = obj; 
                    statusParse.Content = "OK";
                }
            }
            catch (Exception exc)
            {
                txtbox.Foreground = Brushes.Red;
                statusParse.Content = exc.Message;
            }
        }
        // XAML ��ü�� ���� ��Ȳ���� ���� �� �䱸�Ǵ� UnhandledException �ڵ鷯
        void DispatcherOnUnhandledException(object sender, 
                                    DispatcherUnhandledExceptionEventArgs args)
        {
            statusParse.Content = "Unhandled Exception: " + args.Exception.Message;
            args.Handled = true;
        }
    }
}
