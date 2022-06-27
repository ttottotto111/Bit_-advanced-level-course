//----------------------------------------------
// BetterEllipse.cs (c) 2006 by Charles Petzold
//----------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;

namespace Petzold.RenderTheBetterEllipse
{
    public class BetterEllipse : FrameworkElement
    {
        // ���� ������Ƽ
        public static readonly DependencyProperty FillProperty;
        public static readonly DependencyProperty StrokeProperty;

        // ���� ������Ƽ�� ���� Public �������̽�
        public Brush Fill
        {
            set { SetValue(FillProperty, value); }
            get { return (Brush)GetValue(FillProperty); }
        }
        public Pen Stroke
        {
            set { SetValue(StrokeProperty, value); }
            get { return (Pen)GetValue(StrokeProperty); }
        }

        // ���� ������
        static BetterEllipse()
        {
            //���� ������Ƽ ���?
            FillProperty =
                DependencyProperty.Register("Fill", //������Ƽ �̸�
                        typeof(Brush),              //������Ƽ�� Ÿ��
                        typeof(BetterEllipse),      //������Ƽ�� �θ�Ÿ��(Ŭ���� �̸�)
                                                    //������Ƽ�� ��Ÿ������
                        new FrameworkPropertyMetadata(null, 
                            FrameworkPropertyMetadataOptions.AffectsRender)); //flag��
            StrokeProperty =
                DependencyProperty.Register("Stroke", typeof(Pen),
                        typeof(BetterEllipse), new FrameworkPropertyMetadata(null,
                                FrameworkPropertyMetadataOptions.AffectsMeasure));
        }

        // MeasureOverride�� �������̵�
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            Size sizeDesired = base.MeasureOverride(sizeAvailable);

            if (Stroke != null)
                sizeDesired = new Size(Stroke.Thickness, Stroke.Thickness);

            return sizeDesired;
        }

        // OnRender�� �������̵�
        protected override void OnRender(DrawingContext dc)
        {
            Size size = RenderSize;

            // ���� �β��� RenderSize ����
            if (Stroke != null)
            {
                //Thickness������Ƽ ��ŭ Ÿ���� ������ ���δ�.
                size.Width = Math.Max(0, size.Width - Stroke.Thickness);
                size.Height = Math.Max(0, size.Height - Stroke.Thickness);
            }

            // Ÿ�� �׸���
            dc.DrawEllipse(Fill, Stroke,
                new Point(RenderSize.Width / 2, RenderSize.Height / 2),
                size.Width / 2, size.Height / 2);

            #region �߰����� �ڵ�
            string testString = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor";

            // FormattedText ����
            FormattedText formtxt = new FormattedText(
                testString, //���ڿ�
                CultureInfo.GetCultureInfo("en-us"),//Text Ư�� ��ȭ��    
                FlowDirection.LeftToRight,          //Text �д� ����
                new Typeface("Verdana"),            //Text ��Ÿ��
                32,                                 //�۲� ũ��
                Brushes.Black);                     //�귯�� ����

            // Set a maximum width and height. If the text overflows these values, an ellipsis "..." appears.
            formtxt.MaxTextWidth = 300;             //Text ���� �ִ���
            formtxt.MaxTextHeight = 240;            //Text ���� �ִ����

            // Use a larger font size beginning at the first (zero-based) character and continuing for 5 characters.
            // The font size is calculated in terms of points -- not as device-independent pixels.
            formtxt.SetFontSize(36 * (96.0 / 72.0), 0, 5);

            // ������ �ؽ�Ʈ �� ���� (����, ��ġ, ����)
            formtxt.SetFontWeight(FontWeights.Bold, 6, 11);

            // ������ �ؽ�Ʈ �׶��̼� �ֱ�
            formtxt.SetForegroundBrush(
                                    new LinearGradientBrush(
                                    Colors.Orange,
                                    Colors.Teal,
                                    90.0),                      //�귯��(�׶��̼�)
                                    6, 11);                     //��ġ, ����

            // ������ �ؽ�Ʈ�� ��Ʈ��Ÿ��
            formtxt.SetFontStyle(FontStyles.Italic, 28, 28);

            //���
            dc.DrawText(formtxt, new Point((RenderSize.Width - formtxt.Width) / 2,
                                            (RenderSize.Height - formtxt.Height) / 2));
            #endregion

            dc.PushClip(new RectangleGeometry(new Rect(new Point(0, 0), RenderSize)));
        }
    }
}