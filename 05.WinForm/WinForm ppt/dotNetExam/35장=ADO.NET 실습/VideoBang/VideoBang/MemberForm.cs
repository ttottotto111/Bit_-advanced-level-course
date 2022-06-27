using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoBang
{
    public partial class MemberForm : Form
    {
        public MemberForm()
        {
            InitializeComponent();
        }

        public string Name1
        {
            get { return textName.Text; }
            set { textName.Text = value.ToString(); }
        }

        public int BYear
        {
            get { return Convert.ToInt32(textByear.Text); }
            set { textByear.Text = value.ToString(); }
        }

        public string Tel
        {
            get { return textTel.Text; }
            set { textTel.Text = value.ToString(); }
        }

        public string Addr
        {
            get { return textAddr.Text; }
            set { textAddr.Text = value.ToString(); }
        }

        public int Money
        {
            get { return Convert.ToInt32(textMoney.Text); }
            set { textMoney.Text = value.ToString(); }
        }

        public int Grade
        {
            get 
            {
                if (radioButton1.Checked) return 1;
                if (radioButton2.Checked) return 2;
                return 3;
            }
            set 
            {
                if ((int)value == 1) radioButton1.Checked = true;
                if ((int)value == 2) radioButton2.Checked = true;
                if ((int)value == 3) radioButton3.Checked = true;
            }
        }
    }
}