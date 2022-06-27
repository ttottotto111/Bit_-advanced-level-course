using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _1103XML
{
   
    public partial class Form5 : Form
    {
        Tracer tracer = new Tracer();

        public Form5()
        {
            InitializeComponent();
        }

        //출력1
        private void button1_Click(object sender, EventArgs e)
        {
            tracer.MakeDocument();
            textBox1.Text = tracer.Doc.DocumentElement.OuterXml;
        }

        //출력2
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> strlist = tracer.DocumentPrint();

            string str = string.Empty;
            foreach(string temp in strlist)
            {
                str += temp + "\r\n";
            }

            textBox2.Text = str;
        }

        //XML 로드
        private void button3_Click(object sender, EventArgs e)
        {
            Form5XMLExample.GetXMLFileLoad("accounts.xml");
            textBox3.Text =  Form5XMLExample.GetXmlData();
        }

        //객체 획득
        private void button4_Click(object sender, EventArgs e)
        {
            List<Account> acclist = Form5XMLExample.DocumentPrint();
            foreach (Account acc in acclist)
            {
                listBox1.Items.Add(acc.ToString());
            }
        }
    }

    class Tracer
    {
        private XmlDocument doc;        //DOM
        public XmlDocument Doc { get { return doc;  } }

        /*<정의문>
         * <주석>
         * <books>
                <book price="12000" count="50">XML.NET</book>
                <book>ADO.NET</book>
            </books>
        */

        //XMLDocument객체생성(객체를 이용해서 XML 문서를 생성)
        public void MakeDocument()
        {
            doc = new XmlDocument();
            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", null, null);
            doc.InsertBefore(xmldecl, doc.DocumentElement);
            XmlElement root = doc.CreateElement("books");
            doc.AppendChild(root);
            XmlElement elem = doc.CreateElement("book");
            elem.InnerText = "XML.NET";
            doc.DocumentElement.AppendChild(elem);
            elem.SetAttribute("price", "12000");
            XmlAttribute attr = doc.CreateAttribute("count");
            attr.Value = "50";
            elem.Attributes.Append(attr);
            XmlElement elem2 = doc.CreateElement("book");
            elem2.InnerText = "ADO.NET";
            doc.DocumentElement.AppendChild(elem2);
        }
        
        //Document객체 데이터 추출(순차적)
        public List<string> DocumentPrint()
        {
            MakeDocument();

            List<string> xmllist = new List<string>();
            //books의 노드로 이동
            XmlNode root = doc.SelectSingleNode("books");

            //books가 자식노드를 갖고 있느냐?
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++) //2개
                {
                    xmllist.Add(root.ChildNodes[i].InnerText);
                    //만약에 해당 요소가 특성을 가지고 있다면 특성정보 추출
                    XmlAttributeCollection col = root.ChildNodes[i].Attributes;
                    foreach (XmlAttribute at in col)//2번(price, count)
                    {
                        xmllist.Add(at.Value);
                    }
                }
            }
            return xmllist;
        }

        #region 해당 노드에 접근하는 부분, 수정 및 삭제 
        private void TestElement_RemoveAttributeAt()
        {
            Console.WriteLine("---Start TestElement_RemoveAttributeAt---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            XmlNode cnode = pnode.ChildNodes[0];
            XmlElement xelem = cnode as XmlElement;
            if (xelem != null) { xelem.RemoveAttributeAt(0); }
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestElement_RemoveAttributeAt---");
        }
        private void TestElement_RemoveAttribute()
        {
            Console.WriteLine("---Start TestElement_RemoveAttribute---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            XmlNode cnode = pnode.ChildNodes[0];
            XmlElement xelem = cnode as XmlElement;
            if (xelem != null) { xelem.RemoveAttribute("price"); }
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestElement_RemoveAttribute---");
        }
        private void TestElement_RemoveAllAttributes()
        {
            Console.WriteLine("---Start TestElement_RemoveAllAttributes---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            XmlNode cnode = pnode.ChildNodes[0];
            XmlElement xelem = cnode as XmlElement;
            if (xelem != null) { xelem.RemoveAllAttributes(); }
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestElement_RemoveAllAttributes---");
        }
        private void TestAttributes_RemoveAt()
        {
            Console.WriteLine("---Start TestAttributes_RemoveAt---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            XmlNode cnode = pnode.ChildNodes[0];
            XmlAttributeCollection col = cnode.Attributes;
            col.RemoveAt(0);
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestAttributes_RemoveAt---");
        }
        private void TestAttributes_RemoveAll()
        {
            Console.WriteLine("---Start TestAttributes_RemoveAll---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            XmlNode cnode = pnode.ChildNodes[0];
            XmlAttributeCollection col = cnode.Attributes;
            col.RemoveAll();
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestAttributes_RemoveAll---");
        }
        private void TestAttributes_Remove()
        {
            Console.WriteLine("---Start TestAttributes_Remove---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            XmlNode cnode = pnode.ChildNodes[0];
            XmlAttributeCollection col = cnode.Attributes;
            XmlAttribute attr = col["price"];
            col.Remove(attr);
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestAttributes_Remove---");
        }
        private void TestXmlNode_RemoveAll()
        {
            Console.WriteLine("---Start TestXmlNode_RemoveAll---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            pnode.RemoveAll();
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestXmlNode_RemoveAll---");
        }
        private void TestXmlNode_RemoveChild()
        {
            Console.WriteLine("---Start TestXmlNode_RemoveChild---");
            MakeDocument();
            XmlNode pnode = doc.SelectSingleNode("books");
            XmlNode cnode = pnode.ChildNodes[0];
            pnode.RemoveChild(cnode);
            doc.Save(Console.Out);
            Console.WriteLine();
            Console.WriteLine("---End TestXmlNode_RemoveChild---");
        }
        #endregion 
    }


}
