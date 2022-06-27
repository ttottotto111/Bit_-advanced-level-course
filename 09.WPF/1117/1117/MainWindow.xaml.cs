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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1117
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public string Msg { get; set; }
        // 터널링 이벤트
        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //최초의 라우트된 이벤트 메시지
            Msg = "Window_터널링->";
        }
        private void Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "Canvas_터널링->";
        }
        private void Label_Yellow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "Label_Yellow터널링->";
        }
        private void StackPanel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "StackPanel_터널링->";
        }
        private void Ellipse_Red_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {            
            Msg += "Ellipse_터널링->";
            
        }
        private void Label_Green_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "Label_Green터널링->";
        }
        // 버블링 이벤트
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "Window_버블링";
            Title = Msg; // 지금까지 발생한 라우트된 이벤트를 출력한다.
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "Canvas_버블링->";
        }
        private void Label_Yellow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "Label_Yellow버블링->";
        }
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "StackPanel_버블링->";
        }
        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show("TEST");
            Msg += "Ellipse_버블링->";
        }
        private void Label_Green_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Msg += "Label_Green버블링->";
        }
    }
}
