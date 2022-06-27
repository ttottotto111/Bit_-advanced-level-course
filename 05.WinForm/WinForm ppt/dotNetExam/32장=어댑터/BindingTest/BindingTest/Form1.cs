using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BindingTest
{
    public partial class Form1 : Form
    {
        private SqlConnection Con;
        private SqlDataAdapter Adpt;
        private DataSet DbADOTest;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Server=(local);database=ADOTest;" +
                "Integrated Security=true";
            Adpt = new SqlDataAdapter("SELECT * FROM tblPeople", Con);
            DbADOTest = new DataSet("ADOTest");
            Adpt.Fill(DbADOTest, "tblPeople");

            // 단순히 출력만 하기
            //textBox1.Text = (string)DbADOTest.Tables["tblPeople"].Rows[0]["Name"];

            // 바인딩하기
            textBox1.DataBindings.Add("Text", DbADOTest, "tblPeople.Name");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BindingContext[DbADOTest, "tblPeople"].Position++;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            BindingContext[DbADOTest, "tblPeople"].Position--;
        }
    }
}