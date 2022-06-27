using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GetChangesTest
{
    public partial class Form1 : Form
    {
        private SqlConnection Con;
        private SqlDataAdapter Adpt;
        DataSet DbADOTest;

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
            dataGridView1.DataSource = DbADOTest.Tables["tblPeople"];
        }

        private void btnGetChanges_Click(object sender, EventArgs e)
        {
            if (DbADOTest.HasChanges() == true)
            {
                DataSet Change = DbADOTest.GetChanges();
                DataTable tblPeople = Change.Tables["tblPeople"];
                string Record = "";
                listBox1.Items.Clear();
                foreach (DataRow R in tblPeople.Rows)
                {
                    switch (R.RowState)
                    {
                    case DataRowState.Added:
                        Record = string.Format("추가 : {0}", R["Name"]);
                        break;
                    case DataRowState.Deleted:
                        Record = string.Format("삭제 : {0}", R["Name", 
                            DataRowVersion.Original]);
                        break;
                    case DataRowState.Modified:
                        Record = string.Format("수정 : {0} -> {1}"
                            , R["Name", DataRowVersion.Original], R["Name"]);
                        break;
                    }
                    listBox1.Items.Add(Record);
                }
            }
        }

    }
}