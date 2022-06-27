//----------------------------------------------
// BindTheButton.cs (c) 2006 by Charles Petzold
//----------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Data;

namespace Petzold.BindTheButton
{
    public class BindTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new BindTheButton());
        }
        public BindTheButton()
        {
            Title = "Bind theButton";

            ToggleButton btn = new ToggleButton();
            btn.Content = "Make _Topmost";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;

            //Binding bind = new Binding("Topmost");                    //Binding Ŭ������ �̿��Ͽ� Topmost ����
            //bind.Source = this;                                       // ���ε��� ��ü(�ҽ�)�� �ڱ��ڽ�
            //btn.SetBinding(ToggleButton.IsCheckedProperty, bind);     //setBining ���� ��� ��ư�� IsCheckedPropert�� Binding �� ����
            
            btn.SetBinding(ToggleButton.IsCheckedProperty, "Topmost"); // ��ư�� ���ε��� ���� Topmost ������Ƽ ���..
            btn.DataContext = this;                                    // ���ε��� �� ��ü (Windows â ... �� �ڱ� �ڽ�)
            Content = btn;

            ToolTip tip = new ToolTip();                               //���� ����
            tip.Content = "Toggle the button on to make " +
                          "the window topmost on the desktop";
            btn.ToolTip = tip;                                         //Btb
        }
    }
}