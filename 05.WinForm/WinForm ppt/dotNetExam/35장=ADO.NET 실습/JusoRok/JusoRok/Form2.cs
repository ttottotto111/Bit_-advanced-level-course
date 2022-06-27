using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace JusoRok
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string Name1
        {
            get { return textName.Text; }
            set { textName.Text = value.ToString(); }
        }

        public bool Male
        {
            get { return checkMale.Checked; }
            set { checkMale.Checked = value; }
        }

        public DateTime Birth
        {
            get { return dtBirth.Value; }
            set { dtBirth.Value = value; }
        }

        public string Addr
        {
            get { return textAddr.Text; }
            set { textAddr.Text = value.ToString(); }
        }

        public string HandPhone
        {
            get { return textHandPhone.Text; }
            set { textHandPhone.Text = value.ToString(); }
        }

        public string Email
        {
            get { return textEMail.Text; }
            set { textEMail.Text = value.ToString(); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Name == "" || HandPhone == "")
            {
                MessageBox.Show("이름과 핸드폰 번호는 반드시 입력해야 합니다.");
                DialogResult = DialogResult.None;
                return;
            }
            DialogResult = DialogResult.OK;
        }
    }
}