//------------------------------------------------------
// SingleRecordDataEntry.cs (c) 2006 by Charles Petzold
//------------------------------------------------------
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Petzold.SingleRecordDataEntry
{
    public partial class SingleRecordDataEntry : Window
    {
        // ���Ͽ���, ���� ���̾�α� ��ﶧ �������ĺκп� ����
        const string strFilter = "Person XML files (*.PersonXml)|" +
                                 "*.PersonXml|All files (*.*)|*.*";

        // Person��ü�� xml �������� �����ϱ� ���� ��ü ����
        XmlSerializer xml = new XmlSerializer(typeof(Person));

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new SingleRecordDataEntry());
        }
        public SingleRecordDataEntry()
        {
            InitializeComponent();

            // File New ����� �ùķ��̼�
            ApplicationCommands.New.Execute(null, this);

            // �г��� ù��° �ؽ�Ʈ�ڽ��� ��Ŀ���� �ش�.
            // pnlPerson�̶�� �̸��� xaml�ڵ忡�� ������ ����
            pnlPerson.Children[1].Focus();
        }
        // �����ϱ� �̺�Ʈ �ڵ鷯
        void NewOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            // Person Ÿ���� ���ο� ��ü ���� �ϰ� PersonPanel�� DataContext������Ƽ�� ����
            // �̷��� �ϸ� Person��ü�� �⺻���� PersonPanel�� ǥ�õ�
            pnlPerson.DataContext = new Person();
        }

        // �����Ϳ��� �̺�Ʈ �ڵ鷯 (���� IO�κ�) 
        // ������ ������� ���̴� Deserialize�� Serialize �κ�
        void OpenOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            OpenFileDialog dlg = new OpenFileDialog();    // ���Ͽ��� ���̾�α� ��ü ����
            dlg.Filter = strFilter;                                   // ǥ�õǴ� �������� ���� (�������ĺκ�)
            Person pers;                                            // PersonŬ���� ��ü ����

            if ((bool)dlg.ShowDialog(this))                      // ���Ͽ��� ���̾�αװ� ����������?
            {
                try
                {
                    // �����̸� ���ڿ��� �д� ��Ʈ�� ���� ��ü ����
                    StreamReader reader = new StreamReader(dlg.FileName);
                    // ��Ʈ������ ��ü�� �籸�� �ؼ� Person ��ü�� ����
                    pers = (Person) xml.Deserialize(reader);
                    reader.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("������ �����ھ�� ��  _�� : " + exc.Message, 
                                    Title, MessageBoxButton.OK,  MessageBoxImage.Exclamation);
                    return;
                }
                // DataContext�� ��Ұ� ���ε��� ���Ǵ� ������ �ҽ��� ���� ���� �� ��� ��
                // ���ε��� ��Ÿ Ư���� �θ� ��ҷκ��� ��� �� �� �ֵ��� �ϴ� ����.
                pnlPerson.DataContext = pers;
            }
        }

        // ������ ���� �޴� �̺�Ʈ �ڵ鷯 (���� IO�κ�)
        void SaveOnExecuted(object sender, ExecutedRoutedEventArgs args)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = strFilter;

            if ((bool)dlg.ShowDialog(this))
            {
                try
                {
                    StreamWriter writer = new StreamWriter(dlg.FileName);
                    // �о ����
                    xml.Serialize(writer, pnlPerson.DataContext);
                    writer.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("�� �̰� ���� ���ϰڽ� ' ��'  : " + exc.Message,
                                    Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return;
                }
            }
        }
    }
}
