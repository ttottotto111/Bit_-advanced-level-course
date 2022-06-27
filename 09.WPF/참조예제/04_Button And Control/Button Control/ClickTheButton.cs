//-----------------------------------------------
// ClickTheButton.cs (c) 2006 by Charles Petzold
//-----------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls.Primitives;

namespace Petzold.ClickTheButton
{
    public class ClickTheButton : Window
    {
        Run runButton;                                                                           //��ư��ü�� �̺�Ʈ�� �ܺο��� �̺�Ʈ�� �ֱ����� ������ �ʵ�  

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ClickTheButton());                                                   
        }
        public ClickTheButton()
        {
            Title = "Button Control";

            Button btn = new Button();

                                                 

            #region ��ư �Ӽ� ���� �߰��� �κ�


            //btn.Content = "_Click me, please!";
            //btn.Click += ButtonOnClick;  //��ư ��Ʈ�ѿ� ���ڿ� �߰�.."_"�� �ٷΰ��� Ű ����
            //btn.Focus();                                                                       //��ư ��Ʈ�ѿ� ��Ŀ��(�⺻��ư) ����
            //btn.IsDefault = true;                                                              //��ư�� ��Ŀ���� ��� �⺻ ��ư���� �����ϴ� ������Ƽ EndterŰ � ����
            //btn.IsCancel = true;                                                               //��ư�� Calcel ����� �߰��ϴ� ������Ƽ Esc Ű � �����ϰ� �ȴ�.

            //btn.Margin = new Thickness(96);                                                    //������Ʈ�� ��� �ٱ��� ������ �ο� ... ����������� ����� �Է��� �ȵȴ�.
            //btn.HorizontalContentAlignment = HorizontalAlignment.Left;                         //��ư ��Ʈ�ѿ� �Ҵ�� ���ڿ�(��ü)�� ���� �ϴܿ� ��ġ (����)
            //btn.VerticalContentAlignment = VerticalAlignment.Bottom;

            //btn.Padding = new Thickness(96);                                                   //��ư ���ο� ������ ����
            //btn.HorizontalAlignment = HorizontalAlignment.Center;                              //��ư�� ũ�⸦ �������� �°� ������ ���� â�� ��ġ�� �߾� �̹� ǥ�õ� �Ķ� ���� 
            //btn.VerticalAlignment = VerticalAlignment.Center;
            ////btn.Width = 96;                                                                    //��ư�� ũ�⸦ ��������� ����
            ////btn.Height = 96;

            //SizeToContent = SizeToContent.WidthAndHeight;                                     //��ư ũ�⿡ ���缭 â�� ũ�Ⱑ ���� ��ư�� ������ Margin �� �����
            
            //btn.FontSize = 48;                                                                //�Ҵ�ȵ� ���ڿ��� ���� ��Ʈ ������� 48 ��Ʈ������ Times New Roman
            //btn.FontFamily = new FontFamily("Times New Roman");

            //btn.Background = Brushes.AliceBlue;                                               //��ư�� ���� ����  
            //btn.Foreground = Brushes.DarkSalmon;
            //btn.BorderBrush = Brushes.Magenta;

            
            #endregion

            #region ��ư �̺�Ʈ ���� �߰��� �κ�

            #region ��ư �Ӽ� 
            
            //SizeToContent = SizeToContent.WidthAndHeight; 
            //btn.HorizontalAlignment = HorizontalAlignment.Center;                              //��ư�� ũ�⸦ �������� �°� ������ ���� â�� ��ġ�� �߾� �̹� ǥ�õ� �Ķ� ���� 
            //btn.VerticalAlignment = VerticalAlignment.Center;
           

            #endregion

            //btn.Content = runButton = new Run("Click me, please!");                             //��ư ��Ʈ�ѿ� ���ڿ� �߰�.."_"�� �ٷΰ��� Ű ����

            //btn.Click += ButtonOnClick;                                                          //��ư Ŭ�� �̺�Ʈ
            //btn.MouseEnter += ButtonOnMouseEnter;
            //btn.MouseLeave += ButtonOnMouseLeave;

            #endregion

            #region ��ư�� �̹����� ����

            Uri uri = new Uri("pack://application:,,/munch.png");                               //Uri ������
            BitmapImage bitmap = new BitmapImage(uri);                                          //Uri �����ڸ� �̿��Ͽ� ��Ʈ�� ��ü ����

            Image img = new Image();                                                            //�̹��� ��ü ����
            img.Source = bitmap;                                                                //�̹��� �ҽ��� ������ ��Ʈ�� ��ü
            img.Stretch = Stretch.None;                                                         //ũ��� �̹��� ���� ũ��� ...

            btn.Content = img;                                                                  //��ư Bottun.Content�� �̹��� ���Ϸ� �Ҵ� 

            #region ��ư�Ӽ�
            btn.HorizontalAlignment = HorizontalAlignment.Center;                              //��ư�� ũ�⸦ �������� �°� ������ ���� â�� ��ġ�� �߾� �̹� ǥ�õ� �Ķ� ���� 
            btn.VerticalAlignment = VerticalAlignment.Center;
            #endregion
           
            #endregion

            //#region ��ư���� Ŭ������ (�ٿ��ֱ�) ����
            //#region ��ư�Ӽ�
            //btn.HorizontalAlignment = HorizontalAlignment.Center;
            //btn.VerticalAlignment = VerticalAlignment.Center;
            //#endregion

            //btn.Command = ApplicationCommands.Paste;                                            //Application �� ������ �� �ִ� Paste �� ��ư Ŀ���� ���ε� 
            //btn.Content = ApplicationCommands.Paste.Text;                                       //Paste �� �̸����ڿ�(�ٿ��ֱ�)

            //CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste,                   //Command�� �̺�Ʈ �ڵ鷯 ���ε� 
            //                    PasteOnExecute, PasteCanExecute));


            //#endregion

            #region ��� ��ư
            //ToggleButton Tbtn = new ToggleButton();                                             //��� ��ư ����
            CheckBox Tbtn = new CheckBox();                                                   //üũ �ڽ� ����
            Tbtn.Content = "Can _Resize";
            Tbtn.HorizontalAlignment = HorizontalAlignment.Center;
            Tbtn.VerticalAlignment = VerticalAlignment.Center;
            Tbtn.IsChecked = (ResizeMode == ResizeMode.CanResize);                              //IsChecked �̺�Ʈ �ʱ�ȭ
            Tbtn.Checked += ButtonOnChecked;                                                  //Button Checked �̺�Ʈ �޼��� �Ҵ�
            Tbtn.Unchecked += ButtonOnChecked;                                                //Button UnChecked �̺�Ʈ �޼��� �Ҵ�
            Content = Tbtn;
            #endregion

            //Content = btn;                                                                       //��ư ��ü ������ Winodow.Content ������Ƽ ��ü�� �Ҵ�

        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("The button has been clicked and all is well.",Title);
        }

        #region ��ư �̺�Ʈ �޼���
        void ButtonOnMouseEnter(object sender, MouseEventArgs args)
        {
            runButton.Foreground = Brushes.Red;                                                // ���콺�� ��ư ��Ʈ�� ������ �̵��� �߻� 
        }
        void ButtonOnMouseLeave(object sender, MouseEventArgs args)
        {
            runButton.Foreground = SystemColors.ControlTextBrush;                             // ���콺�� ��ư ��Ʈ�� ������ �̵��� �߻� 
        }
        #endregion

        #region �ٿ��ֱ� �̺�Ʈ �Լ�
        void PasteOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            Title = Clipboard.GetText();
        }
        void PasteCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = Clipboard.ContainsText();
        }
        protected override void OnMouseDown(MouseButtonEventArgs args)
        {
            base.OnMouseDown(args);
            Title = "Button Control";
        }
        #endregion
        
      
        void ButtonOnChecked(object sender, RoutedEventArgs args)
        {
            ToggleButton Tbtn = sender as ToggleButton;
            ResizeMode =
                (bool)Tbtn.IsChecked ? ResizeMode.CanResize : ResizeMode.NoResize;
        }
    }
}
