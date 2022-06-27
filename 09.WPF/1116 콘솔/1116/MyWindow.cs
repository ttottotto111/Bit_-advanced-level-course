using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _1116
{
    class MyWindow : Window
    {
        public MyWindow()
        {
            //버튼 생성
            Button btn = new Button();
            btn.Click += Btn_Click;
            btn.Width = 100;
            btn.Height = 25;

            //버튼이 자식 컨텐츠로 문자열
            btn.Content = "클릭";

            //Window가 자식 컨텐츠로 버튼
            AddChild(btn);

            Title = "WPF Window";
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("버튼 클릭");
        }
    }
}
