using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlCon
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			MySqlConnection Con = new MySqlConnection();
			Con.ConnectionString = "Data Source=localhost;Database=ADOTest;"
				+ "User Id=root;Password=mypass";
			Con.Open();
			string Rec;
			MySqlCommand Com = new MySqlCommand("SELECT * FROM tblPeople", Con);
			MySqlDataReader R;
			R = Com.ExecuteReader();
			listBox1.Items.Clear();
			while (R.Read())
			{
				Rec = string.Format("이름 : {0}, 나이 : {1}, 성별 : {2}",
					R["Name"], R["Age"], R["Male"]);
				listBox1.Items.Add(Rec);
			}
			R.Close();
			Con.Close();
		}
	}
}
