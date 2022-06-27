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

namespace _1119
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private AccList acclist = new AccList();

        public MainWindow()
        {
            InitializeComponent();
        }

        //계좌번호 생성
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            accnum.Text = acclist.GetAccNumber().ToString();
        }

        //저장
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (accnum.Text == "" || accname.Text == "" || accnmoney.Text == "")
                    throw new Exception("계좌 정보를 입력하세요");

                Account acc = new Account()
                {
                    accId = int.Parse(accnum.Text),
                    accName = accname.Text,
                    accMoney = int.Parse(accnmoney.Text),
                    accTime = DateTime.Now                    
                };

                acclist.Add(acc);

                //컨트롤 초기화
                accnum.Text = accname.Text = accnmoney.Text = "";

                //우측에 정보 출력
                PrintNewAccount(acc);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintNewAccount(Account acc)
        {
            Run textid = new Run
            (
                "계좌번호 : " + acc.accId
            );
            Run textname = new Run("이   름 : " + acc.accName);
            Run textmoney = new Run("입 금 액 : " + acc.accMoney);
            Run textday = new Run("거래일자 : " + acc.accTime.ToShortDateString());
            Run texttime = new Run("거래시간 : " + acc.accTime.ToShortTimeString());

            Paragraph paragraph = new Paragraph();
            paragraph.TextAlignment = TextAlignment.Left;
            paragraph.FontFamily = new FontFamily("Palatino Linotype");
            paragraph.FontSize = 16;
            paragraph.Typography.NumeralStyle = FontNumeralStyle.OldStyle;
            paragraph.Typography.Fraction = FontFraction.Stacked;
            paragraph.Typography.Variants = FontVariants.Inferior;

            paragraph.Inlines.Add(textid);
            paragraph.Inlines.Add(new LineBreak());
            paragraph.Inlines.Add(textname);
            paragraph.Inlines.Add(new LineBreak());
            paragraph.Inlines.Add(textmoney);
            paragraph.Inlines.Add(new LineBreak());
            paragraph.Inlines.Add(textday);
            paragraph.Inlines.Add(new LineBreak());
            paragraph.Inlines.Add(texttime);
            this.flowDocument.Blocks.Add(paragraph);
        }

        //윈도우 종료시점
        private void Window_Closed(object sender, EventArgs e)
        {
            WbExcel.FileSave(acclist);
        }
    }
}
