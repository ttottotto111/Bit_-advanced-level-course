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

    class Account
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public int Balance { get; private set; }

        private Account(int id, string name, int balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }

        //파싱코드
        public static Account MakeAccount(XmlReader xr)
        {
            xr.ReadToDescendant("accid");
            xr.ReadStartElement("accid");
            int accid = int.Parse(xr.Value);

            xr.ReadToNextSibling("name");
            xr.ReadToFollowing("name");
            string name = xr.ReadElementString("name");       //문자열            

            xr.ReadToDescendant("balance");
            xr.ReadStartElement("balance");
            int balance = int.Parse(xr.Value);                    //숫자 

            return new Account(accid, name, balance);

        }

        public static Account MakeDomAccount(XmlAttributeCollection col)
        {
            int accid = int.Parse(col["accid"].Value);
            string name = col["name"].Value;
            int balance = int.Parse(col["balance"].Value);

            return new Account(accid, name, balance);
        }

        public override string ToString()
        {
            return Id + ", " + Name + ", " + Balance;
        }

    }

    class Member
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public string Phone { get; private set; }

        private Member(string id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }

        //파싱코드
        public static Member MakeMember(XmlReader xr)
        {
            xr.ReadToDescendant("id");
            string id = xr.ReadElementString("id");       //문자열

            xr.ReadToDescendant("name");
            string name = xr.ReadElementString("name");       //문자열

            xr.ReadToDescendant("phone");
            string phone = xr.ReadElementString("phone");       //문자열              

            return new Member(id, name, phone);
        }

        public override string ToString()
        {
            return Id + ", " + Name + ", " + Phone;
        }

    }

    class Student
    {
        public int Id { get; private set; }
        public int Kor { get; private set; }

        public int Eng { get; private set; }
        public int Mat { get; private set; }
        public float Average { get; private set; }


        private Student(int id, int kor, int eng, int mat, float average)
        {
            Id = id;
            Kor = kor;
            Eng = eng;
            Mat = mat;
            Average = average;
        }

        //파싱코드
        public static Student MakeStudent(XmlReader xr)
        {
            xr.ReadToDescendant("id");
            xr.ReadStartElement("id");
            int id = int.Parse(xr.Value);               

            xr.ReadToNextSibling("kor");
            xr.ReadToFollowing("kor"); // xr.ReadEndElement();
            xr.ReadStartElement("kor");
            int kor = int.Parse(xr.Value);                    //숫자 

            xr.ReadToNextSibling("eng");
            xr.ReadToFollowing("eng");
            xr.ReadStartElement("eng");
            int eng = int.Parse(xr.Value);                    //숫자 

            xr.ReadToNextSibling("mat");
            xr.ReadToFollowing("mat");
            xr.ReadStartElement("mat");
            int mat = int.Parse(xr.Value);                    //숫자 

            xr.ReadToNextSibling("average");
            xr.ReadToFollowing("average");
            xr.ReadStartElement("average");
            float average = float.Parse(xr.Value);                    //숫자 

            return new Student(id, kor, eng, mat, average);

        }

        public override string ToString()
        {
            return Id + ", " + Kor + ", " + Eng + ", " + Mat + ", " + Average;
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


        #region 파싱 후 객체리스트 반환(Book)
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

        #region 파싱 후 객체리스트 반환(Account)
        public static List<Account> XmlPaser3(string path)
        {
            List<Account> ar = new List<Account>();

            XmlReader reader = XmlReader.Create(path);
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

        #endregion

        #region 파싱 후 객체리스트 반환(member)
        public static List<Member> XmlPaser4(string path)
        {
            List<Member> ar = new List<Member>();

            XmlReader reader = XmlReader.Create(path);
            while (reader.Read())
            {
                if (reader.IsStartElement("member"))
                {
                    Member ma = Member.MakeMember(reader);
                    if (ma != null)
                        ar.Add(ma);
                }
            }

            return ar;
        }
        #endregion

        #region 파싱 후 객체리스트 반환(Student)
        public static List<Student> XmlPaser5(string path)
        {
            List<Student> ar = new List<Student>();

            XmlReader reader = XmlReader.Create(path);
            while (reader.Read())
            {
                if (reader.IsStartElement("student"))
                {
                    Student stu = Student.MakeStudent(reader);
                    if (stu != null)
                        ar.Add(stu);
                }
            }

            return ar;
        }
        #endregion 
    }
}
