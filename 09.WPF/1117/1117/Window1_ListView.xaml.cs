using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1117
{
    public class MyItem
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }

    /// <summary>
    /// Window1_ListView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1_ListView : Window
    {
        public Window1_ListView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string inputname = name.Text;
            string inputphone = phone.Text;
            
            listview1.Items.Add(new MyItem { Name = inputname, Phone = inputphone });
        }

        private void listview1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyItem item = (MyItem)listview1.SelectedItem;
            Title = item.Name + "," + item.Phone;
        }
    }
}
