//--------------------------------------------------
// CalculateYourLife.cs (c) 2006 by Charles Petzold
//--------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.CalculateYourLife
{
    class CalculateYourLife : Window
    {
        private TextBox txtboxBegin, txtboxEnd; 
        private Label lblLifeYears;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CalculateYourLife());
        }
        public CalculateYourLife()
        {
            Title = "Calculate Your Life";

            SizeToContent = SizeToContent.WidthAndHeight; // 사이즈 자동 조정
            ResizeMode = ResizeMode.CanMinimize;          // 폼사이즈 변동 불가

            //그리드 생성 추가
            Grid grid = new Grid();
            Content = grid;

            // 행추가
            for (int i = 0; i < 3; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowdef); //그리드에 추가
            }

            // 열 2개 추가
            for (int i = 0; i < 2; i++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                coldef.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(coldef); //그리드에 추가
            }

            // 라벨
            Label lbl = new Label();
            lbl.Content = "Begin Date: ";
            grid.Children.Add(lbl);
            Grid.SetRow(lbl, 0);
            Grid.SetColumn(lbl, 0);

            // 첫번째 텍스트박스추가
            txtboxBegin = new TextBox();
            txtboxBegin.Text = new DateTime(1980, 1, 1).ToShortDateString();  // 1980.1.1
            txtboxBegin.TextChanged += TextBoxOnTextChanged;
            grid.Children.Add(txtboxBegin);
            Grid.SetRow(txtboxBegin, 0);
            Grid.SetColumn(txtboxBegin, 1);

            // 두번째 라벨 추가
            lbl = new Label(); 
            lbl.Content = "End Date: ";
            grid.Children.Add(lbl);
            Grid.SetRow(lbl, 1);
            Grid.SetColumn(lbl, 0);

            // 두번째 텍스트박스 추가
            txtboxEnd = new TextBox();
            txtboxEnd.TextChanged += TextBoxOnTextChanged; // 이벤트 처리
            grid.Children.Add(txtboxEnd);
            Grid.SetRow(txtboxEnd, 1);
            Grid.SetColumn(txtboxEnd, 1);

            // Third label.
            lbl = new Label();
            lbl.Content = "Life Years: ";
            grid.Children.Add(lbl);
            Grid.SetRow(lbl, 2);
            Grid.SetColumn(lbl, 0);

            // Label for calculated result.
            lblLifeYears = new Label();
            grid.Children.Add(lblLifeYears);
            Grid.SetRow(lblLifeYears, 2);
            Grid.SetColumn(lblLifeYears, 1);

            // 경계선을 만든다.
            Thickness thick = new Thickness(5); // ~1/20 inch.
            grid.Margin = thick;

            foreach (Control ctrl in grid.Children)
                ctrl.Margin = thick;

            // Set focus and trigger the event handler.
            txtboxBegin.Focus();
            txtboxEnd.Text = DateTime.Now.ToShortDateString();
        }
        void TextBoxOnTextChanged(object sender, TextChangedEventArgs args)
        {
            DateTime dtBeg, dtEnd;

            if (DateTime.TryParse(txtboxBegin.Text, out dtBeg) &&
                DateTime.TryParse(txtboxEnd.Text, out dtEnd))
            {
                int iYears = dtEnd.Year - dtBeg.Year;
                int iMonths = dtEnd.Month - dtBeg.Month;
                int iDays = dtEnd.Day - dtBeg.Day;

                if (iDays < 0)
                {
                    iDays += DateTime.DaysInMonth(dtEnd.Year,
                                            1 + (dtEnd.Month + 10) % 12);
                    iMonths -= 1;
                }
                if (iMonths < 0)
                {
                    iMonths += 12;
                    iYears -= 1;
                }
                lblLifeYears.Content =
                    String.Format("{0} year{1}, {2} month{3}, {4} day{5}",
                                  iYears, iYears == 1 ? "" : "s",
                                  iMonths, iMonths == 1 ? "" : "s",
                                  iDays, iDays == 1 ? "" : "s");
            }
            else
            {
                lblLifeYears.Content = "";
            }
        }
    }
}