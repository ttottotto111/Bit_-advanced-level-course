//-----------------------------------------------------
// DataEntryWithListBox.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using Petzold.MultiRecordDataEntry;
using Petzold.SingleRecordDataEntry;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.DataEntryWithListBox
{
    public partial class DataEntryWithListBox
    {
        ListCollectionView collview;
        People people;

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DataEntryWithListBox());
        }
        public DataEntryWithListBox()
        {
            InitializeComponent();

            // File New ����� �ùķ��̼�
            ApplicationCommands.New.Execute(null, this);

            // �г��� ù��° �ؽ�Ʈ�ڽ��� ��Ŀ���� �ش�.
            pnlPerson.Children[1].Focus();
        }

        // �����ϱ� �̺�Ʈ �ڵ鷯
        void NewOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            people = new People();
            people.Add(new Person());
            InitializeNewPeopleObject();
        }

        // �����Ϳ��� �̺�Ʈ �ڵ鷯 (���� IO�κ�) 
        void OpenOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            people = People.Load(this);

            if (people != null)
                InitializeNewPeopleObject();
        }
        // ������ ���� �޴� �̺�Ʈ �ڵ鷯 (���� IO�κ�)
        void SaveOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            people.Save(this);
        }

        void InitializeNewPeopleObject()
        {
            // People��ü�� ������� ListCollectionView ���� (����Ʈ!!)
            collview = new ListCollectionView(people);

            // ��(View)�� �����ϱ� ���� ������Ƽ�� ����
            // "LastName"�� �������� �� �ѵ� ������������ ����
            collview.SortDescriptions.Add(
                new SortDescription("LastName", ListSortDirection.Ascending));

            // ListCollectionView�� ���� ListBox�� PersonPanel�� ����
            lstbox.ItemsSource = collview;

            // ListBox�� �̿��� �÷����� Ž���ϱ� ���� ����
            pnlPerson.DataContext = collview;

            // ����Ʈ�ڽ��� SelectedIndex �����ϱ�
            if (lstbox.Items.Count > 0)                     // ����Ʈ�ڽ��� �������� ������ ' ��'
                lstbox.SelectedIndex = 0;                  // �� ������ ���õǾ� �ְ�
        }

        // ������ �߰� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        void AddOnClick(object sender, RoutedEventArgs args)
        {
            Person person = new Person();
            people.Add(person);
            lstbox.SelectedItem = person;
            pnlPerson.Children[1].Focus();

            // ����Ʈ�� ����
            collview.Refresh();
        }

        void DeleteOnClick(object sender, RoutedEventArgs args)
        {
            if (lstbox.SelectedItem != null)
            {
                people.Remove(lstbox.SelectedItem as Person);

                if (lstbox.Items.Count > 0)
                    lstbox.SelectedIndex = 0;
                else
                {
                    // ������ �� �����Ͷ� �־��... ��� �س��׿� > ��<
                    AddOnClick(sender, args);
                }
            }
        }
    }
}
