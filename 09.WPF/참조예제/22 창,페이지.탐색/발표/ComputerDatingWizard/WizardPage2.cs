//--------------------------------------------
// WizardPage2.cs (c) 2006 by Charles Petzold
//--------------------------------------------
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Petzold.ComputerDatingWizard
{
    public partial class WizardPage2
    {
        Vitals vitals;

        // ������.
        public WizardPage2(Vitals vitals)
        {
            InitializeComponent();
            this.vitals = vitals;
        }

        // Browse ��ư �̺�Ʈ �ڵ鷯.
        void BrowseButtonOnClick(object sender, RoutedEventArgs args)
        {
            DirectoryPage page = new DirectoryPage();
            page.Return += DirPageOnReturn;
            NavigationService.Navigate(page);
        }
        void DirPageOnReturn(object sender, ReturnEventArgs<DirectoryInfo> args)
        {
            if (args.Result != null)
                txtboxFavoriteDir.Text = args.Result.FullName;
        }
        // �ϴ� ��ư �̺�Ʈ �ڵ鷯.
        void PreviousButtonOnClick(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }
        void NextButtonOnClick(object sender, RoutedEventArgs args)
        {
            vitals.FavoriteOS = txtboxFavoriteOS.Text;      //���������� �Է������� �����ڷ� ����
            vitals.Directory = txtboxFavoriteDir.Text;

            if (NavigationService.CanGoForward)
                NavigationService.GoForward();
            else
            {
                WizardPage3 page = new WizardPage3(vitals);
                NavigationService.Navigate(page);
            }
        }
    }
}
