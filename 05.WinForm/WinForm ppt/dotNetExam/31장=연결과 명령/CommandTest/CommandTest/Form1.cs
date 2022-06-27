using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CommandTest
{
    public partial class Form1 : Form
    {
        private SqlConnection Con;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Server=(local);database=ADOTest;" +
                "Integrated Security=true";
            Con.Open();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Con.Close();
        }

        private void PrintTable()
        {
            //*
            string Rec;
            SqlCommand Com = new SqlCommand("SELECT * FROM tblPeople", Con);
            SqlDataReader R;
            R = Com.ExecuteReader();
            listBox1.Items.Clear();
            while (R.Read())
            {
                Rec = string.Format("이름 : {0}, 나이 : {1}, 성별 : {2}",
                    R["Name"], R["Age"], (bool)R[2] ? "남자":"여자");
                listBox1.Items.Add(Rec);
            }
            R.Close();
            //*/

            /* 두 개 이상의 결과셋 읽기
            string Rec;
            SqlCommand Com = new SqlCommand("SELECT * FROM tblPeople;" + 
                "SELECT * FROM tblSale", Con);
            SqlDataReader R;
            R = Com.ExecuteReader();
            listBox1.Items.Clear();
            while (R.Read())
            {
                Rec = string.Format("이름 : {0}, 나이 : {1}, 성별 : {2}",
                    R["Name"], R["Age"], (bool)R[2] ? "남자" : "여자");
                listBox1.Items.Add(Rec);
            }
            R.NextResult();
            while (R.Read())
            {
                Rec = string.Format("번호 : {0}, 고객 : {1}, 상품 : {2}, 날짜 : {3}",
                    R["OrderNo"], R["Customer"], R["Item"], R["ODate"]);
                listBox1.Items.Add(Rec);
            }
            R.Close();
            //*/

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            PrintTable();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Sql = "UPDATE tblPeople SET Age = Age + 1 WHERE Name = '정우성'";
            SqlCommand Com = new SqlCommand(Sql, Con);
            Com.ExecuteNonQuery();
            PrintTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string Sql = "DELETE tblPeople WHERE Name = '배용준'";
            SqlCommand Com = new SqlCommand(Sql, Con);
            Com.ExecuteNonQuery();
            PrintTable();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            string Sql = "SELECT SUM(Age) FROM tblPeople";
            SqlCommand Com = new SqlCommand(Sql, Con);
            int Sum = (int)Com.ExecuteScalar();
            MessageBox.Show("나이의 총 합은 " + Sum + "입니다.");
        }

        private void btnInsert1_Click(object sender, EventArgs e)
        {
            string Sql = string.Format("INSERT INTO tblPeople VALUES ('{0}',{1},{2})",
                textName.Text, textAge.Text, checkMale.Checked ? 1:0);
            SqlCommand Com = new SqlCommand(Sql, Con);
            Com.ExecuteNonQuery();
            PrintTable();
        }

        private void btnInsert2_Click(object sender, EventArgs e)
        {
            string Sql = "INSERT INTO tblPeople VALUES (@Name,@Age,@Male)";
            SqlCommand Com = new SqlCommand(Sql, Con);
            Com.Parameters.Add("@Name", SqlDbType.NVarChar, 10);
            Com.Parameters.Add("@Age", SqlDbType.Int);
            Com.Parameters.Add("@Male", SqlDbType.Bit);

            Com.Parameters["@Name"].Value = textName.Text;
            Com.Parameters["@Age"].Value = textAge.Text;
            Com.Parameters["@Male"].Value = checkMale.Checked ? 1 : 0;

            Com.ExecuteNonQuery();
            PrintTable();
        }

        private void btnIncAllAge_Click(object sender, EventArgs e)
        {
            SqlCommand Com = new SqlCommand("IncAllAge", Con);
            Com.CommandType = CommandType.StoredProcedure;
            int nRow;
            nRow = Com.ExecuteNonQuery();
            PrintTable();
            MessageBox.Show("영향받은 행수 = " + nRow);
        }

        private void btnIncSomeAge_Click(object sender, EventArgs e)
        {
            // 명령 객체 생성
            SqlCommand Com = new SqlCommand("IncSomeAge", Con);
            Com.CommandType = CommandType.StoredProcedure;

            // 파라미터 설정
            Com.Parameters.Add("@Name", SqlDbType.NVarChar, 10);
            Com.Parameters.Add("@Age", SqlDbType.Int);
            Com.Parameters["@Age"].Direction = ParameterDirection.Output;

            // 호출
            Com.Parameters["@Name"].Value = "김태희";
            Com.ExecuteNonQuery();

            // 결과 출력
            PrintTable();
            int Age = (int)Com.Parameters["@Age"].Value;
            MessageBox.Show("프로시저 호출 후 나이 = " + Age);
        }

        private void btnRollback_Click(object sender, EventArgs e)
        {
            SqlTransaction Tr = Con.BeginTransaction();
            SqlCommand Com = Con.CreateCommand();
            Com.Connection = Con;
            Com.Transaction = Tr;
            Com.CommandText = "UPDATE tblPeople SET Age = Age + 1 WHERE Name = '정우성'";
            Com.ExecuteNonQuery();
            Com.CommandText = "UPDATE tblPeople SET Age = Age - 1 WHERE Name = '배용준'";
            Com.ExecuteNonQuery();
            Tr.Rollback();
            PrintTable();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            SqlTransaction Tr = Con.BeginTransaction();
            SqlCommand Com = Con.CreateCommand();
            Com.Connection = Con;
            Com.Transaction = Tr;
            Com.CommandText = "UPDATE tblPeople SET Age = Age + 1 WHERE Name = '정우성'";
            Com.ExecuteNonQuery();
            Com.CommandText = "UPDATE tblPeople SET Age = Age - 1 WHERE Name = '배용준'";
            Com.ExecuteNonQuery();
            Tr.Commit();
            PrintTable();
        }
    }
}