using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace LinqSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataContext db = new DataContext("Server=(local);database=ADOTest;" +
                "Integrated Security=true");

            Table<People> Peoples = db.GetTable<People>();

            var Query = from p in Peoples select p;
            foreach (People k in Query)
            {
                listBox1.Items.Add(string.Format("이름 : " + k.Name + ", 나이 : " + 
                    k.Age + ", 남자 : " + k.Male));
            }
        }
    }
}

[Table(Name = "tblPeople")]
public class People
{
	private string _Name;
	[Column(IsPrimaryKey = true, Storage = "_Name")]
	public string Name
	{
		get { return _Name; }
		set { _Name = value; }
	}

	private int _Age;
	[Column(Storage = "_Age")]
	public int Age
	{
		get { return _Age; }
		set { _Age = value; }
	}

	private bool _Male;
	[Column(Storage = "_Male")]
	public bool Male
	{
		get { return _Male; }
		set { _Male = value; }
	}
}

