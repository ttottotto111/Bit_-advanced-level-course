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
    /// Window3.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window3 : Window
    {
        private Person per = null;

        public Window3()
        {
            InitializeComponent();
            per = (Person)FindResource("person");   //정적리소스에서 획득

            //에러 콜백 함수 등록[컨트롤명, 핸들러 함수]
            Validation.AddErrorHandler(agetxt, Age_ValidationError);
        }

        private void Age_ValidationError(object sender,ValidationErrorEventArgs e)
        {
            MessageBox.Show((string)e.Error.ErrorContent, "유효성 검사 실패");

            //동적 툴팁
            agetxt.ToolTip = (string)e.Error.ErrorContent;
        }


        private void eraseButton_Click(object sender, RoutedEventArgs e)
        {
            per.Name = "";
            per.Phone = "";
            per.Age = null;
        }
    }
}
