//------------------------------------------
// ColorCell.cs (c) 2006 by Charles Petzold
//------------------------------------------
using System;
using System.Windows;
using System.Windows.Media;

namespace Petzold.SelectColor
{
    class ColorCell : FrameworkElement
    {
        // Private �ʵ�
        static readonly Size sizeCell = new Size(20, 20);
        DrawingVisual visColor;
        Brush brush;

        // ���� ������Ƽ
        public static readonly DependencyProperty IsSelectedProperty;
        public static readonly DependencyProperty IsHighlightedProperty;
 
        static ColorCell()
        {
            // ���� ������Ƽ ���
            IsSelectedProperty = 
                DependencyProperty.Register("IsSelected", typeof(bool), 
                        typeof(ColorCell), new FrameworkPropertyMetadata(false, 
                                FrameworkPropertyMetadataOptions.AffectsRender));

            IsHighlightedProperty = 
                DependencyProperty.Register("IsHighlighted", typeof(bool), 
                        typeof(ColorCell), new FrameworkPropertyMetadata(false, 
                                FrameworkPropertyMetadataOptions.AffectsRender));
        }

        // ������Ƽ
        public bool IsSelected
        {
            set { SetValue(IsSelectedProperty, value); }
            get { return (bool)GetValue(IsSelectedProperty); }
        }
        public bool IsHighlighted
        {
            set { SetValue(IsHighlightedProperty, value); }
            get { return (bool)GetValue(IsHighlightedProperty); }
        }
        public Brush Brush
        {
            get { return brush; }
        }

        // Color�� ���ڷ� �ϴ� ������
        public ColorCell(Color clr)
        {
            // DrawingVisual�� ������ �ʵ忡 ����
            visColor = new DrawingVisual();
            DrawingContext dc = visColor.RenderOpen();

            // Color ���ڸ� ������ �簢�� �׸���
            Rect rect = new Rect(new Point(0, 0), sizeCell);
            rect.Inflate(-4, -4); 
            Pen pen = new Pen(SystemColors.ControlTextBrush, 1);
            brush = new SolidColorBrush(clr);
            dc.DrawRectangle(brush, pen, rect);
            dc.Close();

            // AddVisualChild�� �̺�Ʈ ����ÿ� �ʿ���!
            AddVisualChild(visColor);
            AddLogicalChild(visColor);
        }

        // VisualChild�� ���õ� protected ������Ƽ�� �޼ҵ带 �������̵�
        // Visual�� ���縦 �����ϱ� ���� 1�� ��ȯ
        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        // Visual �� ��ü�� ��ȯ�Ѵ�.
        protected override Visual GetVisualChild(int index)
        {
            if (index > 0)
                throw new ArgumentOutOfRangeException("index");

            return visColor;
        }


        // ������Ʈ�� ũ��� �������� ���õ� protected �޼ҵ带 �������̵�
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            return sizeCell;
        }

        protected override void OnRender(DrawingContext dc)
        {
            Rect rect = new Rect(new Point(0, 0), RenderSize);
            
            // �簢���� ������ ũ�⸸ŭ ����ϰų� Ȯ��
            rect.Inflate(-2, -2);   
            Pen pen = new Pen(SystemColors.HighlightBrush, 1);

            if (IsHighlighted)      // �׸��� ���� ǥ�� ����
                dc.DrawRectangle(SystemColors.ControlDarkBrush, pen, rect);
            else if (IsSelected)    // ���� ����
                dc.DrawRectangle(SystemColors.ControlLightBrush, pen, rect);
            else
                dc.DrawRectangle(Brushes.Transparent, null, rect);
        }
    }
}
