using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027
{
    class Control
    {

        Wbdatabase db = new Wbdatabase();

        public Boolean DBLogin
        {
            get { return db.DBLogin; }
        }

        #region 싱글톤
        //1. 생성자 은닉
        private Control()
        {
        }
        //2. 프로퍼티 선언
        static public Control Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static Control()
        {
            Singleton = new Control();
        }
        #endregion

        #region 도서관리

        public void DBConnect()
        {
             db.Connect();
        }

        public void DBDisConnect()
        {
             db.DisConnect();
        }

        public void InsertProduct(string name, int price, string des)
        {
            db.InsertProduct(name, price, des);
        }

        public List<Book> SelectAllBooks()
        {
            return db.SelectAllBooks();
        }

        public Book SelectPidToBook(int pid)
        {
            return db.SelectPidToBook(pid);
        }

        public void DeleteProduct(int pid)
        {
            db.DeleteProduct(pid);
        }

        public void UpdateProduct(int pid, int price)
        {
            db.UpdateProduct(pid, price);
        }
        #endregion


        #region 고객 관리

        public List<Custom> SelectAllCustom()
        {
            return db.SelectAllCustom();
        }

        public Custom SelectCidToCustom(int cid)
        {
            return db.SelectCidToCustom(cid);
        }

        public void InsertCustom(string name, string phone, string addr)
        {
            db.InsertCustom(name, phone, addr);
        }

        public void DeleteCustom(int cid)
        {
            db.DeleteCustom(cid);
        }

        public void UpdateCustom(int cid, string phone)
        {
            db.UpdateCustom(cid, phone);
        }
        public void UpdateAddr(int cid, string addr)
        {
            db.UpdateAddr(cid, addr);
        }

        #endregion

        #region 구매

        public List<Custom> SelectCustom(string name)
        {
            return db.SelectCustom(name);
        }

        public List<Book> SelectProduct(string name)
        {
            return db.SelectProduct(name);
        }

        public void BookBuy(int cid,int pid,int count)
        {
            db.BookBuy(cid, pid, count);
        }

        #endregion

        #region 검색

        public List<CustomBuy> SelectCustomBuy(string name)
        {
            return db.SelectCustomBuy(name);
        }

        public List<BookBuy> SelectBookBuy(string name)
        {
            return db.SelectBookBuy(name);
        }

        #endregion

        public void InsertProduct1(string name, int price, string des)
        {
            db.InsertProduct1(name, price, des);
        }
    }
}
