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
    /// Window1_SlidProgress.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1_SlidProgress : Window
    {
        public Window1_SlidProgress()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Title = slider1.Value.ToString();
            Title = ((int)slider1.Value).ToString();
            //Title = ((System.Windows.Controls.Primitives.RangeBase)e.Source).Value.ToString();

            prog.Value = slider1.Value;
        }
    }
}
