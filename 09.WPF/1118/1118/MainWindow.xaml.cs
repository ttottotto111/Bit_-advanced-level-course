using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace _1118
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private ShapeData sdata = null;
        private ShapeDataList sdatalist = null;

        public MainWindow()
        {
            InitializeComponent();

            sdata = (ShapeData)FindResource("shape");
            sdatalist = (ShapeDataList)FindResource("shapedatalist");
        }

        //그림그리기
        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            sdata.Pt = e.GetPosition(can);

            Shape rt = null;
            if (sdata.Type == 1)
                rt = new Rectangle();
            else
                rt = new Ellipse();

            rt.Width    = rt.Height = sdata.Size;
            rt.Stroke   = new SolidColorBrush(sdata.Col);
            rt.Fill     = new SolidColorBrush(sdata.Col);

            Canvas.SetLeft(rt, sdata.Pt.X);
            Canvas.SetTop(rt, sdata.Pt.Y);
            can.Children.Add(rt);

            //저장
            ShapeData sd = new ShapeData()
            {
                Type = sdata.Type,
                Col = sdata.Col,
                Size = sdata.Size,
                Pt = sdata.Pt
            };

            sdatalist.Add(sdata);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                sdata.Type = 1;
            }
            if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                sdata.Type = 2;
            }

            //키보드 방향키로 도형변경
            if(e.Key ==Key.Up)
            {
                if (sdata.Size == 25)       sdata.Size = 50;
                else if (sdata.Size == 50)  sdata.Size = 100;
                else if (sdata.Size == 100) sdata.Size = 150;
                else if (sdata.Size == 150) sdata.Size = 200;
                else if (sdata.Size == 200) sdata.Size = 50;
            }
            else if(e.Key ==Key.Down)
            {
                if (sdata.Size == 200) sdata.Size = 150;
                else if (sdata.Size == 150) sdata.Size = 100;
                else if (sdata.Size == 100) sdata.Size = 50;
                else if (sdata.Size == 50) sdata.Size = 25;
                else if (sdata.Size == 25) sdata.Size = 200;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Temp();
        }

        //Color 나열함수
        private void Temp()
        {
            //SQL문 처럼 C#언어에서 사용할 수 있는 문법
            //var == List<ColorInfo>
            var color_query =
                    from PropertyInfo property in typeof(Colors).GetProperties()
                    orderby property.Name
                    //orderby ((Color)property.GetValue(null, null)).ToString()
                    select new ColorInfo(
                property.Name,
                (Color)property.GetValue(null, null));

            //컨테이너에 저장된 데이터를 콤보박스에 바인딩
            combocolor.ItemsSource = color_query;
        }

        
    }
}
