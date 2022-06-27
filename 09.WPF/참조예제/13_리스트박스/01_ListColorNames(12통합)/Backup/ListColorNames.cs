using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization; // ��¥

namespace Petzold.ListColorNames
{
    class ListColorNames : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ListColorNames());
        }
        public ListColorNames()
        {
            Title = "List Color Names";
            
            ListBox lstbox = new ListBox();
            lstbox.Width = 150;   // ��
            lstbox.Height = 150;  //���� 
            lstbox.SelectionChanged += ListBoxOnSelectionChanged;   // �̺�Ʈ ��� 
            Content = lstbox;          //win�� ���(ȭ�鿡 ���)
           
           // lstbox.Items.Add("������");
           // lstbox.Items.Add("ȭ����");
            //lstbox.Items.Add("������");
            //lstbox.Items.Add("�����");
           
            //lstbox.ItemsSource = DateTimeFormatInfo.CurrentInfo.DayNames;   //�ڱ���
            //lstbox.ItemsSource = DateTimeFormatInfo.InvariantInfo.DayNames; //����
           
            //1��
            /*
            //��������� ListBox�� ü���
            PropertyInfo[] props = typeof(Colors).GetProperties();
            //GetProperties �� Colors�� �ִ� ������Ƽ 141���� �迭�� �����´�.
            //������ PropertyInfo Ÿ���� �迭�� �ϳ��� ������ Name���� �̸��� ����Ʈ �ڽ��� �߰��Ѵ�.
            foreach (PropertyInfo prop in props)
                lstbox.Items.Add(prop.Name);
            */


            //2��
            /*
            PropertyInfo[] props = typeof(Colors).GetProperties();
            //����Ʈ �ڽ��� Color ������ ü���...
            foreach (PropertyInfo prop in props)
                lstbox.Items.Add(prop.GetValue(null, null));
           */

          
        }

        //����Ʈ�� ��å�׸��� �������� �߻��ϴ� �̺�Ʈ 
        void ListBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            //�Ķ���ͷ� �Ѿ�� �ڱ� �ڽ��� ����ȯ �Ͽ� ��´�. 
            ListBox lstbox = sender as ListBox;


            //1��
            /*
            //������ ��ü�� ���õ� Item �� string ���·� ĳ���� �Ͽ� string�� ��´�.
            string str = lstbox.SelectedItem as string;
            //Selectedindex ������ 0 ���� ������ ���� -1 ������ �ȴ�.
            //��ȯ�� string���� null�� �ƴϸ� ������ �ٲ۴�.
            if (str != null)
            {
                //�������� �̸����� Color�� ���� ��ȯ �޴¹�� 
                Color clr = (Color)typeof(Colors).GetProperty(str).GetValue(null, null);

                Background = new SolidColorBrush(clr);
            }
            */

            //2��
            /*
            if (lstbox.SelectedIndex != -1)
            {
                Color clr = (Color)lstbox.SelectedItem;
                Background = new SolidColorBrush(clr);
            }
            */
            
        }
            



    }
}
