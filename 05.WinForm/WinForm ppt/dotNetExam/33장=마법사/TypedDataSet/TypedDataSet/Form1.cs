using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TypedDataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'aDOTestDataSet.tblPeople' 테이블에 로드합니다. 필요한 경우 이 코드를 이동하거나 제거할 수 있습니다.
            this.tblPeopleTableAdapter.Fill(this.aDOTestDataSet.tblPeople);

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string Name = textName.Text;
            ADOTestDataSet.tblPeopleRow Result = aDOTestDataSet.tblPeople.
                FindByName(Name);
            if (Result == null)
            {
                MessageBox.Show("테이블에 존재하지 않는 사람입니다.");
            }
            else
            {
                MessageBox.Show(Name + "의 나이는 " + Result.Age + "살입니다.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ADOTestDataSet.tblPeopleRow Result = aDOTestDataSet.tblPeople.
                FindByName(textName2.Text);
            if (Result != null)
            {
                Result.Age = Convert.ToInt32(textAge.Text);
            }
        }
    }
}