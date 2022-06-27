//----------------------------------------------------
// DumpControlTemplate.cs (c) 2006 by Charles Petzold
//----------------------------------------------------
using System;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace Petzold.DumpControlTemplate
{
    public partial class DumpControlTemplate : Window
    {
        Control ctrl;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DumpControlTemplate());
        }
        public DumpControlTemplate()
        {
            InitializeComponent();
        }

        // Control �޴��� Ŭ������ �� �߻��ϴ� �̺�Ʈ �ڵ鷯
        void ControlItemOnClick(object sender, RoutedEventArgs args)
        {
            // Remove any existing child from the first row of the Grid.
            for (int i = 0; i < grid.Children.Count; i++)
                if (Grid.GetRow(grid.Children[i]) == 0)
                {
                    grid.Children.Remove(grid.Children[i]);
                    break;
                }

            // TextBox�� ���
            txtbox.Text = "";

            // Ŭ���� �޴��� Control Ŭ������ ������
            MenuItem item = args.Source as MenuItem;
            Type typ = (Type)item.Tag;

            // ���õ� Ÿ���� ��ü�� �����ϱ� ���� �غ�
            ConstructorInfo info = typ.GetConstructor(System.Type.EmptyTypes);
            
            // ���õ� Ÿ���� ��ü�� ����
            try
            {
                //Control ctrl;
                ctrl = (Control)info.Invoke(null);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Title);
                return;
            }

            //������ ��ü�� �׸��忡 ����
            //�����ϸ� ������ ��ü�� Window
            try
            {
                grid.Children.Add(ctrl);
            }
            catch
            {
                if (ctrl is Window)
                    (ctrl as Window).Show();
                else
                    return;
            }
            Title = Title.Remove(Title.IndexOf('-')) + "- " + typ.Name;
        }
        // Dump�޴��� ������ �׸��� Ȱ��ȭ
        void DumpOnOpened(object sender, RoutedEventArgs args)
        {
            itemTemplate.IsEnabled = ctrl != null;
            itemItemsPanel.IsEnabled = ctrl != null && ctrl is ItemsControl;
        }
        // ControlTemplate ������Ƽ�� ������ Template��ü�� XAML�� ������
        void DumpTemplateOnClick(object sender, RoutedEventArgs args)
        {
            if (ctrl != null)
                Dump(ctrl.Template);
        }
        // ItemsPanel ������Ƽ�� ������ ItemsPanelTemplate ��ü�� XAML�� ������
        void DumpItemsPanelOnClick(object sender, RoutedEventArgs args)
        {
            if (ctrl != null && ctrl is ItemsControl)
                Dump((ctrl as ItemsControl).ItemsPanel);
        }
        // ���ø��� XMAL�� ������
        void Dump(FrameworkTemplate template)
        {
            if (template != null)
            {
                // XAML�� TextBox�� ������
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true; //�鿩����
                settings.IndentChars = new string(' ', 4);
                settings.NewLineOnAttributes = true;    //���� ����

                StringBuilder strbuild = new StringBuilder();
                XmlWriter xmlwrite = XmlWriter.Create(strbuild, settings);

                try
                {
                    XamlWriter.Save(template, xmlwrite);
                    txtbox.Text = strbuild.ToString();
                }
                catch (Exception exc)
                {
                    txtbox.Text = exc.Message;
                }
            }
            else
                txtbox.Text = "no template";
        }
    }
}
