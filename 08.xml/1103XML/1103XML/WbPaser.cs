using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _1103XML
{
    //파싱 저장 객체 정의
    class Book
    {
        public string Title     { get; private set; }
        public int Price        { get; private set; }
        
        private Book(string title, int price)
        {
            Title = title;
            Price = price;
        }

        //파싱코드
        public static Book MakeBook(XmlReader xr)
        {        
            xr.ReadToDescendant("title");
            string title = xr.ReadElementString("title");       //문자열

            xr.ReadToNextSibling("가격");
            xr.ReadStartElement("가격");
            int price = int.Parse(xr.Value);                    //숫자 

            return new Book(title, price);
        }
       
        public override string ToString()
        {
            return Title + ", " + Price;
        }

    }

    class WbPaser
    {
        public static string PrintMessage { get; private set; }

        //원본 XML read
        public static void XmlRead(string path)
        {
            XmlReader reader3 = XmlReader.Create(path);
            //
            StringBuilder sb = new StringBuilder();
            XmlWriter xwriter = XmlWriter.Create(sb);
            xwriter.WriteNode(reader3, false);           //복사
            xwriter.Close();
            PrintMessage = sb.ToString();
            //
            reader3.Close();
        }

        #region 현재 위치의 노드 형식 알아내기 예제 코드(page32)
        public static void Paser1(string path)
        {
            PrintMessage = string.Empty;

            XmlReader reader = XmlReader.Create(path);
            reader.MoveToContent();
            while (reader.Read())
            {
                WriteNodeInfo(reader);
            }

        }

        private static void WriteNodeInfo(XmlReader reader)
        {
            PrintMessage += "노드 형 " + reader.NodeType + "\r\n";
            PrintMessage += "▷ 노드 이름 " + reader.Name + "\r\n";
            PrintMessage += "▷노드 데이터 " + reader.Value + "\r\n";
            PrintMessage += "\r\n";
        }
        #endregion


        #region 파싱 후 객체리스트 반환
        public static List<Book> XmlPaser2(string path)
        {
            List<Book> ar = new List<Book>();

            XmlReader reader = XmlReader.Create(path);
            while (reader.Read())
            {
                if (reader.IsStartElement("book"))
                {
                    Book book = Book.MakeBook(reader);
                    if (book != null) 
                        ar.Add(book);                     
                }
            }

            return ar;            
        }

        #endregion 
    }



}
