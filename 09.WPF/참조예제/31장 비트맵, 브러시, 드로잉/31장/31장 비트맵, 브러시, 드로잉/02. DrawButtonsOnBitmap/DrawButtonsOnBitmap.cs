//----------------------------------------------------
// DrawButtonsOnBitmap.cs (c) 2006 by Charles Petzold
//----------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Petzold.DrawButtonsOnBitmap
{
    public class DrawButtonsOnBitmap : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DrawButtonsOnBitmap());
        }
        public DrawButtonsOnBitmap()
        {
            Title = "Draw Buttons on Bitmap";

            // ��ư�� ��ġ��ų UniformGrid ����
            UniformGrid unigrid = new UniformGrid();
            unigrid.Columns = 4;

            // UniformGrid ���� 32���� ��۹�ư ��ü�� ����
            for (int i = 0; i < 32; i++)
            {
                ToggleButton btn = new ToggleButton();
                btn.Width = 96;
                btn.Height = 24;
                btn.IsChecked = (i < 4 | i > 27) ^ (i % 4 == 0 | i % 4 == 3);
                unigrid.Children.Add(btn);
            }

            // ������Ʈ �Ǵ� ��Ʈ���� ������ �������� �׸��� �ݵ�� Measure / Arrage �޼ҵ带 ȣ���ؼ� ũ�⸦ �����������.
            unigrid.Measure(new Size(Double.PositiveInfinity,
                                     Double.PositiveInfinity));

            Size szGrid = unigrid.DesiredSize;

            unigrid.Arrange(new Rect(new Point(0, 0), szGrid));

            // ���� ������ ������ ������ ��ħ.
            RenderTargetBitmap renderbitmap =
                new RenderTargetBitmap((int)Math.Ceiling(szGrid.Width),
                                       (int)Math.Ceiling(szGrid.Height),
                                       96, 96, PixelFormats.Default);

           
            renderbitmap.Render(unigrid);

            
            Image img = new Image();
            img.Source = renderbitmap;

 
            Content = img;
        }
    }
}
