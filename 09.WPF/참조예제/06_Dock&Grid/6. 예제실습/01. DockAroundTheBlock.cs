using System;
using System.Windows;
using System.Windows.Controls;  // button �߰��ϱ�����

namespace Project1
{
    class Class1 : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new Class1());  // Run �� Class1�� ȣ���Ѵ�.
        }

        public Class1()
        {
            Title = "Dock Aound the Block";  // Ÿ��Ʋ����

            DockPanel dock = new DockPanel();  // ��ŷ ��ü �ϳ� ����
            Content = dock;                    // Content ������Ƽ�� �ִ´�.

            for (int i = 0; i < 5; i++)        // �� 5�� ���ư���
            {
                Button btn = new Button();    
                btn.Content = "Button No." + (i + 1);   // ��ư�� ����
                dock.Children.Add(btn);                 // ��ư�� ��ŷ ���ϵ�� �־��ش�.

               // btn.HorizontalAlignment = HorizontalAlignment.Center;  // ��������
               // btn.VerticalAlignment = VerticalAlignment.Center;      // ��������

                btn.SetValue(DockPanel.DockProperty, (Dock)(i % 4));  // 0 ���� 1 �� 2 ������ 4�Ʒ�

            }
            //dock.LastChildFill = false; ������������ ä��°� ��� ���Ѵ�.
        }

    }
}


