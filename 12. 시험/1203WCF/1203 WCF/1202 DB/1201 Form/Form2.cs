using _1201_Form.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1201_Form
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("저장실패");
            }
        }

        public Stu GetStudentInfo()
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            Enumclass type = (Enumclass)comboBox1.SelectedIndex;
            int grade = int.Parse(comboBox2.Text);

            Stu stuclass = new Stu();
            stuclass.Number = id;
            stuclass.Name = name;
            stuclass.SType = type;
            stuclass.Grade = grade;

            return stuclass;
        }
    }
}