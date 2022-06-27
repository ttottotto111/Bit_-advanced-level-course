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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            WbXMLRead.XmlRead1("data1.xml", textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WbXMLRead.XmlRead2("data1.xml", textBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WbXMLRead.XmlRead3("data1.xml", textBox3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WbXMLRead.XmlRead4("data1.xml", textBox4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = "http://175.125.91.94/openapi/service/rest/meta/KTVnews";
            WbXMLRead.XmlRead4(path, textBox5);
        }
    }
}
