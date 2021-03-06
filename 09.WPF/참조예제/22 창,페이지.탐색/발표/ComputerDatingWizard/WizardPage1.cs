//--------------------------------------------
// WizardPage1.cs (c) 2006 by Charles Petzold
//--------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.ComputerDatingWizard
{
    public partial class WizardPage1: Page
    {
        Vitals vitals;

        // Constructors.
        public WizardPage1(Vitals vitals)
        {
            InitializeComponent();
            this.vitals = vitals;           //페이지 전체에서 사용된 Vitals 객체를 받아 필드에 저장
        }
        // Event handlers for Previous and Back buttons.
        void PreviousButtonOnClick(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }
        void NextButtonOnClick(object sender, RoutedEventArgs args)
        {
            vitals.Name = txtboxName.Text;                      //정보 저장            
            vitals.Home = 
                Vitals.GetCheckedRadioButton(grpboxHome).Content as string;     
            vitals.Gender = 
                Vitals.GetCheckedRadioButton(grpboxGender).Content as string;

            if (NavigationService.CanGoForward)
                NavigationService.GoForward();
            else
            {
                WizardPage2 page = new WizardPage2(vitals);
                NavigationService.Navigate(page);
            }
        }
    }
}

