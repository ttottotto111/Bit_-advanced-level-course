using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1027
{
    class Wbdatabase
    {
        public Boolean DBLogin { get; set; }
        public string ConMsg { get; private set; }

        private SqlConnection scon = new SqlConnection();

        //생성자
        public Wbdatabase()
        {
            DBLogin = false;
            ConMsg = @"Data Source=DESKTOP-R8F9OUG\SQLEXPRESS;Initial Catalog=WbDB; User ID=ksw;Password=123";
            scon = new SqlConnection(ConMsg);
        }

        //연결
        public Boolean Connect()
        {
            try
            {
                scon.Open();
                DBLogin = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //연결해제
        public Boolean DisConnect()
        {
            try
            {
                scon.Close();
                DBLogin = false;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }

        #region 도서관리

        //제품 추가
        public Boolean InsertProduct(string name, int price, string des)
        {
            try
            {
                string comtxt = string.Format("insert into Product (PNAME, Price, Description) values ('{0}', {1}, '{2}')",
                    name, price, des);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //삭제
        public Boolean DeleteProduct(int pid)
        {
            try
            {
                string comtxt = string.Format("delete from Product where PID = {0}", pid);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //수정
        public Boolean UpdateProduct(int pid, int price)
        {
            try
            {
                string comtxt = string.Format("update Product set Price={0} where PID ={1}", price, pid);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //제품 전체 리스트
        public List<Book> SelectAllBooks()
        {
            List<Book> list = new List<Book>();

            string comtext = "Select * From Product";
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        int.Parse(reader[2].ToString()),
                                        reader[3].ToString());
                list.Add(book);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list;
        }

        public Book SelectPidToBook(int pid)
        {
            List<Book> list = new List<Book>();

            string comtext = string.Format("Select * From Product where PID = {0}", pid);
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        int.Parse(reader[2].ToString()),
                                        reader[3].ToString());
                list.Add(book);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list[0];
        }



        #endregion

        #region 고객 관리

        public List<Custom> SelectAllCustom()
        {
            List<Custom> list = new List<Custom>();

            string comtext = "Select * From Custom";
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Custom custom = new Custom(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        reader[2].ToString(),
                                        reader[3].ToString());
                list.Add(custom);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list;
        }

        public Custom SelectCidToCustom(int cid)
        {
            List<Custom> list = new List<Custom>();

            string comtext = string.Format("Select * From Custom where CID = {0}", cid);
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Custom custom = new Custom(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        reader[2].ToString(),
                                        reader[3].ToString());
                list.Add(custom);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list[0];
        }

        public Boolean InsertCustom(string name, string phone, string addr)
        {
            try
            {
                string comtxt = string.Format("insert into Custom (CNAME, PHONE, ADDR) values ('{0}', '{1}', '{2}')",
                    name, phone, addr);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Boolean DeleteCustom(int cid)
        {
            try
            {
                string comtxt = string.Format("delete from Custom where CID = {0}", cid);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Boolean UpdateCustom(int cid, string phone)
        {
            try
            {
                string comtxt = string.Format("update Custom set PHONE='{0}' where CID ={1}", phone, cid);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public Boolean UpdateAddr(int cid, string addr)
        {
            try
            {
                string comtxt = string.Format("update Custom set ADDR='{0}' where CID ={1}", addr, cid);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        #endregion


        #region 구매

        public List<Custom> SelectCustom(string name)
        {
            List<Custom> list = new List<Custom>();

            string comtext = string.Format("Select * From Custom where CNAME='{0}'", name);
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Custom custom = new Custom(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        reader[2].ToString(),
                                        reader[3].ToString());
                list.Add(custom);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list;
        }

        public List<Book> SelectProduct(string name)
        {
            List<Book> list = new List<Book>();

            string comtext = string.Format("Select * From Product where PNAME='{0}'", name);
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Book book = new Book(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        int.Parse(reader[2].ToString()),
                                        reader[3].ToString());
                list.Add(book);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list;
        }

        public Boolean BookBuy(int cid, int pid, int count)
        {
            try
            {
                string comtxt = string.Format("insert into SaleDate (CID, PID, COUNT, SaleDate) values ({0}, {1}, {2},CONVERT(CHAR(19), GETDATE(), 20))",
                    cid, pid, count);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion

        #region 검색

        //고객이름 -> 구매내역 검색
        public List<CustomBuy> SelectCustomBuy(string name)
        {
            List<CustomBuy> list = new List<CustomBuy>();

            string comtext = string.Format("Select p.PID, PNAME, Price, COUNT, SaleDate " +
                " from Product p INNER JOIN SaleDate s ON p.PID= s.PID" +
                " where p.PID =any(select PID from SaleDate where CID =" +
                " any(select CID from Custom where CNAME ='{0}')) and CID = " +
                " any(select CID from Custom where CNAME ='{0}')"
                , name);
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CustomBuy book = new CustomBuy(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        int.Parse(reader[2].ToString()),
                                        int.Parse(reader[3].ToString()),
                                        reader[4].ToString());
                list.Add(book);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list;
        }

        //도서명검색
        public List<BookBuy> SelectBookBuy(string name)
        {
            List<BookBuy> list = new List<BookBuy>();

            string comtext = string.Format("select CID, CNAME, PHONE, ADDR" +
                " from Custom" +
                " where CID =" +
                " any(select CID from SaleDate where PID =" +
                " (select PID from Product where PNAME = '{0}'))"
                , name);
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                BookBuy book = new BookBuy(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        reader[2].ToString(),
                                        reader[3].ToString());
                list.Add(book);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            return list;
        }

        #endregion

        //제품 추가
        public Boolean InsertProduct1(string name, int price, string des)
        {
            try
            {
                string comtxt = "AddBook";  //프로시저 이름

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.CommandType = System.Data.CommandType.StoredProcedure;
                //============================================================

                //파라미터 정보 : 파라미터 키워드, 값, 타입(기본타입 : 문자열) <-- 필요
                SqlParameter param_name = new SqlParameter("@Name", name);
                scom.Parameters.Add(param_name);

                SqlParameter param_price = new SqlParameter();
                param_price.ParameterName = "@Price";
                param_price.SqlDbType = System.Data.SqlDbType.Int;
                param_price.Value = price;
                scom.Parameters.Add(param_price);

                SqlParameter param_description = new SqlParameter("@Description", des);
                scom.Parameters.Add(param_description);

                //============================================================
                scom.ExecuteNonQuery();
                scom.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
