//----------------------------------------------
// DirectoryPage.cs (c) 2006 by Charles Petzold
//----------------------------------------------
using Petzold.RecurseDirectoriesIncrementally;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Petzold.ComputerDatingWizard
{
    public partial class DirectoryPage : PageFunction<DirectoryInfo>
    {
        // ������.
        public DirectoryPage()
        {
            InitializeComponent();
            treevue.SelectedItemChanged += TreeViewOnSelectedItemChanged;
        }
        // ok��ư�� Ȱ��ȭ��Ű�� �̺�Ʈ �ڵ鷯.
        void TreeViewOnSelectedItemChanged(object sender,       
                            RoutedPropertyChangedEventArgs<object> args)
        {
            btnOk.IsEnabled = args.NewValue != null;        //��ư�� ���õǾ������� Ȱ��ȭ
        }
        //  Cancel �� OK ��ư�� �̺�Ʈ�ڵ鷯
        void CancelButtonOnClick(object sender, RoutedEventArgs args)
        {
            OnReturn(new ReturnEventArgs<DirectoryInfo>());         
        }
        void OkButtonOnClick(object sender, RoutedEventArgs args)
        {
            DirectoryInfo dirinfo =                 
                (treevue.SelectedItem as DirectoryTreeViewItem).DirectoryInfo;      //�ش� ���丮�� ����

            OnReturn(new ReturnEventArgs<DirectoryInfo>(dirinfo));      //dirinfo���ڸ� �ѱ�
        }
    }
}
