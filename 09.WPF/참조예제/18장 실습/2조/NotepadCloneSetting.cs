using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Petzold.NotPadClone
{

    /*************************************************************************************
 Ŭ������ : NotepadCloneSetting
 ��      �� :
 ��      �� : ������ �⺻���� ����,���� ������ ���� ����� �Ҿ����
**************************************************************************************/

    class NotepadCloneSetting
    {
        public WindowState WindowState = WindowState.Normal;  //�ּ�ȭ, ���� ���� â ���¸� �������ų� �����մϴ�.
        public Rect RestoreBounds = Rect.Empty;               //��ġ�� ���̰� ���� �簢���� ��Ÿ���� Ư�� ���� �����ɴϴ�
        public TextWrapping TextWrapping = TextWrapping.NoWrap;        // ��ü�� �ؽ�Ʈ �� �ٲ� ����� ��Ÿ���� ������ �� �� �ϳ��Դϴ�.
        public string FontFamily = "";                            //�� ����� �������� ���� �⺻ ���� �۲� �йи��� �������ų� �����մϴ�. 
        public string FontStyle = new FontStyleConverter().ConvertToString(FontStyles.Normal);
        public string FontWeight = new FontWeightConverter().ConvertToString(FontWeights.Normal);
        public string FontStretch = new FontStretchConverter().ConvertToString(FontStretches.Normal);
        public double FontSize = 11;

        //������ ���Ͽ� ����
        public virtual bool Save(string strAppData)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strAppData));  //������ path�� ��� ���͸��� ���� ���͸��� ����ϴ�. 
                StreamWriter write = new StreamWriter(strAppData);
                XmlSerializer xml = new XmlSerializer(GetType());
                xml.Serialize(write, this);   //��ü�� XML ������ serialize�ϰ� XML �������� deserialize�մϴ�. XmlSerializer�� ����ϸ� ��ü�� XML�� ���ڵ��Ǵ� ����� ������ �� �ֽ��ϴ�.
                write.Close();
            }
            catch
            {
                return false;
            }
            return true;

        }

        //������ ���Ͽ��� �Ҿ����
        public static object Load(Type type, string strAppData)
        {
            StreamReader reader;
            object settings;
            XmlSerializer xml = new XmlSerializer(type);

            try
            {
                reader = new StreamReader(strAppData);
                settings = xml.Deserialize(reader);   //������ StreamReader�� ���Ե� XML ������ deserialize�մϴ�. .NET Compact Framework���� �����˴ϴ�. 
                reader.Close();
            }
            catch
            {
                //������ �Ű� ������ �ִ� �ν��Ͻ����� ���÷��ǵ� �����ڸ� ȣ���Ͽ� �Ϲ������� ������ �ʴ� �Ű� ������ ���� �⺻���� �����մϴ�. 
                settings = type.GetConstructor(System.Type.EmptyTypes).Invoke(null); 

            }
            return settings;
        }
    }
}
