//-----------------------------------------------
// CalculateInHex.cs (c) 2006 by Charles Petzold
//-----------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Petzold.CalculateInHex
{
    public class CalculateInHex : Window
    {
        // Private �ʵ�
        RoundedButton btnDisplay;
        ulong numDisplay;
        ulong numFirst;
        bool bNewNumber = true;
        char chOperation = '=';

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new CalculateInHex());
        }
        // ������
        public CalculateInHex()
        {
            Title = "Calculate in Hex";
            SizeToContent = SizeToContent.WidthAndHeight;       // ������ ũ�⸦ â�� ũ�⿡ �°� �ڵ����� ����
            ResizeMode = ResizeMode.CanMinimize;                // â �ּ�ȭ�� ������ ��� ����

            // Grid�� �����ϰ� Content�� ����
            Grid grid = new Grid();
            grid.Margin = new Thickness(4);                     // grid���� ����
            Content = grid;                                     // grid�� Content�� ����

            // 5���� ���� ����
            for (int i = 0; i < 5; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width = GridLength.Auto;                    // col�� �ʺ� �ڵ� ����
                grid.ColumnDefinitions.Add(col);                // 5���� ���� ����
            }

            // 7���� ���� ����
            for (int i = 0; i < 7; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = GridLength.Auto;                   // row�� ���� �ڵ� ����
                grid.RowDefinitions.Add(row);                   // 7���� ���� ����
            }

            // ��ư�� ������ �ؽ�Ʈ
            string[] strButtons = { "0",
                                    "D", "E", "F", "+", "&",
                                    "A", "B", "C", "-", "|",
                                    "7", "8", "9", "*", "^",
                                    "4", "5", "6", "/", "<<",
                                    "1", "2", "3", "%", ">>", 
                                    "0", "Back", "Equals" };
            int iRow = 0, iCol = 0;

            // ��ư ����
            foreach (string str in strButtons)
            {
                // RoundedButton ����
                RoundedButton btn = new RoundedButton();
                btn.Focusable = false;
                btn.Height = 32;                            // ��ư ����
                btn.Margin = new Thickness(4);              // ��ư ���� ����
                btn.Click += ButtonOnClick;

                // TextBlock�� �����ؼ� RoundedButton�� �ڽ����� ����
                TextBlock txt = new TextBlock();
                txt.Text = str;
                btn.Child = txt;

                // RoundedButton�� Grid�� �߰�
                grid.Children.Add(btn);
                Grid.SetRow(btn, iRow);
                Grid.SetColumn(btn, iCol);

                // ��ư ��� �� ���� ��Ȳ ó��
                if (iRow == 0 && iCol == 0)
                {
                    btnDisplay = btn;
                    btn.Margin = new Thickness(4, 4, 4, 6);
                    Grid.SetColumnSpan(btn, 5);                 // btn�� 5���� ���� ��ģ��.
                    iRow = 1;
                }

                // Back�� Equals ��ư ó��
                else if (iRow == 6 && iCol > 0)
                {
                    Grid.SetColumnSpan(btn, 2);
                    iCol += 2;
                }

                // ������ ��ư�� ���
                else
                {
                    btn.Width = 32;
                    if (0 == (iCol = (iCol + 1) % 5))
                        iRow++;
                }
            }
        }

        // Click �̺�Ʈ �ڵ鷯
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            // Ŭ���� ��ư ���ϱ�
            RoundedButton btn = args.Source as RoundedButton;

            if (btn == null)
                return;

            // ��ư �ؽ�Ʈ�� ù ���� ���ϱ�
            string strButton = (btn.Child as TextBlock).Text;
            char chButton = strButton[0];

            // �� ���� Ư���� ���
            if (strButton == "Equals")
                chButton = '=';

            if (btn == btnDisplay)
                numDisplay = 0;

            else if (strButton == "Back")
                numDisplay /= 16;

            // 16���� ����
            else if (Char.IsLetterOrDigit(chButton))
            {
                if (bNewNumber)
                {
                    numFirst = numDisplay;
                    numDisplay = 0;
                    bNewNumber = false;
                }
                if (numDisplay <= ulong.MaxValue >> 4)
                    numDisplay = 16 * numDisplay + (ulong)(chButton - 
                                    (Char.IsDigit(chButton) ? '0' : 'A' - 10));
            }

            // ����
            else
            {
                if (!bNewNumber)
                {
                    switch (chOperation)
                    {
                        case '=': break;
                        case '+': numDisplay = numFirst + numDisplay; break;
                        case '-': numDisplay = numFirst - numDisplay; break;
                        case '*': numDisplay = numFirst * numDisplay; break;
                        case '&': numDisplay = numFirst & numDisplay; break;
                        case '|': numDisplay = numFirst | numDisplay; break;
                        case '^': numDisplay = numFirst ^ numDisplay; break;
                        case '<': numDisplay = numFirst << (int)numDisplay; break;
                        case '>': numDisplay = numFirst >> (int)numDisplay; break;
                        case '/':
                            numDisplay = 
                                numDisplay != 0 ? numFirst / numDisplay : 
                                                  ulong.MaxValue;
                            break;
                        case '%':
                            numDisplay = 
                                numDisplay != 0 ? numFirst % numDisplay : 
                                                  ulong.MaxValue;
                            break;
                        default: numDisplay = 0; break;
                    }
                }
                bNewNumber = true;
                chOperation = chButton;
            }

            // ��� ���� ����
            TextBlock text = new TextBlock();
            text.Text = String.Format("{0:X}", numDisplay);
            btnDisplay.Child = text;
        }

        protected override void OnTextInput(TextCompositionEventArgs args)
        {
            base.OnTextInput(args);

            if (args.Text.Length == 0)
                return;

            // ���� �Է� ���ϱ�
            char chKey = Char.ToUpper(args.Text[0]);

            // ��ư�� ���� ����
            foreach (UIElement child in (Content as Grid).Children)
            {
                RoundedButton btn = child as RoundedButton;
                string strButton = (btn.Child as TextBlock).Text;

                // ��ġ�ϴ� ��ư�� Ȯ���ϱ� ���� ����
                if ((chKey == strButton[0] && btn != btnDisplay &&
                        strButton != "Equals" && strButton != "Back") ||
                    (chKey == '=' && strButton == "Equals") ||
                    (chKey == '\r' && strButton == "Equals") ||
                    (chKey == '\b' && strButton == "Back") ||
                    (chKey == '\x1B' && btn == btnDisplay))
                {
                    // Ű �Է��� ó���ϱ� ���� Click �̺�Ʈ�� �߻�
                    RoutedEventArgs argsClick = 
                        new RoutedEventArgs(RoundedButton.ClickEvent, btn);
                    btn.RaiseEvent(argsClick);

                    // ��ư�� ���� ��ó�� ǥ��
                    btn.IsPressed = true;

                    // ��ư�� �ٽ� ���� ���� ���·� ����� ���� Ÿ�̸� ����
                    DispatcherTimer tmr = new DispatcherTimer();
                    tmr.Interval = TimeSpan.FromMilliseconds(100);
                    tmr.Tag = btn;
                    tmr.Tick += TimerOnTick;
                    tmr.Start();

                    args.Handled = true;
                } 
            }
        }

        void TimerOnTick(object sender, EventArgs args)
        {
            // ���� ��ư ����
            DispatcherTimer tmr = sender as DispatcherTimer;
            RoundedButton btn = tmr.Tag as RoundedButton;
            btn.IsPressed = false;

            // Ÿ�̸� �����ϰ� �̺�Ʈ �ڵ鷯 ����
            tmr.Stop();
            tmr.Tick -= TimerOnTick;
        }
    }
}
