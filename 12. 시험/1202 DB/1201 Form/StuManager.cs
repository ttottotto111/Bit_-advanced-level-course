using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1201_Form
{
    class StuManager : IStuManager
    {
        #region 싱글톤
        //private static StuManager singleton;
        //public static StuManager Singleton { get { return singleton; } }

        //static StuManager()
        //{
        //    singleton = new StuManager();
        //}

        //private StuManager() { }

        #endregion

        public Boolean DBLogin { get; set; }
        public string ConMsg { get; private set; }

        private SqlConnection scon = new SqlConnection();

        public StuManager()
        {
            DBLogin = false;
            ConMsg = @"Data Source=DESKTOP-R8F9OUG\SQLEXPRESS;Initial Catalog=WbDB;User ID=ksw;Password=123";
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

        public List<Student> PrintAll()
        {
            Connect();
            List<Student> stulist = new List<Student>();

            string comtext = "Select * From Student";
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student stu = new Student(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        (SubjectType)int.Parse(reader[2].ToString()),
                                        int.Parse(reader[3].ToString()));
                stulist.Add(stu);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========

            DisConnect();
            return stulist;
        }

        //학생추가
        public bool StuInsert(Student stu)
        {
            try
            {
                Connect();
                string comtxt = string.Format("insert into Student (Number, Name, SType, Grade) values ({0}, '{1}', {2}, {3})",
                    stu.Number, stu.Name, (int)stu.SType, stu.Grade);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                DisConnect();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                DisConnect();
                return false;
            }
        }

        //검색함수
        public Student NumberToStudent(int number)
        {
            Connect();
            List<Student> stulist = new List<Student>();

            string comtext = string.Format("Select * From Student where Number = {0}", number);
            SqlCommand command = new SqlCommand(comtext, scon);

            //select
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Student stu = new Student(
                                        int.Parse(reader[0].ToString()),
                                        reader[1].ToString(),
                                        (SubjectType)reader[2],
                                        int.Parse(reader[3].ToString()));
                stulist.Add(stu);
            }
            reader.Close();         //<=========
            command.Dispose();      //<=========
            DisConnect();

            return stulist[0];
        }

        //삭제함수
        public bool StuDelete(int number)
        {
            try
            {
                Connect();
                string comtxt = string.Format("delete from Student where Number = {0}", number);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                DisConnect();
                return true;
            }
            catch (Exception)
            {
                DisConnect();
                return false;

            }
        }

        //수정함수
        public bool StuUpdate(int number, SubjectType type, int grade)
        {
            try
            {
                Connect();
                string comtxt = string.Format("update Student set SType={0}, Grade={1} where Number ={2}", (int)type, grade, number);

                SqlCommand scom = new SqlCommand(comtxt, scon);
                scom.ExecuteNonQuery();
                scom.Dispose();

                DisConnect();
                return true;
            }
            catch (Exception)
            {
                DisConnect();
                return false;
            }
        }
    }
}
