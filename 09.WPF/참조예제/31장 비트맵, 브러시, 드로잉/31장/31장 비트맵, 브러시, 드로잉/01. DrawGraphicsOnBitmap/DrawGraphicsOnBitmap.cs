//-----------------------------------------------------
// DrawGraphicsOnBitmap.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Petzold.DrawGraphicsOnBitmap
{
    public class DrawGraphicsOnBitmap : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DrawGraphicsOnBitmap());
        }
        public DrawGraphicsOnBitmap()
        {
            Title = "Draw Graphics on Bitmap";

            // ��Ʈ���� ������ �����ϱ� ���� ����� ������.
            Background = Brushes.Khaki;

            // RenderTargetBitmap ������.
            RenderTargetBitmap renderbitmap = new RenderTargetBitmap(100, 100, 96, 96, PixelFormats.Default);

            // DrawingVisual ��ü�� ������.
            DrawingVisual drawvis = new DrawingVisual();
            DrawingContext dc = drawvis.RenderOpen();      // Render �޼ҵ� ȣ��
            dc.DrawRoundedRectangle(Brushes.Blue, new Pen(Brushes.Red, 10),
                                    new Rect(25, 25, 50, 50), 10, 10);
            dc.Close();

            // RenderTargetBitmap ���� DrawingVisual ��ü�� �׸�.
            renderbitmap.Render(drawvis);

            // �̹��� ��ä ���� -> ������Ƽ ����
            Image img = new Image();
            img.Source = renderbitmap;

            // ���
            Content = img;
        }
    }
}