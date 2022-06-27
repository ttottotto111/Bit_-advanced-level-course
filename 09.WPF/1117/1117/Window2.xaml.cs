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
    /// Window2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window2 : Window
    {
        private Person per = new Person() {
            Name = "홍길동", Phone = "010-1111-1234", Age = 20 };

        public Window2()
        {
            InitializeComponent();

            //바인딩 처리 : 패널(UI)과 per(Data)객체
            panel.DataContext = per;
        }

        //[데이터바인딩처리]
        //UI 변경하면 자동으로 데이터 변경되는것은 확인했다.

        //데이터 변경 -> UI변경될까?(안된다):.NET속성이기때문에...
        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            per.Name = "";
            per.Phone = "";
            per.Age = null;
        }
    }
}
