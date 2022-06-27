using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _1105.SearchBook
{
    class Shorturl
    {
        public string ShortUrl { get; private set; }

        public Shorturl(string shorturl)
        {
            ShortUrl = shorturl;
        }

        static internal Shorturl MakeShortUrl(XmlNode xn)
        {
            XmlNode url_node = xn.SelectSingleNode("url");
            string url = ConvertString(url_node.InnerText);

            return new Shorturl(url);
        }

        private static string ConvertString(string str)
        {
            int sindex;
            int eindex;
            while (true)
            {
                sindex = str.IndexOf('<');
                if (sindex == -1)
                {
                    break;
                }
                eindex = str.IndexOf('>');
                str = str.Remove(sindex, eindex - sindex + 1);
            }
            return str;
        }
    }
}
