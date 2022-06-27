using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VideoBang
{
    public partial class VideoForm : Form
    {
        public VideoForm()
        {
            InitializeComponent();
        }

        public string Name1
        {
            get { return textName.Text; }
            set { textName.Text = value.ToString(); }
        }

        public int Num
        {
            get { return Convert.ToInt32(textNum.Text); }
            set { textNum.Text = value.ToString(); }
        }

        public string Company
        {
            get { return textCompany.Text; }
            set { textCompany.Text = value.ToString(); }
        }

        public string Director
        {
            get { return textDirector.Text; }
            set { textDirector.Text = value.ToString(); }
        }

        public string Major
        {
            get { return textMajor.Text; }
            set { textMajor.Text = value.ToString(); }
        }

        public string Genre
        {
            get
            {
                if (radioButton1.Checked) return "액션";
                if (radioButton2.Checked) return "에로";
                if (radioButton3.Checked) return "어린이";
                if (radioButton4.Checked) return "코미디";
                if (radioButton5.Checked) return "멜로";
                return "기타";
            }
            set
            {
                if ((string)value == "액션") radioButton1.Checked = true;
                if ((string)value == "에로") radioButton2.Checked = true;
                if ((string)value == "어린이") radioButton3.Checked = true;
                if ((string)value == "코미디") radioButton4.Checked = true;
                if ((string)value == "멜로") radioButton5.Checked = true;
                if ((string)value == "기타") radioButton6.Checked = true;
            }
        }
    }
}