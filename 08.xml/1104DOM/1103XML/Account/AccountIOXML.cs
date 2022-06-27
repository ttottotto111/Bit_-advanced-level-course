using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Wb.XMLPaser
{
    class AccountIOXML
    {
        #region 싱글톤
        //1. 생성자 은닉
        private AccountIOXML()
        {
        }
        //2. 프로퍼티 선언
        static public AccountIOXML Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static AccountIOXML()
        {
            Singleton = new AccountIOXML();
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
                        readxml = reader.ReadOuterXml();
                    }
                }
            }
            return readxml;
        }

        //전달된 XML파일을 읽어 파싱 후 결과값을 컬렉션으로 반환
        public List<AccountIO> XmlPaser(string filename)
        {
            List<AccountIO> ar = new List<AccountIO>();

            XmlReader reader = XmlReader.Create(filename);
            while (reader.Read())
            {
                if (reader.IsStartElement("accountio"))
                {
                    AccountIO acc = AccountIO.MakeAccountIO(reader);
                    if (acc != null)
                        ar.Add(acc);
                }
            }
            return ar;
        }
    }
}
