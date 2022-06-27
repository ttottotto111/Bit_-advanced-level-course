using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JusoRok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tblJusoTableAdapter.Fill(this.jusoRokDataSet.tblJuso);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            tblJusoTableAdapter.Update(jusoRokDataSet.tblJuso);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            dlg.Text = "새 친구 추가";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                JusoRokDataSet.tblJusoRow Row = jusoRokDataSet.tblJuso.NewtblJusoRow();
                Row.Name = dlg.Name1;
                Row.Male = dlg.Male;
                Row.Birth = dlg.Birth;
                Row.Addr = dlg.Addr;
                Row.HandPhone = dlg.HandPhone;
                Row.Email = dlg.Email;
                jusoRokDataSet.tblJuso.Rows.Add(Row);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow CR = dataGridView1.CurrentRow;
            if (CR == null)
            {
                MessageBox.Show("편집할 행을 먼저 선택하십시오.");
                return;
            }
            int ID = (int)CR.Cells[0].Value;

            Form2 dlg = new Form2();
            dlg.Text = "친구 정보 수정";

            dlg.Name1 = (string)CR.Cells[1].Value;
            dlg.Male = (bool)CR.Cells[2].Value;
            dlg.Birth = (DateTime)CR.Cells[3].Value;
            dlg.Addr = (string)CR.Cells[4].Value;
            dlg.HandPhone = (string)CR.Cells[5].Value;
            dlg.Email = (string)CR.Cells[6].Value;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                JusoRokDataSet.tblJusoRow Row = jusoRokDataSet.tblJuso.FindByID(ID);
                Row.Name = dlg.Name1;
                Row.Birth = dlg.Birth;
                Row.Male = dlg.Male;
                Row.Addr = dlg.Addr;
                Row.HandPhone = dlg.HandPhone;
                Row.Email = dlg.Email;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow CR = dataGridView1.CurrentRow;
            if (CR == null)
            {
                MessageBox.Show("삭제할 행을 먼저 선택하십시오.");
                return;
            }
            int ID = (int)CR.Cells[0].Value;
            JusoRokDataSet.tblJusoRow Row = jusoRokDataSet.tblJuso.FindByID(ID);
            Row.Delete();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (textName.Text.Length != 0)
            {
                tblJusoBindingSource.Filter = "Name LIKE '%" + textName.Text + "%'";
            }
            else
            {
                tblJusoBindingSource.Filter = "";
            }
        }
    }
}