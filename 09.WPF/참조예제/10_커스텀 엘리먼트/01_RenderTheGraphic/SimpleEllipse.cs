//----------------------------------------------
// SimpleEllipse.cs (c) 2006 by Charles Petzold
//----------------------------------------------
using System;
using System.Windows;
using System.Windows.Media;

namespace Petzold.RenderTheGraphic
{
    class SimpleEllipse : FrameworkElement
    {
        protected override void OnRender(DrawingContext dc)
        {
            //DrawingContext : ���� ���� ������ �׸���� ���� �޼ҵ�
	        //�� �ٸ� �ǹ̴� dc or drawingContext
            dc.DrawEllipse(Brushes.Blue, //Ÿ���� ����
                new Pen(Brushes.Red, 24),//Ÿ���� ��輱
                new Point(RenderSize.Width / 2, RenderSize.Height / 2),//Ÿ���� �߽��� ����Ű�� Point��ü
                RenderSize.Width / 2, RenderSize.Height / 2);//���� �ݰ�� ���� �ݰ�
        }
    }
}