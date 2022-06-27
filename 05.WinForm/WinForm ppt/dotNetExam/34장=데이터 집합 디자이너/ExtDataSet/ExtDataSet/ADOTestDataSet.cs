using System;
using System.Windows.Forms;

namespace ExtDataSet
{
	partial class ADOTestDataSet
	{
		public int Add(int a, int b) { return a + b; }
	}
}

namespace ExtDataSet.ADOTestDataSetTableAdapters
{
	partial class tblPeopleTableAdapter
	{
		public void Merong() { MessageBox.Show("메롱 메롱"); }
	}
}
