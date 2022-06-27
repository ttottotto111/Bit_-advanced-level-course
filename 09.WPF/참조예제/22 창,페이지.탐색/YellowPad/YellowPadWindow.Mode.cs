//-----------------------------------------------------
// YellowPadWindow.Mode.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.YellowPad
{
    public partial class YellowPadWindow : Window
    {
        // Stylus-Mode : submenu �� �ϳ��� �׸��� ������ üũ�ؾ��Ѵ�.
        void StylusModeOnOpened(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;

            foreach (MenuItem child in item.Items)
                child.IsChecked = inkcanv.EditingMode ==
                                    (InkCanvasEditingMode)child.Tag;
        }
        // ������ �׸��� EditingMode property�� ����.
        void StylusModeOnClick(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;
            inkcanv.EditingMode = (InkCanvasEditingMode)item.Tag;
        }
        // Eraser-Mode : submenu �� �ϳ��� �׸��� ������ üũ�ؾ��Ѵ�.
        void EraserModeOnOpened(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;

            foreach (MenuItem child in item.Items)
                child.IsChecked = inkcanv.EditingModeInverted ==
                                    (InkCanvasEditingMode)child.Tag;
        }
        // ������ �׸����κ��� EditingModeInverted property����.
        void EraserModeOnClick(object sender, RoutedEventArgs args)
        {
            MenuItem item = sender as MenuItem;
            inkcanv.EditingModeInverted = (InkCanvasEditingMode)item.Tag;
        }
    }
}
