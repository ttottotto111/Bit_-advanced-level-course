using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MergeTest
{
    public partial class Form1 : Form
    {
        private SqlConnection Con;
        private SqlDataAdapter Adpt;
        private DataSet DbADOTest;
        private DataTable tblPeople2;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Server=(local);database=ADOTest;" +
                "Integrated Security=true";
            Adpt = new SqlDataAdapter("SELECT * FROM tblPeople", Con);
            DbADOTest = new DataSet("ADOTest");
            Adpt.Fill(DbADOTest, "tblPeople");

            tblPeople2 = MakePeopleTable();
            //DbADOTest.Merge(tblPeople2);
            //DbADOTest.Merge(tblPeople2, true, MissingSchemaAction.Add);
            //DbADOTest.Merge(tblPeople2, false, MissingSchemaAction.Add);
            DbADOTest.Merge(tblPeople2, false, MissingSchemaAction.Ignore);

            dataGridView1.DataSource = DbADOTest.Tables["tblPeople"];
        }

        private DataTable MakePeopleTable()
        {
            DataTable tblPeople = new DataTable("tblPeople");

            DataColumn col;
            DataRow row;

            // 열 등록
            col = new DataColumn("Name", typeof(String));
            col.MaxLength = 10;
            col.AllowDBNull = false;
            col.Unique = true;
            tblPeople.Columns.Add(col);

            tblPeople.PrimaryKey = new DataColumn[] { col };

            col = new DataColumn("Age", typeof(Int32));
            col.AllowDBNull = false;
            tblPeople.Columns.Add(col);

            col = new DataColumn("Male", typeof(bool));
            col.AllowDBNull = false;
            tblPeople.Columns.Add(col);

            col = new DataColumn("Tel", typeof(string));
            col.AllowDBNull = true;
            tblPeople.Columns.Add(col);

            // 행 삽입
            row = tblPeople.NewRow();
            row["Name"] = "정우성";
            row["Age"] = 41;
            row["Male"] = true;
            row["tel"] = "111-2222";
            tblPeople.Rows.Add(row);

            row = tblPeople.NewRow();
            row["Name"] = "송혜교";
            row["Age"] = 33;
            row["Male"] = false;
            row["tel"] = "333-4444";
            tblPeople.Rows.Add(row);

            tblPeople.AcceptChanges();
            return tblPeople;
        }
    }
}