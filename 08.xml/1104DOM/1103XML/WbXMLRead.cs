using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _1103XML
{
    class WbXMLRead
    {
        #region 리더객체 생성
        //전체 파싱(XML과 연결된 파일객체를 생성, 파일객체와 reader객체 연결)
        public static void XmlRead1(string filename, TextBox text)
        {
            //Create(Stream input);            
            FileStream fs = new FileStream(filename,
                    FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);

            XmlReader reader1 = XmlReader.Create(fs);
            WriteControl(reader1, text);
            reader1.Close();
            fs.Close();
        }

        //셋팅객체를 사용해서 주석은 제거 
        public static void XmlRead2(string filename, TextBox text)
        {
            //Create(Stream input, XmlReaderSettings settings);
            FileStream fs = new FileStream(filename,
                    FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read);

            //셋팅객체를 사용해서 주석은 제거 
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            XmlReader reader2 = XmlReader.Create(fs, settings);
            WriteControl(reader2, text);
            reader2.Close();
            fs.Close();
        }

        //전체파싱(XML파일명을 이용해 reader객체 생성)
        public static void XmlRead3(string filename, TextBox text)
        {
            ////Create(string uri);   
            XmlReader reader3 = XmlReader.Create(filename);
            WriteControl(reader3, text);
            reader3.Close();
        }

        //전체파싱(XML파일명을 이용해 reader객체 생성)
        //셋팅객체를 사용해서 주석은 제거 
        public static void XmlRead4(string filename, TextBox text)
        {
            ////Create(string uri, XmlReaderSettings settings);
            /////셋팅객체를 사용해서 주석은 제거 
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;

            XmlReader reader4 = XmlReader.Create(filename, settings);
            WriteControl(reader4, text);
            reader4.Close();
        }

        //URL 경로로 가져오기
        public static void XmlRead5(string urlpath, TextBox text)
        {
            //url정보 가져오기 위한 객체 
            XmlUrlResolver resolver = new XmlUrlResolver();
            resolver.Credentials = System.Net.CredentialCache.DefaultCredentials;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.XmlResolver = resolver;

            XmlReader reader = XmlReader.Create(urlpath, settings);
            WriteControl(reader, text);
            reader.Close();
        }
        #endregion 

        private static void WirteConsole(XmlReader reader)
        {            
            XmlWriter xwriter = XmlWriter.Create(Console.Out);
            xwriter.WriteNode(reader, false);
            xwriter.Close();
            Console.WriteLine();
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
