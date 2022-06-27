//----------------------------------------------------------
// ListColorsEvenElegantlier.cs (c) 2006 by Charles Petzold
//----------------------------------------------------------
using Petzold.ListNamedBrushes;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Petzold.ListColorsEvenElegantlier
{
    public class ListColorsEvenElegantlier : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new ListColorsEvenElegantlier());
        }
        public ListColorsEvenElegantlier()
        {
            Title = "List Colors Even Elegantlier";

            // �׸��� DataTemplate ����
            DataTemplate template = new DataTemplate(typeof(NamedBrush));

            // ���� �г� ����� FrameworkElementFactory ����
            FrameworkElementFactory factoryStack =
                                new FrameworkElementFactory(typeof(StackPanel));
            factoryStack.SetValue(StackPanel.OrientationProperty, 
                                                Orientation.Horizontal);

            // DataTemplate ���־� Ʈ���� ��Ʈ ����
            template.VisualTree = factoryStack;

            // Rectangle ����� FrameworkElementFactory ����
            FrameworkElementFactory factoryRectangle =
                                new FrameworkElementFactory(typeof(Rectangle));
            factoryRectangle.SetValue(Rectangle.WidthProperty, 16.0);
            factoryRectangle.SetValue(Rectangle.HeightProperty, 16.0);
            factoryRectangle.SetValue(Rectangle.MarginProperty, new Thickness(2));
            factoryRectangle.SetValue(Rectangle.StrokeProperty, 
                                            SystemColors.WindowTextBrush);
            factoryRectangle.SetBinding(Rectangle.FillProperty, 
                                            new Binding("Brush"));
            // StackPanel �� factoryRectangle ��ü �߰�
            factoryStack.AppendChild(factoryRectangle);

            // TextBlock ����� FrameworkElementFactory ����
            FrameworkElementFactory factoryTextBlock =
                                new FrameworkElementFactory(typeof(TextBlock));
            factoryTextBlock.SetValue(TextBlock.VerticalAlignmentProperty,
                                            VerticalAlignment.Center);
            factoryTextBlock.SetValue(TextBlock.TextProperty, 
                                            new Binding("Name"));
            // StackPanel �� factoryTextBlock ��ü �߰�
            factoryStack.AppendChild(factoryTextBlock);

            // ������ Content�� ���� ����Ʈ �ڽ� ����
            ListBox lstbox = new ListBox();
            lstbox.Width = 150;
            lstbox.Height = 150;
            Content = lstbox;

            // ItemTemplate ������Ƽ�� ���� ������ template���� ����
            lstbox.ItemTemplate = template;
   
            // ItemsSource�� NameBrush ��ü �迭�� ����
            lstbox.ItemsSource = NamedBrush.All;

            // SelectedValue�� ������ ������ ���ε�
            lstbox.SelectedValuePath = "Brush";
            lstbox.SetBinding(ListBox.SelectedValueProperty, "Background");
            lstbox.DataContext = this;
        }
    }
}
