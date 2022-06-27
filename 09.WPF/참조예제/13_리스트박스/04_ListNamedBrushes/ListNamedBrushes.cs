//-------------------------------------------------
// ListNamedBrushes.cs (c) 2006 by Charles Petzold
//-------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.ListNamedBrushes
{
    public class ListNamedBrushes : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ListNamedBrushes());
        }
        public ListNamedBrushes()
        {
            Title = "List Named Brushes";

            ListBox lstbox = new ListBox();
            lstbox.Width = 150;
            lstbox.Height = 150;
            Content = lstbox;

            //�׸�� ������Ƽ �н��� ����...
            lstbox.ItemsSource = NamedBrush.All;
            lstbox.DisplayMemberPath = "Name";
            lstbox.SelectedValuePath = "Brush";             //<---����Ʈ�ڽ��� NamedBrush ��ü�� �������� brush�� ����...

            //selectedValue�� ������ ���� ���ε�..
            lstbox.SetBinding(ListBox.SelectedValueProperty, "Background");
            lstbox.DataContext = this;
        }
    }
}
