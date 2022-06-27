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
    /// <summary>
    /// Window1_Radio.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1_Radio : Window
    {
        public Window1_Radio()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string msg = "";
            if ((bool)r1.IsChecked)
                msg += "r1 ";
            if ((bool)r2.IsChecked)
                msg += "r2 ";
            if ((bool)r3.IsChecked)
                msg += "r3 ";
            Title = msg;
        }

        private void r4_Checked(object sender, RoutedEventArgs e)
        {
            string msg = "";
            if ((bool)r4.IsChecked)
                msg += "r4 ";
            if ((bool)r5.IsChecked)
                msg += "r5 ";
            if ((bool)r6.IsChecked)
                msg += "r6 ";
            Title = msg;
        }
    }
}
