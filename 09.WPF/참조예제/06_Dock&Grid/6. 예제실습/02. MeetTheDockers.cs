//-----------------------------------------------
// MeetTheDockers.cs (c) 2006 by Charles Petzold
//-----------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;          // ��������
using System.Windows.Controls.Primitives; //StatusBar, StatusBarItem

namespace Petzold.MeetTheDockers
{
    public class MeetTheDockers : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new MeetTheDockers());
        }
        public MeetTheDockers()
        {
            Title = "Meet the Dockers";

            //��ŷ�� ����
            DockPanel dock = new DockPanel();
            Content = dock;

            //�޴� ����
            Menu menu = new Menu();

            //�޴� ������ ���� 
            MenuItem item = new MenuItem();
            item.Header = "Menu";
            menu.Items.Add(item);

            //�޴� ������ ����2
            MenuItem item2 = new MenuItem();
            item2.Header = "About";
            menu.Items.Add(item2);

            //��ŷ�� �����Ѵ� ����
            DockPanel.SetDock(menu, Dock.Top);
            dock.Children.Add(menu);  // ��ŷ�� �߰�

            // ���� ����
            ToolBar tool = new ToolBar();
            tool.Header = "Toolbar";

            // ���ٸ� ���������� ��ŷ
            DockPanel.SetDock(tool, Dock.Right);
            dock.Children.Add(tool);

            //���� ����
            StatusBar status = new StatusBar();

            //���¾����� �߰�
            StatusBarItem statitem = new StatusBarItem();
            statitem.Content = "Status";
            status.Items.Add(statitem);
            
            //���¹� �Ʒ��� ��ŷ
            DockPanel.SetDock(status, Dock.Bottom);
            dock.Children.Add(status);

            // ����Ʈ�ڽ� ����
            ListBox lstbox = new ListBox();
            lstbox.Items.Add("List Box Item");

            //����Ʈ �ڽ� ���ʿ� �߰�
            DockPanel.SetDock(lstbox, Dock.Left);
            dock.Children.Add(lstbox);

            // �ؽ�Ʈ�ڽ�
            TextBox txtbox = new TextBox();
            txtbox.AcceptsReturn = true;  // ���� �߰�(Enter���)

            //��ŷ�� �߰�
            dock.Children.Add(txtbox);
            dock.LastChildFill = true;
            txtbox.Focus();
        }
    }
}
