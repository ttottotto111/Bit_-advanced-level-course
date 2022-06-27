using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wb.XMLPaser
{
    class AccountDom
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
        public static List<Account> DocumentPrint()
        {
            List<Account> xmllist = new List<Account>();

            //accounts의 노드로 이동
            XmlNode root = Doc.SelectSingleNode("accounts");

            //accounts가 자식노드를 갖고 있느냐?
            if (root.HasChildNodes)
            {
                for (int i = 0; i < root.ChildNodes.Count; i++) //2개
                {
                    Account acc = Account.MakeDomAccount(root.ChildNodes[i].Attributes);
                    xmllist.Add(acc);
                }
            }
            return xmllist;
        }
    }
}
