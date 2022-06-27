//----------------------------------------------
// SimpleElement.cs (c) 2006 by Charles Petzold
//----------------------------------------------
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Petzold.CustomElementBinding
{
    class SimpleElement : FrameworkElement
    {
        // DependencyProperty ����
        public static DependencyProperty NumberProperty;

        // ���� �����ڿ� DependencyProperty ����
        static SimpleElement()
        {
            NumberProperty =
                DependencyProperty.Register("Number",                 // DependencyProperty�� �̸�
                                        typeof(double),             // �Ӽ��� ������ �� �ִ� ���� Ÿ��
                                        typeof(SimpleElement),       // ���Ӽ� �Ӽ� ������ Ÿ��
                    new FrameworkPropertyMetadata(0.0,              // �߰� �Ӽ� �ɼ� ��Ÿ������
                    FrameworkPropertyMetadataOptions.AffectsRender));
                                
        }

        // DependencyProperty�� CLR ������Ƽ�� ����
        public double Number
        {
            set { SetValue(NumberProperty, value); }
            get { return (double)GetValue(NumberProperty); }
        }

        // MeasureOverride�� �������̵��� ũ�⸦ �ϵ� �ڵ�
        protected override Size MeasureOverride(Size sizeavailable)
        {
            return new Size(200, 50);
        }

        // Number ������Ƽ�� �����ִ� OnRender
        protected override void OnRender(DrawingContext dc)    
        {
            dc.DrawText(
                new FormattedText(Number.ToString(),
                        CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                        new Typeface("Times New Roman"), 12,
                        SystemColors.WindowTextBrush),
                new Point(0, 0)); 
        }
    }
}
