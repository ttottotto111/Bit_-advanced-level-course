using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LinqDataSet
{
    public partial class Form1 : Form
    {
        private static SqlConnection Con;
        private static SqlDataAdapter Adpt;
        private static DataTable tblPeople;

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
            tblPeople = new DataTable("tblPeople");
            Adpt.Fill(tblPeople);

            var tp = tblPeople.AsEnumerable();
            //var Q = from p in tp select p;
            //var Q = from p in tp where p.Field<bool>("Male") == true select p;
            var Q = from p in tp orderby p.Field<int>("Age") select p;
            foreach (var p in Q)
            {
                listBox1.Items.Add(string.Format("이름 : " + p.ItemArray[0] + ", 나이 : " + 
                    p.ItemArray[1] + ", 남자 : " + p.ItemArray[2]));
            }
        }
    }
}
