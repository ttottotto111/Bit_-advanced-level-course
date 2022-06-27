//---------------------------------------------------
// BuildButtonFactory.cs (c) 2006 by Charles Petzold
//---------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.BuildButtonFactory
{
    public class BuildButtonFactory : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new BuildButtonFactory());
        }
        public BuildButtonFactory()
        {
            Title = "Build Button Factory";

            // Button ��ü�� ���� ControlTemplate�� ����
            // ��Ʈ���� ������ ������ ���Ѵ�.
            ControlTemplate template = new ControlTemplate(typeof(Button));         // ������Ʈ���� ����, ������Ʈ�� ������Ƽ�� ��ȭ�� ����� �׿� ���� �����ϴ� Ʈ���� ����

            // Border Ŭ������ ���� FrameworkElementFactory�� ����
            FrameworkElementFactory factoryBorder = new FrameworkElementFactory(typeof(Border));

            // ���߿� �����ϱ� ���� �̸��� ����
            factoryBorder.Name = "border";

            // �⺻ ������Ƽ���� ����
            factoryBorder.SetValue(Border.BorderBrushProperty, Brushes.Red);        // �ܰ��� ����
            factoryBorder.SetValue(Border.BorderThicknessProperty,                  // �ܰ��� �β�
                                   new Thickness(3));       
            factoryBorder.SetValue(Border.BackgroundProperty,                       // ���� ����
                                   SystemColors.ControlLightBrush);

            // ContentPresenter Ŭ������ ���� FrameworkElementFactory�� ����
            FrameworkElementFactory factoryContent = new FrameworkElementFactory(typeof(ContentPresenter));

            // ���߿� �����ϱ� ���� �̸��� ����
            factoryContent.Name = "content";

            // �� ���� ContentPresenter ������Ƽ�� Button ������Ƽ�� ���ε�
            factoryContent.SetValue(ContentPresenter.ContentProperty, new TemplateBindingExtension(Button.ContentProperty));

            // ��ư�� Padding�� ����Ʈ�� Margin��!
            factoryContent.SetValue(ContentPresenter.MarginProperty, new TemplateBindingExtension(Button.PaddingProperty));

            // ContentPresenter�� Border�� �ڽ����� ����
            factoryBorder.AppendChild(factoryContent);

            // Border�� ���־� Ʈ���� ��Ʈ ������Ʈ�� ����
            template.VisualTree = factoryBorder;

            // IsMouseOver�� true�� �ɶ��� Trigger�� ����
            // Trigger - ���Ǻ� �۾��� �����Ѵ�.
            Trigger trig = new Trigger();
            trig.Property = UIElement.IsMouseOverProperty;
            trig.Value = true;

            // �� Ʈ���ſ� ������ Setter�� ����
            // "Border" ������Ʈ�� CornerRadius ������Ƽ�� ����
            Setter set = new Setter();
            set.Property = Border.CornerRadiusProperty;
            set.Value = new CornerRadius(24);
            set.TargetName = "border";                              // �տ��� ���� �̸��� ����( Trigger �۾��� �Ҷ��� Ÿ���� �� )

            // Trigger�� Setters �÷��ǿ� Setter�� �߰�
            trig.Setters.Add(set);

            // ����� ������� FontStyle�� �����Ű�� Setter�� ����
            // (��ư�� ������Ƽ�̹Ƿ� TargetName�� ���ʿ���)
            set = new Setter();
            set.Property = Control.FontStyleProperty;
            set.Value = FontStyles.Italic;

            // ���� ���� �������, �� Setter�� Ʈ������ Setter �÷���
            trig.Setters.Add(set);

            // Ʈ���Ÿ� ���ø��� �߰�
            template.Triggers.Add(trig);

            // ����� ������� IsPressed�� ���� Ʈ���Ÿ� ����
            trig = new Trigger();
            trig.Property = Button.IsPressedProperty;
            trig.Value = true;

            set = new Setter();
            set.Property = Border.BackgroundProperty;
            set.Value = SystemColors.ControlDarkBrush;
            set.TargetName = "border";

            // Trigger�� Setters �÷��ǿ� Setter�� �߰�
            trig.Setters.Add(set);

            // Ʈ���Ÿ� ���ø��� �߰�
            template.Triggers.Add(trig);

            // ���������� Button�� ����
            Button btn = new Button();

            // ���ø� ����
            btn.Template = template;

            // ��Ÿ ������Ƽ ����
            btn.Content = "Button with Custom Template";
            btn.Padding = new Thickness(20);
            btn.FontSize = 48;
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick;

            Content = btn;
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("You clicked the button", Title);
        } 
    }
}
