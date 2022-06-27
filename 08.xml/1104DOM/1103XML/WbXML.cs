using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _1103XML
{

    /// <summary>
    /// XML 문서 작성 
    /// </summary>
    class WbXMLWrite
    {
        #region XMLWrite

        //요소쓰기1
        public static string XMLWriteSample()
        {
            XmlWriterSettings xsettings = new XmlWriterSettings();
            xsettings.Indent = true;
            XmlWriter xwriter = XmlWriter.Create("data.xml", xsettings);
            //=============================================================

            xwriter.WriteComment("XmlWriter 개체 만들기 실습 예제"); //주석 <!--  -->
            xwriter.WriteStartElement("books");  // <books>
            
            xwriter.WriteStartElement("book");   //     <book>ADO.NET</book>
            xwriter.WriteValue("ADO.NET"); 
            xwriter.WriteEndElement();

            xwriter.WriteStartElement("book");  // <book>XML.NET></book>
            xwriter.WriteValue("XML.NET");
            xwriter.WriteEndElement();

            xwriter.WriteEndElement();           //</books>
            xwriter.Close();

            return XmlGetString("data.xml");
        }
    
        //요소쓰기2
        public static string XMLWriteSamle1()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create("data.xml", settings);

            writer.WriteComment("XmlWriter 개체로 요소 쓰기");
            writer.WriteStartElement("books");      //루트 요소 쓰기  <books>
            writer.WriteStartElement("book");       //book 요소 쓰기     <book>

            writer.WriteStartElement("title");      //title 요소 쓰기       <title>XML.NET</title>
            writer.WriteName("XML.NET");
            writer.WriteEndElement();//title 요소 닫기

            writer.WriteStartElement("가격");//가격 요소 쓰기               < 가격>12000</가격>
            writer.WriteValue(12000);
            writer.WriteEndElement();//가격 요소 닫기
            
            writer.WriteEndElement();//book 요소 닫기                   </book>

            writer.WriteStartElement("book");//book 요소 쓰기           <book>            
            //title 요소와 값 쓰기
            writer.WriteElementString("title", "ADO.NET");          //     <title>ADO.NET</title>

            writer.WriteStartElement("가격");//가격 요소 쓰기               <가격>15000</가격>
            writer.WriteValue(15000);
            writer.WriteEndElement();//가격 요소 닫기
           
            writer.WriteEndElement();//book 요소 닫기                   </book>

            writer.WriteEndElement();//루트 요소 닫기             </books>
            writer.Close();

            return XmlGetString("data.xml");
        }

        //특성쓰기1
        public static string XMLWriteSample2()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create("data.xml", settings);
            //=============================================================

            writer.WriteComment("XmlWriter 개체로 특성 쓰기");
            writer.WriteStartElement("books"); //루트 요소 쓰기   <books>
            //=======================================================================================
            writer.WriteStartElement("book");//book 요소 쓰기       <book title="XML.NET" 가격=12000/>
            
            writer.WriteStartAttribute("title"); //title 특성 쓰기
            writer.WriteString("XML.NET"); //title 특성 값 쓰기
            writer.WriteEndAttribute(); //title 특성 닫기
            
            writer.WriteStartAttribute("가격");//가격 특성 쓰기
            writer.WriteValue(12000); //가격 특성 값 쓰기
            writer.WriteEndAttribute(); //가격 특성 닫기

            writer.WriteEndElement(); //book 요소 닫기
            //====================================================================================
            writer.WriteStartElement("book");//book 요소 쓰기      <book title="ADO.NET" 가격=15000/>
            
            writer.WriteAttributeString("title", "ADO.NET");//title 특성과 값 쓰기
            
            writer.WriteStartAttribute("가격");//가격 특성 쓰기
            writer.WriteValue(15000);//가격 특성 값 쓰기            
            writer.WriteEndAttribute();//가격 특성 닫기

            writer.WriteEndElement();//book 요소 닫기
            //====================================================================================
            writer.WriteEndElement();//루트 요소 닫기         </books>

            writer.Close();            


            return XmlGetString1("data.xml");
        }
        #endregion 


        // XML 파일명 전달 -> string 복사 -> string 반환
        public static string XmlGetString(string filename)
        {
            XmlReader xreader1 = XmlReader.Create(filename); //XmlReader 개체 생성
            StringBuilder sb = new StringBuilder();    // string객체와 유사...
            XmlWriter xwriter1 = XmlWriter.Create(sb);
            xwriter1.WriteNode(xreader1, false);
            xwriter1.Close();
            xreader1.Close();

            return sb.ToString();
        }

        /*
        <?xml version="1.0" encoding="utf-16"?>
            <books>
                <book title="XML.NET" 가격="12000" />
                <book title="ADO.NET" 가격="15000" />
            </books>
        */
        // XML 파일명 전달 ->XML파싱 -> string 생성 -> string 반환
        public static string XmlGetString1(string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            StringBuilder sb = new StringBuilder();    // string객체와 유사...
            XmlReader xreader = XmlReader.Create(filename); //XmlReader 개체 생성
            XmlWriter xwriter = XmlWriter.Create(sb, settings); //XmlWriter 개체 생성

            //xreader를이용한 파서 처리
            while (xreader.Read())   // XML문서를 한줄씩 읽어 온다. 
            {
                if (xreader.NodeType == XmlNodeType.Element)  // 요소?  <????>
                {
                    xwriter.WriteStartElement(xreader.Name);    //요소의 이름을 출력
                    xwriter.WriteAttributes(xreader, false); //xreader의 현재 특성을 쓰기
                    if (xreader.IsEmptyElement)
                    {
                        xwriter.WriteEndElement();
                    }
                }
                else if (xreader.NodeType == XmlNodeType.EndElement) //닫는요소?  </????>
                {
                    xwriter.WriteEndElement();
                }
            }
            xwriter.Close();
            xreader.Close();

            return sb.ToString();
        }

        //XML 파일명 전달 -> 콘솔창에 출력
        public static void ConsolePrint(string filename)
        {
            XmlReader xreader = XmlReader.Create(filename); //XmlReader 개체 생성

            //콘솔 출력 스트림으로 XmlWriter 개체 생성
            XmlWriter xwriter = XmlWriter.Create(Console.Out);

            //xreader 개체로 읽어온 데이터를 xwriter 개체에 복사
            //xreader 객체로 읽어온 data.xml 문서의 내용을
            //xwriter(Console.Out)에 복사 -> 따라서 콘솔창에 출력
            xwriter.WriteNode(xreader, false);
            xwriter.Close();
            xreader.Close();
        }

        public static void ConsolePrint1(string filename)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlReader xreader = XmlReader.Create(filename); //XmlReader 개체 생성
            XmlWriter xwriter = XmlWriter.Create(Console.Out, settings); //XmlWriter 개체 생성

            //xreader를이용한 파서 처리
            while (xreader.Read())   // XML문서를 한줄씩 읽어 온다. 
            {
                if (xreader.NodeType == XmlNodeType.Element)  // 요소?  <????>
                {
                    xwriter.WriteStartElement(xreader.Name);    //요소의 이름을 출력
                    xwriter.WriteAttributes(xreader, false); //xreader의 현재 특성을 쓰기
                    if (xreader.IsEmptyElement)
                    {
                        xwriter.WriteEndElement();
                    }
                }
                else if (xreader.NodeType == XmlNodeType.EndElement) //닫는요소?  </????>
                {
                    xwriter.WriteEndElement();
                }
            }
            xwriter.Close();
            xreader.Close();
            Console.WriteLine();
        }
    }

}
