using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1103XML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = WbXMLWrite.XMLWriteSample();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = WbXMLWrite.XMLWriteSamle1(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = WbXMLWrite.XMLWriteSample2();
        }
    }
}
