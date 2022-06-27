//---------------------------------------------------
// DockAroundTheBlock.cs (c) 2006 by Charles Petzold
//---------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DockAroundTheBlock
{
    class DockAroundTheBlock : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DockAroundTheBlock());
        }

        public DockAroundTheBlock()
        {
            Title = "Dock Around the Block";

            // 1. �г� ���� �� �ʱ�ȭ
            DockPanel dock = new DockPanel();
            Content = dock;

            // 2. ���ϴ� �ڽ� ��ü(�̹���, ��Ʈ��, �г�..)
            for (int i = 0; i < 17; i++)
            {
                Button btn = new Button();
                btn.Content = "Button No. " + (i + 1);
                //-------------------------------------------------
                dock.Children.Add(btn);
                
                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4));
                
                DockPanel.SetDock(btn, (Dock)(i % 4));
                //-------------------------------------------------
            }

            dock.LastChildFill = false;
        }
    }
}


