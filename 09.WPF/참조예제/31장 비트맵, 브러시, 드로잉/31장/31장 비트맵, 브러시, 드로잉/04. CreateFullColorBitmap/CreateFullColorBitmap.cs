//------------------------------------------------------
// CreateFullColorBitmap.cs (c) 2006 by Charles Petzold
//------------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Petzold.CreateFullColorBitmap
{
    public class CreateFullColorBitmap : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CreateFullColorBitmap());
        }
        public CreateFullColorBitmap()
        {
            Title = "Create Full-Color Bitmap";

            // ����Ʈ�� �ƴ� ��Ʈ���·� �迭 ����
            int[] array = new int[256 * 256];

            for (int x = 0; x < 256; x++)
            for (int y = 0; y < 256; y++)
            {
                int b = x;
                int g = 0;
                int r = y;

                array[256 * y + x] = b | (g << 8) | (r << 16); // ���� ������ �޸� ���� ������ ���·� �߰�
            }

            // PixelFormats.Bgr32 -> �ش� ������ ����ϸ� Ÿ�������� ǥ�ð� �ƴ� ������ �׷��� ǥ�ø� ������ش�.
            BitmapSource bitmap = 
                BitmapSource.Create(256, 256, 96, 96, PixelFormats.Bgr32,
                                    null, array, 256 * 4);

           
            Image img = new Image();
            img.Source = bitmap;

       
            Content = img;
        }
    }
}
