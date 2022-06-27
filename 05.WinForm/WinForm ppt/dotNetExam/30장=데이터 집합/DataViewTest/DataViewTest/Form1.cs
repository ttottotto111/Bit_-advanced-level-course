using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataViewTest
{
    public partial class Form1 : Form
    {
        private DataTable tblPeople;
        private DataView ViewMan, ViewWoman;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tblPeople = MakePeopleTable();
            tblPeople.DefaultView.Sort = "Age";
            dataGridView1.DataSource = tblPeople;

            ViewMan = new DataView(tblPeople);
            ViewMan.RowFilter = "Male = true";
            ViewMan.Sort = "Name";
			//ViewMan.AllowNew = false;
			//ViewMan.AllowDelete = false;
			//ViewMan.AllowEdit = false;
            dataGridView2.DataSource = ViewMan;

            ViewWoman = new DataView(tblPeople);
            ViewWoman.RowFilter = "Male = false";
            ViewWoman.Sort = "Age";
            dataGridView3.DataSource = ViewWoman;
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

            // 행 삽입
            row = tblPeople.NewRow();
            row["Name"] = "정우성";
            row["Age"] = 36;
            row["Male"] = true;
            tblPeople.Rows.Add(row);

            row = tblPeople.NewRow();
            row["Name"] = "고소영";
            row["Age"] = 32;
            row["Male"] = false;
            tblPeople.Rows.Add(row);

            row = tblPeople.NewRow();
            row["Name"] = "배용준";
            row["Age"] = 37;
            row["Male"] = true;
            tblPeople.Rows.Add(row);

            row = tblPeople.NewRow();
            row["Name"] = "김태희";
            row["Age"] = 29;
            row["Male"] = false;
            tblPeople.Rows.Add(row);

            tblPeople.AcceptChanges();
            return tblPeople;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            DataRowView NewPeople = ViewMan.AddNew();
            NewPeople["Name"] = "김상형";
            NewPeople["Age"] = 29;
            NewPeople["Male"] = true;
            NewPeople.EndEdit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int idx = ViewMan.Find("배용준");
            if (idx != -1)
            {
                DataRowView People = ViewMan[idx];

                People.BeginEdit();
                People["Name"] = "욘사마";
                People.EndEdit();
            }
        }
    }
}