//------------------------------------------------
// StackTenButtons.cs (c) 2006 by Charles Petzold
//------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.StackTenButtons
{
    class StackTenButtons : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new StackTenButtons());
        }

        public StackTenButtons()
        {
            Title = "Stack Ten Buttons";

            StackPanel stack = new StackPanel();        //Defualt�� �����̴�.
            Content = stack;
            Random rand = new Random();                 //���� ������ �߻� ��Ŵ

            //���� Content�� ���� �ϳ��� ��ü�� ���� �� �ִٰ� ����µ�
            //�������� ��ü�� ��� ����
            for (int i = 0; i < 10; i++)
            {
                Button btn = new Button();

                btn.Name = ((char)('A' + i)).ToString();     //�ƽ�Ű �ڵ带 �̿��Ͽ� A���� 10���� ���ĺ� �߻���
                btn.FontSize += rand.Next(10);               //10���� ������ ��Ʈ ������ ���� �߻�
                btn.Content = "Button " + btn.Name + " says 'Click me'";
                btn.Click += ButtonOnClick;

                

                //1. stack.Orientation = Orientation.Horizontal;              // Horizontal�� �̿��ؼ� Defualt���� �ٲ� �� �ִ�.
                //2. btn.HorizontalAlignment = HorizontalAlignment.Center;    // ��ư �ȿ� �۾� ũ��� ���� ����
                //3. stack.HorizontalAlignment = HorizontalAlignment.Center;  // ������Ƽ�� ������ stretch�̹Ƿ� ����ū ��ư ũ��� ���ϵȴ�.
                //4-1  SizeToContent = SizeToContent.WidthAndHeight;            // �������� â�� panel ũ��� �����.
                //4-2. btn.Margin = new Thickness(5);
                //4-2. stack.Margin = new Thickness(5);
                stack.Children.Add(btn);

                stack.Background = Brushes.Aquamarine;

                //string str = stack.Children[i].ToString();                  // �̷������� ������Ʈ�� ������ ���ü��� �ִ�.
            }




            stack.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick));       //AddHandler�޼ҵ�� UIElement�� ���ǵǾ� �����Ƿ� ����͸� ���� ButtonOnClick�� ȣ���� �� �ִ�.

            //AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonOnClick));             //�г��� ������� �ʰ� ������ ��ü���� �ҷ��� ���� �ִ�.
        }
      


        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            Button btn = args.Source as Button;     //��ư�� ���� �� �̺�Ʈ�� ����Ϳ� ����

            MessageBox.Show("Button " + btn.Name + " has been clicked",
                            "Button Click");

            
        }
    }
}