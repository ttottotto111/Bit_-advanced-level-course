using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Validation
{
    public partial class Form1 : Form
    {
        private SqlConnection Con;
        private SqlDataAdapter Adpt;
        DataTable tblPeople;

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
            tblPeople.ColumnChanging += 
                new DataColumnChangeEventHandler(tblPeople_ColumnChanging);
            tblPeople.RowChanging += 
                new DataRowChangeEventHandler(tblPeople_RowChanging);

            Adpt.Fill(tblPeople);
            dataGridView1.DataSource = tblPeople;
        }

        //* 컬럼 에러 설정
        void tblPeople_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "Age")
            {
                if ((int)e.ProposedValue < 0 || (int)e.ProposedValue > 100)
                {
                    e.Row.SetColumnError("Age", "나이는 0 ~ 100 사이여야 합니다.");
                }
                else
                {
                    e.Row.SetColumnError("Age", "");
                }
            }
        }
        //*/

        /* 수정 거부
        void tblPeople_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "Age")
            {
                if ((int)e.ProposedValue < 0 || (int)e.ProposedValue > 100)
                {
                    MessageBox.Show("나이는 0 ~ 100 사이여야 합니다.");
                    e.ProposedValue = e.Row["Age", DataRowVersion.Original];
                }
            }
        }
        //*/

        void tblPeople_RowChanging(object sender, DataRowChangeEventArgs e)
        {
            if ((bool)e.Row["Male"] == false)
            {
                if ((int)e.Row["Age"] > 40)
                {
                    e.Row.SetColumnError("Age", "여성의 나이는 40세 이하여야 합니다.");
                }
                else
                {
                    e.Row.SetColumnError("Age", "");
                }
            }
        }
     }
}