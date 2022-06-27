//--------------------------------------------
// WizardPage3.cs (c) 2006 by Charles Petzold
//--------------------------------------------
using System;
using System.Windows;
using System.Windows.Controls;

namespace Petzold.ComputerDatingWizard
{
    public partial class WizardPage3: Page
    {
        Vitals vitals;

        // ������.
        public WizardPage3(Vitals vitals)
        {
            InitializeComponent();
            this.vitals = vitals;
        }
        // Previous �� Finish ��ư �̺�Ʈ �ڵ鷯.
        void PreviousButtonOnClick(object sender, RoutedEventArgs args)
        {
            NavigationService.GoBack();
        }
        void FinishButtonOnClick(object sender, RoutedEventArgs args)
        {
            // �� �������� ���� ����.
            vitals.MomsMaidenName = txtboxMom.Text;
            vitals.Pet = 
                Vitals.GetCheckedRadioButton(grpboxPet).Content as string;
            vitals.Income = 
                Vitals.GetCheckedRadioButton(grpboxIncome).Content as string;

            // �׻� ������ �������� �ٽû���.
            WizardPage4 page = new WizardPage4(vitals);
            NavigationService.Navigate(page);
        }
    }
}
