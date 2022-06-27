//-----------------------------------------------
// NavigateTheWeb.cs (c) 2006 by Charles Petzold
//-----------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.NavigateTheWeb
{
    public class NavigateTheWeb : Window
    {
        Frame frm;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new NavigateTheWeb());
        }
        public NavigateTheWeb()
        {
            Title = "Navigate the Web";

            frm = new Frame();              
            Content = frm;                  //Window ���������� Frame�� �Ҵ� 

            Loaded += OnWindowLoaded;
        }
        void OnWindowLoaded(object sender, RoutedEventArgs args)
        {
            UriDialog dlg = new UriDialog(); //UriDialog�� ����
            dlg.Owner = this;                // ���̾�α��� ������ �ڱ��ڽ�
            dlg.Text = "http://";           //Text ���� 
            dlg.ShowDialog();

            try
            {
                frm.Source = new Uri(dlg.Text);                  // ShowDialog�� ��ȯ�� ���� Frame Source ������Ƽ�� �Ҵ� 
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, Title);
            }
        }
    }
}
