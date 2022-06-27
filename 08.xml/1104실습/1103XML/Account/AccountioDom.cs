using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wb.XMLPaser
{
    class AccountioDom
    {
        public static XmlDocument Doc { get; set; }

        //파일에 있는 XML문서를 획득해서 메모리에 로딩
        public static void GetXMLFileLoad(string path)
        {
            Doc = new XmlDocument();
            Doc.Load(path);
        }

        public static string GetXmlData()
        {
            return Doc.DocumentElement.OuterXml;
        }

        //객체 반환
        public static List<AccountIO> DocumentPrint()
        {
            List<AccountIO> xmllist = new List<AccountIO>();

            //accounts의 노드로 이동
            XmlNode root = Doc.SelectSingleNode("accountios");

            //accounts가 자식노드를 갖고 있느냐?
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++) 
                {
                    AccountIO acc = AccountIO.MakeDomAccountIO(root.ChildNodes[i].Attributes);
                    xmllist.Add(acc);
                }
            }
            return xmllist;
        }
    }
}
