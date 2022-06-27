using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1014_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("TEST");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                this.Opacity += 0.1D;
            }
            else if(e.KeyCode == Keys.Down)
            {
                this.Opacity -= 0.1D;
            }
        }

        //마우스 클릭이벤트 핸들러 등록 - 마우스 좌표 획득?
        private void Form1_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show("TEST");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
