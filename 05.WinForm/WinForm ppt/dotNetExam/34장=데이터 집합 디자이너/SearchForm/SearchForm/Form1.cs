using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void tblPeopleBindingNavigatorSaveItem_Click(object sender, EventArgs e)
		{
			this.Validate();
			this.tblPeopleBindingSource.EndEdit();
			this.tableAdapterManager.UpdateAll(this.aDOTestDataSet);

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// TODO: 이 코드는 데이터를 'aDOTestDataSet.tblPeople' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
			this.tblPeopleTableAdapter.Fill(this.aDOTestDataSet.tblPeople);

		}

		private void fillByAgeToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.tblPeopleTableAdapter.FillByAge(this.aDOTestDataSet.tblPeople, ((int)(System.Convert.ChangeType(ageToolStripTextBox.Text, typeof(int)))));
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}

		private void fillByNameToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				this.tblPeopleTableAdapter.FillByName(this.aDOTestDataSet.tblPeople, nameToolStripTextBox.Text);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}

		}
	}
}
