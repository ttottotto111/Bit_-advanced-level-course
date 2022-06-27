using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _1103xml과db연결
{
    class WbXMLRead
    {
        public static string PrintMessage { get; private set; }


        //URL 경로로 가져오기
        public static void XmlRead(string urlpath,TextBox text)
        {
            //url정보 가져오기 위한 객체 
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            XmlReader reader = XmlReader.Create(urlpath, settings);
            WriteControl(reader, text);
            reader.Close();

        }

        private static void WriteControl(XmlReader reader, TextBox text)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriter xwriter = XmlWriter.Create(sb);
            xwriter.WriteNode(reader, false);           //복사
            xwriter.Close();

            text.Text = sb.ToString();
        }
    }
}
