//-----------------------------------------------
// MedievalButton.cs (c) 2006 by Charles Petzold
//-----------------------------------------------
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.GetMedieval
{
    public class MedievalButton : Control
    {
        // 2���� private �ʵ�
        FormattedText formtxt;
        bool isMouseReallyOver;

        // ���� �б� ���� �ʵ�
        public static readonly DependencyProperty TextProperty;
        public static readonly RoutedEvent KnockEvent;
        public static readonly RoutedEvent PreviewKnockEvent;

        // ���� ������
        static MedievalButton()
        {
            // ���� ������Ƽ ���
            TextProperty = 
                DependencyProperty.Register("Text", typeof(string), 
                                            typeof(MedievalButton), 
                    new FrameworkPropertyMetadata(" ", 
                            FrameworkPropertyMetadataOptions.AffectsMeasure));

            // ����� �̺�Ʈ ���
            KnockEvent = 
                EventManager.RegisterRoutedEvent("Knock", RoutingStrategy.Bubble, 
                        typeof(RoutedEventHandler), typeof(MedievalButton));

            PreviewKnockEvent = 
                EventManager.RegisterRoutedEvent("PreviewKnock", 
                        RoutingStrategy.Tunnel,
                        typeof(RoutedEventHandler), typeof(MedievalButton));
        }

        // ���� ������Ƽ�� Public �������̽�
        public string Text
        {
            set { SetValue(TextProperty, value == null ? " " : value); }
            get { return (string)GetValue(TextProperty); }
        }

        // ����� �̺�Ʈ�� Public �������̽�
        public event RoutedEventHandler Knock
        {
            add { AddHandler(KnockEvent, value); }
            remove { RemoveHandler(KnockEvent, value); }
        }
        public event RoutedEventHandler PreviewKnock
        {
            add { AddHandler(PreviewKnockEvent, value); }
            remove { RemoveHandler(PreviewKnockEvent, value); }
        }

        // ��ư�� ũ�Ⱑ ����� �� MeasureOverride�� ȣ���
        protected override Size MeasureOverride(Size sizeAvailable)
        {
            formtxt = new FormattedText(
                    Text, CultureInfo.CurrentCulture, FlowDirection,
                    new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),
                    FontSize, Foreground);

            // ũ�⸦ ����� �� Padding�� ���
            Size sizeDesired = new Size(Math.Max(48, formtxt.Width) + 4, 
                                                     formtxt.Height + 4);
            sizeDesired.Width += Padding.Left + Padding.Right;
            sizeDesired.Height += Padding.Top + Padding.Bottom;

            return sizeDesired;
        }

        // ��ư�� �ٽ� �׸��� ���� OnRender ȣ��
        protected override void OnRender(DrawingContext dc)
        {
            
            // ���� ����
            Brush brushBackground = SystemColors.ControlBrush;

            if (isMouseReallyOver && IsMouseCaptured)
                brushBackground = SystemColors.ControlDarkBrush;

            // ���� �β� ����
            Pen pen = new Pen(Foreground, IsMouseOver ? 2 : 1);

            // �ձ� �𼭸��� �簢���� �׸�
           dc.DrawRoundedRectangle(brushBackground, pen,
                                    new Rect(new Point(0, 0), RenderSize), 4, 4);

            // ����� ����
            formtxt.SetForegroundBrush(
                        IsEnabled ? Foreground : SystemColors.ControlDarkBrush);

            // �ؽ�Ʈ�� ������ ����
            Point ptText = new Point(2, 2);
            
            switch (HorizontalContentAlignment)
            {
                case HorizontalAlignment.Left:
                    ptText.X += Padding.Left;
                    break;

                case HorizontalAlignment.Right:
                    ptText.X += RenderSize.Width - formtxt.Width - Padding.Right;
                    break;

                case HorizontalAlignment.Center:
                case HorizontalAlignment.Stretch:
                    ptText.X += (RenderSize.Width - formtxt.Width - 
                            Padding.Left - Padding.Right) / 2;
                    break;
            }
            switch (VerticalContentAlignment)
            {
                case VerticalAlignment.Top:
                    ptText.Y += Padding.Top;
                    break;

                case VerticalAlignment.Bottom:
                    ptText.Y += 
                        RenderSize.Height - formtxt.Height - Padding.Bottom;
                    break;

                case VerticalAlignment.Center:
                case VerticalAlignment.Stretch:
                    ptText.Y += (RenderSize.Height - formtxt.Height -
                            Padding.Top - Padding.Bottom) / 2;
                    break;
            }

            // �ؽ�Ʈ ���
            dc.DrawText(formtxt, ptText);
        }
        // ��ư�� ����� ������ �ִ� Mouse �̺�Ʈ
        protected override void OnMouseEnter(MouseEventArgs args)
        {
            base.OnMouseEnter(args);
            InvalidateVisual();
        }
        protected override void OnMouseLeave(MouseEventArgs args)
        {
            base.OnMouseLeave(args);
            InvalidateVisual();
        }
        protected override void OnMouseMove(MouseEventArgs args)
        {
            base.OnMouseMove(args);

            Point pt = args.GetPosition(this);
            bool isReallyOverNow = (pt.X >= 0 && pt.X < ActualWidth &&
                                    pt.Y >= 0 && pt.Y < ActualHeight);
            if (isReallyOverNow != isMouseReallyOver)
            {
                isMouseReallyOver = isReallyOverNow;
                InvalidateVisual();
            }
        }

        // 'Knock' �̺�Ʈ�� �߻���Ű�� �۾��� ����
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs args)
        {
            base.OnMouseLeftButtonDown(args);
            CaptureMouse();
            InvalidateVisual();
            args.Handled = true;
        }

        // �� �̺�Ʈ�� ������ 'Knock' �̺�Ʈ �߻�
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs args)
        {
            base.OnMouseLeftButtonUp(args);

            if (IsMouseCaptured)
            {
                if (isMouseReallyOver)
                {
                    OnPreviewKnock();
                    OnKnock();
                }
                args.Handled = true;
                Mouse.Capture(null);
            }
        }

        // ���콺 ĸó�� ����Ǹ� �ٽ� �׸�
        protected override void OnLostMouseCapture(MouseEventArgs args)
        {
            base.OnLostMouseCapture(args);
            InvalidateVisual();
        }

        // Space bar �Ǵ� Enter Ű�� ������ ��ư�� ������ ȿ��
        protected override void OnKeyDown(KeyEventArgs args)
        {
            base.OnKeyDown(args);
            if (args.Key == Key.Space || args.Key == Key.Enter)
                args.Handled = true;
        }
        protected override void OnKeyUp(KeyEventArgs args)
        {
            base.OnKeyUp(args);
            if (args.Key == Key.Space || args.Key == Key.Enter)
            {
                OnPreviewKnock();
                OnKnock();
                args.Handled = true;
            }
        }

        // OnKnock �޼ҵ忡�� 'Knock' �̺�Ʈ �߻�
        protected virtual void OnKnock()
        {
            RoutedEventArgs argsEvent = new RoutedEventArgs();
            argsEvent.RoutedEvent = MedievalButton.PreviewKnockEvent;
            argsEvent.Source = this;
            RaiseEvent(argsEvent);
        }

        // OnPreviewKnock �޼ҵ忡�� 'PreviewKnock' �̺�Ʈ �߻�
        protected virtual void OnPreviewKnock()
        {
            RoutedEventArgs argsEvent = new RoutedEventArgs();
            argsEvent.RoutedEvent = MedievalButton.KnockEvent;
            argsEvent.Source = this;
            RaiseEvent(argsEvent);
        }
    }
}
