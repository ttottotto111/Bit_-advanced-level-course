using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wb.XMLPaser
{
    class AccountXML
    {
        #region 싱글톤
        //1. 생성자 은닉
        private AccountXML()
        {
        }
        //2. 프로퍼티 선언
        static public AccountXML Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static AccountXML()
        {
            Singleton = new AccountXML();
        }
        #endregion

        //전달된 xml파일을 읽어 문자열 반환
        public string XmlRead(string filename)
        {
            string readxml = string.Empty;
            using (XmlReader reader = XmlReader.Create(filename))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        readxml =  reader.ReadOuterXml();
                    }
                }
            }
            return readxml;
        }
    
        //전달된 XML파일을 읽어 파싱 후 결과값을 컬렉션으로 반환
        public List<Account> XmlPaser(string filename)
        {
            List<Account> ar = new List<Account>();

            XmlReader reader = XmlReader.Create(filename);
            while (reader.Read())
            {
                if (reader.IsStartElement("account"))
                {
                    Account acc = Account.MakeAccount(reader);
                    if (acc != null)
                        ar.Add(acc);
                }
            }
            return ar;
        }
    }
}
