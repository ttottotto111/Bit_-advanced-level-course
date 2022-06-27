using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace AccessCon
{
	public partial class Form1 : Form
	{
		private OleDbConnection Con;
		private OleDbDataAdapter Adpt;
		private DataTable tblPeople;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Con = new OleDbConnection();
			Con.ConnectionString = "Provider = Microsoft.JET.OLEDB.4.0;" +
				"Data Source = c:\\ADOTest.mdb";
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			Adpt = new OleDbDataAdapter("SELECT * FROM tblPeople", Con);
			tblPeople = new DataTable("tblPeople");
			Adpt.Fill(tblPeople);
			dataGridView1.DataSource = tblPeople;
		}
	}
}
