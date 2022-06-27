using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

namespace ORDesigner
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			DataPeopleDataContext db = new DataPeopleDataContext();
			Table<tblPeople> Peoples = db.GetTable<tblPeople>();

			var Query = from p in Peoples select p;
			foreach (tblPeople k in Query)
			{
				listBox1.Items.Add(string.Format("이름 : " + k.Name + ", 나이 : " +
					k.Age + ", 남자 : " + k.Male));
			}

			int? Age = 0;
			db.IncSomeAge("김태희", ref Age);
		}
	}
}

