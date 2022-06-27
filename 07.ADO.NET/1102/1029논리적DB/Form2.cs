using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * 비연결지향 방식(Adapter)으로 DB를 사용 
 * - Fill   : SelectCommand 가 등록 되어야지만 처리가 가능
 * - Update : Insert, Delete, UpdateCommand  가 등록되어야만 처리 가능하다.
 * [구현]
 * 맴버필드 : Connect, Adapter를 생성
 * - 초기화 과정에서 Adapter객체에 미리 Command명령 4개를 등록하고사용한다.
 * - 자유롭게 어디서나 Update, Fill명령이 가능....
 */

namespace _1029논리적DB
{
    //비연결지향 방식(Adapter)으로 DB를 사용 
    public partial class Form2 : Form
    {
        private DataSet ds = new DataSet("WbDB");
        private string constr = @"Data Source=DESKTOP-R8F9OUG\SQLEXPRESS;Initial Catalog=WbDB;User ID=ksw;Password=123";

        public Form2()
        {
            InitializeComponent();
        }

        #region  Product

        //Product 테이블 생성
        //물리적DB -> 논리적DB 가져오기 
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from Product;";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                //물DB -> 논DB
                adapter.Fill(ds, "Product");

                //출력
                DatatableSchemaPrint(listBox1, ds.Tables["Product"]);

                //DataGridView 를 DataBase테이블과 바인딩처리
                dataGridView1.DataSource = ds.Tables["Product"];
            }
        }

        //저장(insert) : 논리적 DB 저장 
        private void button2_Click(object sender, EventArgs e)
        {
            string name     = textBox1.Text;
            int price       = int.Parse(textBox2.Text);
            string info     = textBox7.Text;

            InsertBook(name, price, info);
        }

        private void InsertBook(string name, int price, string info)
        {
            try
            {
                DataRow dr = ds.Tables["Product"].NewRow();
                dr["PNAME"] = name;
                dr["Price"] = price;
                dr["Description"] = info;

                ds.Tables["Product"].Rows.Add(dr);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //삭제
        private void button3_Click(object sender, EventArgs e)
        {
            int pid = int.Parse(textBox3.Text);

            try
            {
                DataRow dr = ds.Tables["Product"].Rows.Find(pid);
                ds.Tables["Product"].Rows.Remove(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Update
        //논리적DB -> 물리적DB
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.InsertCommand = MakeProductInsertCommand(con);
                    adapter.DeleteCommand = MakeProductDeleteCommand(con);
                    adapter.UpdateCommand = MakeProductUpdateCommand(con);
                    adapter.Update(ds, "Product");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private SqlCommand MakeProductInsertCommand(SqlConnection con)
        {

            string cmd_text = "insert into Product Values(@PNAME, @Price, @Description)";
            SqlCommand cmd = new SqlCommand(cmd_text, con);
            cmd.Parameters.Add("@PNAME", SqlDbType.VarChar, 50, "PNAME");
            cmd.Parameters.Add("@Price", SqlDbType.Int, 4, "Price");
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100, "Description");
            return cmd;            
        }

        private SqlCommand MakeProductDeleteCommand(SqlConnection con)
        {

            string cmd_text = "delete Product where PID=@PID";
            SqlCommand cmd = new SqlCommand(cmd_text, con);
            cmd.Parameters.Add("@PID", SqlDbType.Int, 4, "PID");
            return cmd;
        }

        private SqlCommand MakeProductUpdateCommand(SqlConnection con)
        {

            string cmd_text = "Update Product set Price=@Price, Description=@Description where (PID = @PID)";
            SqlCommand cmd = new SqlCommand(cmd_text, con);
            cmd.Parameters.Add("@PID", SqlDbType.Int, 4, "PID");
            cmd.Parameters.Add("@Price", SqlDbType.Int, 4, "Price");
            cmd.Parameters.Add("@Description", SqlDbType.VarChar, 100, "Description");
            return cmd;
        }


        #endregion

        #region 공통

        //데이터 테이블의 스키만 정보 출력
        private void DatatableSchemaPrint(ListBox listbox, DataTable db)
        {
            //테이블 정보 출력            
            listbox.Items.Add("- 테이블명 : " + db.TableName);
            listbox.Items.Add("- 컬럼개수 : " + db.Columns.Count + "개");
            listbox.Items.Add("----------------------------");
            foreach (DataColumn c in db.Columns)
            {
                listbox.Items.Add(string.Format("{0}\t{1}", c.ColumnName, c.DataType));
            }
        }
        #endregion

        #region Customer
        private void button12_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = "select * from Custom;";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(sql, con);
                //물DB -> 논DB
                adapter.Fill(ds, "Custom");

                //출력
                DatatableSchemaPrint(listBox2, ds.Tables["Custom"]);

                //DataGridView 를 DataBase테이블과 바인딩처리
                dataGridView2.DataSource = ds.Tables["Custom"];
            }
        }



        #endregion

       
    }
}
