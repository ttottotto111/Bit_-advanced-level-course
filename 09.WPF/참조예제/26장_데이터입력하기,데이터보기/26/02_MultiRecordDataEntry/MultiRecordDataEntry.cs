//-----------------------------------------------------
// MultiRecordDataEntry.cs (c) 2006 by Charles Petzold
//-----------------------------------------------------
using Petzold.SingleRecordDataEntry;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Petzold.MultiRecordDataEntry
{
    public partial class MultiRecordDataEntry
    {
        People people;                                   // People Ŭ���� ��ü ����
        int index;                                          // Person �÷��� ��ü�� �ε��� ���� ���� ����

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new MultiRecordDataEntry());
        }

        public MultiRecordDataEntry()
        {
            InitializeComponent();

            // File New ����� �ùķ��̼�
            ApplicationCommands.New.Execute(null, this);

            // �г��� ù��° �ؽ�Ʈ�ڽ��� ��Ŀ���� �ش�.
            // pnlPerson�̶�� �̸��� xaml�ڵ忡�� ������ ����
            pnlPerson.Children[1].Focus();
        }

        // New�޴� Ŭ��
        void NewOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            people = new People();                          // People Ŭ���� ��ü ����
            InitializeNewPeopleObject();                    // �ʱ�ȭ �ż��� ȣ�� (People.cs)
        }

        // Open�޴� Ŭ��
        void OpenOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            people = People.Load(this);                     // Load �޼��� ���� ��ȯ�� ��ü ����       
            InitializeNewPeopleObject();                    // �ʱ�ȭ �ż��� ȣ�� (People.cs)
        }

        // Save�޴� Ŭ��
        void SaveOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            people.Save(this);                                  // Save �޼��� ȣ�� (People.cs)
        }

        // �ʱ�ȭ
        void InitializeNewPeopleObject()
        {
            index = 0;

            if (people.Count == 0)                           // �÷����� ������ ??
                people.Insert(0, new Person());             // 0��° �ε����� ���ο� Person��ü ����

            pnlPerson.DataContext = people[0];          // DataContext�� people�� 0��° �迭�� �ִ� ��ü�� ����
            EnableAndDisableButtons();                     // ��ư Ȱ��ȭ ���� �޼���          
        }

        // ó������ ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        void FirstOnClick(object sender, RoutedEventArgs args)
        {
            // DataContext�� �ε����� 0���� �ʱ�ȭ �ϸ�
            // people�� 0��° �ε����� ��ü�� �־��ش�. (�� ó����ü�� �̵�)
            pnlPerson.DataContext = people[index = 0];  
            EnableAndDisableButtons();
        }

        // ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        void PrevOnClick(object sender, RoutedEventArgs args)
        {
            // DataContext�� ���� �ε������� �ϳ� ����(�����迭) �ε����� ��ü�� �ִ´�.
            pnlPerson.DataContext = people[index -= 1];
            EnableAndDisableButtons();
        }

        // ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        void NextOnClick(object sender, RoutedEventArgs args)
        {
            pnlPerson.DataContext = people[index += 1];
            EnableAndDisableButtons();
        }

        // ������ ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        void LastOnClick(object sender, RoutedEventArgs args)
        {
            // DataContext�� ������ �ε��� ��ü�� �־��ش�.
            // �迭�� 0���� �����̹Ƿ� ���� Count���� -1�� ���־�� �Ѵ�.
            pnlPerson.DataContext = people[index = people.Count - 1];
            EnableAndDisableButtons();
        }

        // ������ �߰� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        void AddOnClick(object sender, RoutedEventArgs args)
        {
            people.Insert(index = people.Count, new Person());
            pnlPerson.DataContext = people[index];
            EnableAndDisableButtons();
        }

        // ������ ���� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
        void DelOnClick(object sender, RoutedEventArgs args)
        {
            people.RemoveAt(index);                      // ������ �ε������� ��� ����

            if (people.Count == 0)                         // ���� �ε����� 0�̶��?
                people.Insert(0, new Person());           // ���ο� 0��° �ε��� ��ü ����

            if (index > people.Count - 1)                 // ���� �ε����� ������ �̾��ٸ�
                index--;                                        // ����� ���� �ε��� ��ȣ -1�� ����
            
            pnlPerson.DataContext = people[index];   //DataContext�� ���� �ε��� ��ȣ�� ��ü�� ���� 
            EnableAndDisableButtons();
        }

        // ��ư Ȱ��ȭ ����
        void EnableAndDisableButtons()
        {
            // ����ǥ�õǰ� �ִ� ���ڵ尡 ó���� �ƴ϶�� '����' ��ư Ȱ��ȭ
            btnPrev.IsEnabled = index != 0;

            // ���� ǥ�õǰ� �ִ� ���ڵ尡 ������ ���ڵ尡 �ƴϸ� '����' ��ư Ȱ��ȭ
            btnNext.IsEnabled = index < people.Count - 1;

            // �г��� ù��° �ؽ�Ʈ�ڽ��� ��Ŀ���� �ش�.
            pnlPerson.Children[1].Focus();
        }
    }
}
