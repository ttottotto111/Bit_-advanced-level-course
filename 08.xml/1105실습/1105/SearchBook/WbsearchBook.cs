using _1105.SearchBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _1105
{
    class WbsearchBook
    {
        public List<Book> BookList { get; set; }
        public List<Shorturl> UrlList { get; set; }
        public string BookName { get; private set; }
        public string BookLink { get; private set; }

        public WbsearchBook()
        {
            BookList = new List<Book>();
            UrlList = new List<Shorturl>();
        }

        public void Find(string book_name, out string xmlstring)
        {
            //1.검색어 저장
            BookName = book_name;

            //2. 검색어로 openapi호출 => xml 문서 획득
            string query = book_name; // 검색할 문자열
            //string url = "https://openapi.naver.com/v1/search/book?query=" + query; // 결과가 JSON 포맷
            string url = "https://openapi.naver.com/v1/search/book.xml?query=" + query;  // 결과가 XML 포맷

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "vX7sf5j06cE075hXlRBj"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "UgdnMBOpNo");       // 클라이언트 시크릿

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);


                xmlstring = reader.ReadToEnd();
            }
            else
            {
                xmlstring = "";
               MessageBox.Show("Error 발생=" + status);
            }

            //3.xml문서를 dompaer로 파싱
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlstring));
            XmlDocument doc = new XmlDocument();
            doc.Load(ms);
            XmlNode node = doc.SelectSingleNode("rss");
            XmlNode n = node.SelectSingleNode("channel");

            Book book = null;
            foreach (XmlNode el in n.SelectNodes("item"))
            {
                book = Book.MakeBook(el);
                BookList.Add(book);
            }
        }

        public Book BookNameToBook(string bookname)
        {
            foreach(Book book in BookList)
            {
                if (book.Title.Equals(bookname) == true)
                    return book;
            }
            return null;
        }

        public void MakeURL(string booklink, out string shorturl)
        {
            BookLink = booklink;

            string url = "https://openapi.naver.com/v1/util/shorturl.xml";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);


            request.Headers.Add("X-Naver-Client-Id", "TA2ZtwuLVnGGekbeOCHN"); // 개발자센터에서 발급받은 Client ID
            request.Headers.Add("X-Naver-Client-Secret", "EWd782ifUl"); // 개발자센터에서 발급받은 Client Secret
            request.Method = "POST";


            string query = booklink; // 단축할 URL 대상


            byte[] byteDataParams = Encoding.UTF8.GetBytes("url=" + query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteDataParams.Length;
            Stream st = request.GetRequestStream();
            st.Write(byteDataParams, 0, byteDataParams.Length);
            st.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            shorturl = reader.ReadToEnd();

            //3.xml문서를 dompaer로 파싱
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(shorturl));
            XmlDocument doc = new XmlDocument();
            doc.Load(ms);

            XmlNode node = doc.SelectSingleNode("result");
            Shorturl surl = null;
            foreach (XmlNode el in node.SelectNodes("result"))
            {
                surl = Shorturl.MakeShortUrl(el);
                UrlList.Add(surl);
            }
        }
    }
}
