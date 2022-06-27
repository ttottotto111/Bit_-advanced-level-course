//-----------------------------------------------------
// YellowPadWindow.File.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace Petzold.YellowPad
{
    public partial class YellowPadWindow : Window
    {
        // File New command: ��� ���� ���� (�ʱ�ȭ).
        void NewOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            inkcanv.Strokes.Clear();
        }
        // File Open command: OpenFileDialog�� ���� ISF file�� �ε�.
        void OpenOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|" +
                         "All files (*.*)|*.*";

            if ((bool)dlg.ShowDialog(this))
            {
                try
                {
                    FileStream file = new FileStream(dlg.FileName, 
                                            FileMode.Open, FileAccess.Read);
                    inkcanv.Strokes = new StrokeCollection(file);
                    file.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }
            }
        }
        // File Save command: SaveFileDialog�� ����.
        void SaveOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ink Serialized Format (*.isf)|*.isf|" +
                         "XAML Drawing File (*.xaml)|*.xaml|" +
                         "All files (*.*)|*.*";

            if ((bool)dlg.ShowDialog(this))
            {
                try
                {
                    FileStream file = new FileStream(dlg.FileName, 
                                            FileMode.Create, FileAccess.Write);

                    if (dlg.FilterIndex == 1 || dlg.FilterIndex == 3)
                        inkcanv.Strokes.Save(file);

                    else
                    {
                        // DrawingGroup object�� Stroke(��) ����.
                        DrawingGroup drawgrp = new DrawingGroup();

                        foreach (Stroke strk in inkcanv.Strokes)
                        {
                            Color clr = strk.DrawingAttributes.Color;

                            if (strk.DrawingAttributes.IsHighlighter)
                                clr = Color.FromArgb(128, clr.R, clr.G, clr.B);

                            drawgrp.Children.Add(
                                new GeometryDrawing(
                                    new SolidColorBrush(clr),
                                    null, strk.GetGeometry()));
                        }
                        XamlWriter.Save(drawgrp, file);
                    }
                    file.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, Title);
                }
            }
        }
        // File Exit item: ���α׷� ����� â�� ���� �ݴ´�.
        void CloseOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            Close();
        }
    }
}
