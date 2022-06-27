using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _1117
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {
        private People people = new People();  //데이터 컬렉션
        private Person per = null;             //데이터 컬렉션 중 하나를 선택

        public Window1()
        {
            InitializeComponent();

            per = people[0];

            UpdateDataToUI();
            UpdateListBox();
        }

        #region Data -> UI
        private void UpdateDataToUI()
        {
            UpdateNameToUI();
            UpdatePhoneToUI();
            UpdateAgeToUI();
        }
        private void UpdateNameToUI()
        {
            if (per == null)
            {
                name.Text         = "";
                nameLabel.Content = "";
            }
            else
            {
                name.Text           = per.Name;
                nameLabel.Content   = per.Name;
            }
        }
        private void UpdatePhoneToUI()
        {
            if (per == null)
            {
                phone.Text          = "";
                phoneLabel.Content  = "";
            }
            else
            {
                phone.Text          = per.Phone;
                phoneLabel.Content  = per.Phone;
            }
        }
        private void UpdateAgeToUI()
        {
            if (per == null)
            {
                age.Text = "";
                ageLabel.Content = "";
            }
            else
            {
                age.Text = per.Age.ToString();
                ageLabel.Content = per.Age.ToString();
            }
        }
        private void UpdateListBox()
        {
            listbox.Items.Clear();

            foreach(Person per in people)
            {
                listbox.Items.Add(per); //per.ToString()
            }
        }
        #endregion

        #region UI -> Data
        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {
            //per.Name = name.Text;
            ////Title = per.Name;
            nameLabel.Content = name.Text;
            //UpdateListBox();
        }

        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            //per.Phone = phone.Text;
            ////Title = per.Phone;
            phoneLabel.Content = phone.Text;
            //UpdateListBox();
        }

        private void age_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //per.Age = int.Parse(age.Text);
                ////Title = per.Age.ToString();
                ageLabel.Content = int.Parse(age.Text);
                //UpdateListBox();
            }
            catch
            {

            }
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listbox.SelectedIndex >= 0)
            {
                per = people[listbox.SelectedIndex];
                UpdateDataToUI();
            }
        }

        #endregion
        
        #region 버튼 핸들러(추가, 삭제, 변경)
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || phone.Text == "" || age.Text == "")
                return;

            people.Add(new Person() {
                Name = name.Text, Phone = phone.Text, Age = int.Parse(age.Text) });

            UpdateListBox();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (listbox.SelectedIndex < 0)
                return;

            people.RemoveAt(listbox.SelectedIndex);

            //삭제 후 per 선택처리
            if (people.Count == 0)
                per = null;
            else
                per = people[0];

            //화면 갱신
            UpdateDataToUI();   //name, phone, age
            UpdateListBox();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || phone.Text == "" || age.Text == "")
                return;

            //data <- UI
            per.Name    = name.Text;
            per.Phone   = phone.Text;
            per.Age     = int.Parse(age.Text);

            UpdateDataToUI();
            UpdateListBox();
        }
        #endregion
    }
}
