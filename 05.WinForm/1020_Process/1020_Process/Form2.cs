using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1020_Process
{
    public partial class Form2 : Form
    {
        public string ProcessName
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel)
                return;

            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("프로세스명을 입력하세요.");
                e.Cancel = true;
            }
        }

        //찾아보기
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                ProcessName = openDlg.FileName;
            }
        }        
    }
}
