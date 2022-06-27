//---------------------------------------
// People.cs (c) 2006 by Charles Petzold
//---------------------------------------
using Microsoft.Win32;
using Petzold.SingleRecordDataEntry;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows;
using System.Xml.Serialization;

namespace Petzold.MultiRecordDataEntry
{
    // ObservableCollection : 
    // �׸��� �߰� �Ǵ� ���ŵǰų� ��ü����� ���� ������ �� 
    // �˸��� �����ϴ� ���� ������ �÷���
    // ���ʸ� Ŭ���� �̱� ������ Person Ÿ���� ���ο� ��ü�� �÷��ǿ� �߰��� �� ĳ���� ���ص� ��
    public class People : ObservableCollection<Person>
    {
        // ���Ͽ���, ���� ���̾�α� ��ﶧ �������ĺκп� ����
        const string strFilter = "People XML files (*.PeopleXml)|" +
                                 "*.PeopleXml|All files (*.*)|*.*";

        // PeopleŸ�� ��ü ��ȯ�ϴ� ���� �޼���, WindowŸ�� ��ü�� ���ڷ� ����
        public static People Load(Window win)               
        {
            OpenFileDialog dlg = new OpenFileDialog();      // ���Ͽ��� ���̾�α� ��ü ����
            dlg.Filter = strFilter;                                     // ǥ�õǴ� �������� ���� (�������ĺκ�)
            People people = null;                                  // People ��ü �ʱ�ȭ

            if ((bool)dlg.ShowDialog(win))
            {
                try
                {
                    // �����̸� ���ڿ��� �д� ��Ʈ�� ���� ��ü ����
                    StreamReader reader = new StreamReader(dlg.FileName);

                    // Person��ü�� xml �������� �����ϱ� ���� ��ü ����
                    XmlSerializer xml = new XmlSerializer(typeof(People));

                    // ��Ʈ������ ��ü�� �籸�� �ؼ� Person ��ü�� ����
                    people = (People)xml.Deserialize(reader);
                    reader.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("������ �����ھ�� ��  _�� : " + exc.Message,
                        win.Title, MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    people = null;
                }
            }
            return people;
        }
        public bool Save(Window win)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = strFilter;

            if ((bool)dlg.ShowDialog(win))
            {
                try
                {
                    StreamWriter writer = new StreamWriter(dlg.FileName);
                    XmlSerializer xml = new XmlSerializer(GetType());

                    // �о ����
                    xml.Serialize(writer, this);
                    writer.Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("�� �̰� ���� ���ϰڽ� ' ��'  : " + exc.Message,
                                    win.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return false;
                }
            }
            return true;
        }
    }
}
