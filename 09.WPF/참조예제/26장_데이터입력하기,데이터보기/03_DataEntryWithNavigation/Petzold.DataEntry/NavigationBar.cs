//----------------------------------------------
// NavigationBar.cs (c) 2006 by Charles Petzold
//----------------------------------------------
using System;
using System.Collections;                   // IList ����
using System.Collections.Specialized;    // NotifyCollectionChangedEventArgs ����
using System.ComponentModel;         // ICollectionView ����
using System.Reflection;                    // ConstructorInfo ����
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Petzold.DataEntry
{
    public partial class NavigationBar : ToolBar
    {
        IList coll;
        ICollectionView collview;
        Type typeItem;

        // Public ������
        public NavigationBar()
        {
            InitializeComponent();
        }

        // Public ������Ƽ
        public IList Collection
        {
            set
            {
                coll = value;

                // CollectionView�� �����ϰ� �̺�Ʈ �ڵ鷯�� �ο�
                // ������ �⺻ �� ��ü ����
                collview = CollectionViewSource.GetDefaultView(coll);
                // ���� ������ �ٲ𶧸��� �߻��ϴ� �̺�Ʈ �ڵ鷯 ���
                collview.CurrentChanged += CollectionViewOnCurrentChanged;
                // 
                collview.CollectionChanged += CollectionViewOnCollectionChanged;

                // �ؽ�Ʈ�ڽ��� ��ư�� �ʱ�ȭ ��Ű�� ���� �̺�Ʈ �ڵ鷯 ȣ�� (NavigationBar.cs)
                CollectionViewOnCurrentChanged(null, null);

                // �ؽ�Ʈ��(�� �񽺹��� �Ѱ�) �ʱ�ȭ
                txtblkTotal.Text = coll.Count.ToString();
            }
            get
            {
                return coll;
            }
        }

        // ������ �÷����� �����ϴ� �׸��� Ÿ���̴�.
        // Add, New ��� ó���� ���� ���ȴ�.
        public Type ItemType
        {
            set { typeItem = value; }
            get { return typeItem; }
        }
      
        // CollectionView�� ���� �̺�Ʈ �ڵ鷯
        void CollectionViewOnCollectionChanged(object sender, 
                                        NotifyCollectionChangedEventArgs args)
        {
            txtblkTotal.Text = coll.Count.ToString();
        }

        void CollectionViewOnCurrentChanged(object sender, EventArgs args)
        {
            txtboxCurrent.Text = (1 + collview.CurrentPosition).ToString();
            btnPrev.IsEnabled = collview.CurrentPosition > 0;
            btnNext.IsEnabled = collview.CurrentPosition < coll.Count - 1;
            btnDel.IsEnabled = coll.Count > 1;
        }

        // ��ư Ŭ�� �̺�Ʈ ���� ---------------------------------------------------------------
        void FirstOnClick(object sender, RoutedEventArgs args)
        {
            // ICollectionVeiw���� �ڵ����� �յ� �÷������� �̵��� �� �ִ� �޼��� ����
            collview.MoveCurrentToFirst();
        }
        void PreviousOnClick(object sender, RoutedEventArgs args)
        {
            collview.MoveCurrentToPrevious();
        }
        void NextOnClick(object sender, RoutedEventArgs args)
        {
            collview.MoveCurrentToNext();
        }
        void LastOnClick(object sender, RoutedEventArgs args)
        {
            collview.MoveCurrentToLast();
        }

        // �� ������ �����
        void AddOnClick(object sender, RoutedEventArgs args)
        {
            // �̰� �ո����� �𸣰ԽῩ, �ƴ� �� ������ ���ּ��� ' ��'
            ConstructorInfo info =  typeItem.GetConstructor(System.Type.EmptyTypes);

            // ����Ʈ�� �׸��߰�
            coll.Add(info.Invoke(null));

            // ���� ������ �׸��� CurrentItem���� ����
            collview.MoveCurrentToLast();
        }

        void DeleteOnClick(object sender, RoutedEventArgs args)
        {
            // ������ġ�� �ε��� ����
            coll.RemoveAt(collview.CurrentPosition);
        }
        //----------------------------------------------------------------------------------------

        // ���� ���ڵ� ��ȣ ����ϴ� �ؽ�Ʈ �ڽ��� ���� �̺�Ʈ �ڵ鷯
        string strOriginal;

        // �ؽ�Ʈ �ڽ��� ��Ŀ���� �����Ҷ� �̺�Ʈ
        void TextBoxOnGotFocus(object sender, KeyboardFocusChangedEventArgs args)
        {
            // �ؽ�Ʈ�ڽ��� �ִ� �� ��������
            // ���⼭�� �ؽ�Ʈ �ڽ��� ���� �Է��� ������ ���ڵ� �̵��� ����
            strOriginal = txtboxCurrent.Text;
        }

        // �ؽ�Ʈ �ڽ��� ��Ŀ���� ��������� �̺�Ʈ
        void TextBoxOnLostFocus(object sender, KeyboardFocusChangedEventArgs args)
        {
            int current;

            // if���ȿ� ������ �� �𸣰ԽῩ, �ƴ� �� ���� �ٶ� ' ��'
            if (Int32.TryParse(txtboxCurrent.Text, out current))
                if (current > 0 && current <= coll.Count)
                    collview.MoveCurrentToPosition(current - 1);
            else
                txtboxCurrent.Text = strOriginal;
        }
        void TextBoxOnKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Escape)
            {
                // esc Ű�� �Է��ϸ� �ؽ�Ʈ�ڽ��� �ִ� ���� ���� ���ڵ� ������ �ٽ� ����
                txtboxCurrent.Text = strOriginal;
                args.Handled = true;
            }
            else if (args.Key == Key.Enter)
            {
                args.Handled = true;
            }
            else
                return;

            // ��Ŀ���� �� ������ �̵�.. �״ϱ� ������? �� �ִ� ������ �̵�
            MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
        }
    }
}
