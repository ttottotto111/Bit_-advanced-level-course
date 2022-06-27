//-----------------------------------------------------
// YellowPadWindow.Edit.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;

namespace Petzold.YellowPad
{
    public partial class YellowPadWindow : Window
    {
        // ���� ���õǾ� ������ Format �׸� Ȱ��ȭ.
        void EditOnOpened(object sender, RoutedEventArgs args)
        {
            itemFormat.IsEnabled = inkcanv.GetSelectedStrokes().Count > 0;
        }
        // ���� ���õǾ� ������ Cut, Copy, Delete �׸� Ȱ��ȭ.
        void CutCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = inkcanv.GetSelectedStrokes().Count > 0;
        }
        // InkCanvas�� �޼ҵ带 �̿��� Cut�� Copy ����.
        void CutOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            inkcanv.CutSelection();
        }
        void CopyOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            inkcanv.CopySelection();
        }
        // Ŭ������ �� �׸��� �ٿ� �ֱⰡ �����ϸ� Paste �׸� Ȱ��ȭ.

        void PasteCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = inkcanv.CanPaste();
        }
        // InkCanvas���� �޼ҵ带 �̿��Ͽ� Paste ����.
        void PasteOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            inkcanv.Paste();
        }
        // Delete�� "����"���� 
        void DeleteOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            foreach (Stroke strk in inkcanv.GetSelectedStrokes())
                inkcanv.Strokes.Remove(strk);
        }
        // Select All item: ��� �׸� (Stroke)����.
        void SelectAllOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            inkcanv.Select(inkcanv.Strokes);
        }
        // Format Selection item: StylusToolDialog ȣ��(Invoke).
        void FormatOnClick(object sender, RoutedEventArgs args)
        {
            StylusToolDialog dlg = new StylusToolDialog();
            dlg.Owner = this;
            dlg.Title = "Format Selection";

            // ó�� ���õ� ���� DrawingAttributes�� ���� ����.
            StrokeCollection strokes = inkcanv.GetSelectedStrokes();

            if (strokes.Count > 0)
                dlg.DrawingAttributes = strokes[0].DrawingAttributes;
            else
                dlg.DrawingAttributes = inkcanv.DefaultDrawingAttributes;

            if ((bool)dlg.ShowDialog().GetValueOrDefault())
            {
                // ���õ� ��缱�� DrawingAttributes�� ����.
                foreach (Stroke strk in strokes)
                    strk.DrawingAttributes = dlg.DrawingAttributes;
            }
        }
    }
}
