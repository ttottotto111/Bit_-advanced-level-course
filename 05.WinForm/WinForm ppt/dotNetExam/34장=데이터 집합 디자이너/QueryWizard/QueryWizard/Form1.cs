using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryWizard
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

        private void btnFillBy35_Click(object sender, EventArgs e)
        {
            this.tblPeopleTableAdapter.FillBy35(this.aDOTestDataSet.tblPeople);
        }

        private void btnGetPeopleCount_Click(object sender, EventArgs e)
        {
            int Count = tblPeopleTableAdapter.GetPeopleCount().Value;
            MessageBox.Show("총 인원은 " + Count + "명입니다.");
        }

        private void btnUpdateByName_Click(object sender, EventArgs e)
        {
            tblPeopleTableAdapter.UpdateByName(60, true, "배용준");
            this.tblPeopleTableAdapter.Fill(this.aDOTestDataSet.tblPeople);
        }

        private void btnGetToday_Click(object sender, EventArgs e)
        {
            ADOTestDataSetTableAdapters.QueriesTableAdapter Q =
                new ADOTestDataSetTableAdapters.QueriesTableAdapter();

            DateTime Now = Q.GetToday().Value;
            MessageBox.Show("오늘은 " + Now + "입니다.");
        }
    }
}
