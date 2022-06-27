//-----------------------------------------------------------
// EnlargeButtonWithAnimation.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Petzold.EnlargeButtonWithAnimation
{
    public class EnlargeButtonWithAnimation : Window
    {
        const double initFontSize = 12;
        const double maxFontSize = 48;
        Button btn;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new EnlargeButtonWithAnimation());
        }
        public EnlargeButtonWithAnimation()
        {
            Title = "Enlarge Button with Animation";

            btn = new Button();
            btn.Content = "Expanding Button";
            btn.FontSize = initFontSize;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick;
            Content = btn;
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            //DoubleAnimation ��ü����
            DoubleAnimation anima = new DoubleAnimation();
            //Duration(���ӽð�)�� 2�ʷ� ����
            anima.Duration = new Duration(TimeSpan.FromSeconds(2));   
            //�ʱⰪ����
            anima.From = initFontSize;    
            //���������� ��ȭ��Ų�ٴ� ����κ�....
            anima.To = maxFontSize;
            anima.FillBehavior = FillBehavior.Stop;
            //BeginAnimation - UIElement�� ���� �޼ҵ�
            //ù��°���ڴ� ���ϸ��̼��� ������ ���� ������Ƽ
            //�ι�°���ڴ� ���ϸ��̼��� ��ų DoulbeAnimaiton�� ��ü
            btn.BeginAnimation(Button.FontSizeProperty, anima);
            //btn.BeginAnimation(Button.FontSizeProperty, anima.CreateClock());

        }
    }
}
