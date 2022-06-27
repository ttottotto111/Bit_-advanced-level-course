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
    public partial class Form1 : Form
    {
        StuManager stumanager = new StuManager();

        public Form1()
        {
            InitializeComponent();
        }

        #region 메뉴구성

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 회원정보입력ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 dlg = new Form2();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                Student stu = dlg.GetStudentInfo();
                stumanager.StuInsert(stu);
                PrintStudent();
            }
        }

        private void 프로그램종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 dlg = new Form3();
            dlg.ShowDialog();
        }

        #endregion 

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintStudent();
        }

        public void PrintStudent()
        {
            List<Student> slist = stumanager.PrintAll();

            listView1.Items.Clear();
            label1.Text = "총 학생수 : " + slist.Count + "명";

            foreach (Student stu in slist)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                stu.Number.ToString(), stu.Name, stu.SType.ToString(), stu.Grade.ToString()
            }));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView1.SelectedItems.Count !=0)
            {
                int select=listView1.SelectedItems[0].Index;

                textBox1.Text = listView1.Items[select].SubItems[0].Text;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                PrintStudentInfo(int.Parse(textBox1.Text));
        }

        private void PrintStudentInfo(int number)
        {
            try
            {
                Student stu = stumanager.NumberToStudent(number);
                textBox2.Text = stu.Name;
                comboBox1.Text = stu.SType.ToString();
                comboBox2.Text = stu.Grade.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                stumanager.StuDelete(int.Parse(textBox1.Text));
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                PrintStudent();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(textBox1.Text);
                SubjectType sub = (SubjectType)comboBox1.SelectedIndex;
                int grade = int.Parse(comboBox2.Text);

                stumanager.StuUpdate(num, sub, grade);
                PrintStudent();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stumanager.DisConnect();
        }
    }
}
