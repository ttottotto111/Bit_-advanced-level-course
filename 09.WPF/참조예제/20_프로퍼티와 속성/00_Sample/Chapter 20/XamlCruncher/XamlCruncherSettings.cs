//-----------------------------------------------------
// XamlCruncherSettings.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Petzold.XamlCruncher
{
    public class XamlCruncherSettings : Petzold.NotepadClone.NotepadCloneSettings
    {
        // ����� ��ȣ�� ���� �⺻ ����
        public Dock Orientation = Dock.Left;    // Dock��ġ�� Left�� ����
        public int TabSpaces = 4;               // ���� ������ ���� ������ 4ĭ���� ����
        public string StartupDocument =         // ���α׷� �������ڸ��� �ؽ�Ʈ�ڽ��� �������� ����
            "<Button xmlns=\"http://schemas.microsoft.com/winfx" + 
                        "/2006/xaml/presentation\"\r\n" +
            "        xmlns:x=\"http://schemas.microsoft.com/winfx" + 
                        "/2006/xaml\">\r\n" +
            "    Hello, XAML!\r\n" +
            "</Button>\n";

        // NotepadCloneSettings ���� �⺻ ������ �ʱ�ȭ�ϴ� ������
        public XamlCruncherSettings()
        {
            FontFamily = "Lucida Console";  // ��Ʈ ����
            FontSize = 10 / 0.75;           // ��Ʈ ������ ����
        }
    }
}