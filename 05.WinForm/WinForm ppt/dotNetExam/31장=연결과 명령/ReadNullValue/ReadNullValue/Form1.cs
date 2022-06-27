using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ReadNullValue
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

        private void btnRead_Click(object sender, EventArgs e)
        {
			/*
            string Sql = "SELECT SUM(Age) FROM tblPeople";
            SqlCommand Com = new SqlCommand(Sql, Con);

            int Result = (int)Com.ExecuteScalar();
            textBox1.Text = Result.ToString();
			//*/

			//*
			string Sql = "SELECT SUM(Age) FROM tblPeople WHERE Age > 100";
			SqlCommand Com = new SqlCommand(Sql, Con);
			
			SqlDataReader R= Com.ExecuteReader();
			R.Read();
			if (R.IsDBNull(0) == true)
			{
				textBox1.Text = "알 수 없는 값";
			}
			else
			{
				textBox1.Text = R[0].ToString();
			}
			R.Close();
			//*/
		}
    }
}