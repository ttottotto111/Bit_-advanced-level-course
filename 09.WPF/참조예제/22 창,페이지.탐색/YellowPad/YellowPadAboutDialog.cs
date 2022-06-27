//-----------------------------------------------------
// YellowPadAboutDialog.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using System;
using System.Diagnostics;           // Process class�� ���� NameSpace.
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Markup;
using System.Windows.Navigation;    //RequestNavigateEventArgs�� ���� NameSpace.

namespace Petzold.YellowPad
{
    public partial class YellowPadAboutDialog
    {
        public YellowPadAboutDialog()
        {
            InitializeComponent();

            // ���۰�/���� ���� Drawing ��ü�� ������ Image ������Ʈ�� ����.
            Uri uri = new Uri("pack://application:,,,/Images/Signature.xaml");
            Stream stream = Application.GetResourceStream(uri).Stream;
            Drawing drawing = (Drawing)XamlReader.Load(stream);
            stream.Close();

            imgSignature.Source = new DrawingImage(drawing);
        }
        // ������ ��ũ�� Ŭ���Ǹ� ������ ������Ʈ�� �̵�.
        void LinkOnRequestNavigate(object sender, RequestNavigateEventArgs args)
        {
            Process.Start(args.Uri.OriginalString);
            args.Handled = true;
        }
    }
}
