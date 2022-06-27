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

        public Student GetStudentInfo()
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            SubjectType type = (SubjectType)comboBox1.SelectedIndex;
            int grade = int.Parse(comboBox2.Text);

            Student stu = new Student(id, name, type, grade);
            return stu;
        }
    }
}