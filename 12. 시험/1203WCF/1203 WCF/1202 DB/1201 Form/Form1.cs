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
    public partial class Form1 : Form
    {
        StuManagerClient stumanager = new StuManagerClient();

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
                Stu stu = dlg.GetStudentInfo();
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

        private void PrintStudent()
        {
            listView1.Items.Clear();
            List<Stu> stulist = stumanager.PrintAll().ToList();

            label1.Text = string.Format("총 학생수 : {0}명", stulist.Count);
            foreach (Stu stu in stulist)
            {
                string subject = transSub(stu.SType);
                listView1.Items.Add(new ListViewItem(new string[] {
                    stu.Number.ToString(),
                    stu.Name,
                    subject,
                    stu.Grade.ToString()
                     }));
            }
            
        }

        private string transSub(Enumclass stype)
        {
            switch (stype)
            {
                case Enumclass.COM:
                    return "컴퓨터";
                case Enumclass.IT:
                    return "IT";
                case Enumclass.GAME:
                    return "게임";
                case Enumclass.ETC:
                    return "기타";
                default:
                    return null;
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
                Stu stu = stumanager.NumberToStudent(number);
                textBox2.Text = stu.Name;
                comboBox1.Text = stu.SType.ToString();
                comboBox2.Text = stu.Grade.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("없다");
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
                Enumclass sub = (Enumclass)comboBox1.SelectedIndex;
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
        }
    }
}
