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

            // 바이트가 아닌 인트형태로 배열 생성
            int[] array = new int[256 * 256];

            for (int x = 0; x < 256; x++)
            for (int y = 0; y < 256; y++)
            {
                int b = x;
                int g = 0;
                int r = y;

                array[256 * y + x] = b | (g << 8) | (r << 16); // 이전 예제와 달리 좀더 정교한 형태로 추가
            }

            // PixelFormats.Bgr32 -> 해당 포멧을 사용하면 타일형태의 표시가 아닌 정교한 그래픽 표시를 출력해준다.
            BitmapSource bitmap = 
                BitmapSource.Create(256, 256, 96, 96, PixelFormats.Bgr32,
                                    null, array, 256 * 4);

           
            Image img = new Image();
            img.Source = bitmap;

       
            Content = img;
        }
    }
}
