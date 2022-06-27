using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1103xml과db연결
{
    class WbDataBase
    {
        private DataSet ds = new DataSet("WbDB");
        private string constr = @"Data Source=DESKTOP-R8F9OUG\SQLEXPRESS;Initial Catalog=WbDB; User ID=ksw;Password=123";


        #region 싱글톤
        //1. 생성자 은닉
        private WbDataBase()
        {

        }
        //2. 프로퍼티 선언
        static public WbDataBase Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static WbDataBase()
        {
            Singleton = new WbDataBase();
        }
        #endregion

        #region 연결
        public DataSet Connect()
        {

            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from News;";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                //물 DB -> 논 DB
                adapter.FillSchema(ds, SchemaType.Source, "News");
                adapter.Fill(ds, "News");
                return ds;
            }
        }
        #endregion

        #region 동기화
        public void Update()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = MakeItemInsertCommand(con);
                    adapter.Update(ds, "News");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region DB생성
        public void InsertItem(Item item)
        {
            try
            {
                DataRow dr = ds.Tables["News"].NewRow();
                dr["alternativeTitle"] = item.CollectionDb;
                dr["collectionDb"] = item.CollectionDb;
                dr["creator"] = item.Creator;
                dr["description"] = item.Description;
                dr["language"] = item.Language;
                dr["regDate"] = item.RegDate;
                dr["subDescription"] = item.SubDescription;
                dr["subjectCategory"] = item.SubjectCategory;
                dr["title"] = item.Title;

                ds.Tables["News"].Rows.Add(dr);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private SqlCommand MakeItemInsertCommand(SqlConnection con)
        {

            string cmd_text = "insert into News Values(@alternativeTitle,@collectionDb, @creator, @description,@language,@regDate,@subDescription,@subjectCategory,@title)";
            SqlCommand cmd = new SqlCommand(cmd_text, con);
            cmd.Parameters.Add("@alternativeTitle", SqlDbType.VarChar, 1024, "alternativeTitle");
            cmd.Parameters.Add("@collectionDb", SqlDbType.VarChar, 1024, "collectionDb");
            cmd.Parameters.Add("@creator", SqlDbType.VarChar, 1024, "creator");
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 1024, "description");
            cmd.Parameters.Add("@language", SqlDbType.VarChar, 1024, "language");
            cmd.Parameters.Add("@regDate", SqlDbType.VarChar, 1024, "regDate");
            cmd.Parameters.Add("@subDescription", SqlDbType.VarChar, 1024, "subDescription");
            cmd.Parameters.Add("@subjectCategory", SqlDbType.VarChar, 1024, "subjectCategory");
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 1024, "title");
            return cmd;
        }
        #endregion
    }
}
