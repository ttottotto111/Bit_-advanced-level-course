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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //원본 XML 문서
        private void button3_Click(object sender, EventArgs e)
        {
            WbPaser.XmlRead("data1.xml");
            textBox3.Text = WbPaser.PrintMessage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WbPaser.Paser1("data1.xml");
            textBox1.Text = WbPaser.PrintMessage;
        }

        //파싱 결과물 획득
        private void button2_Click(object sender, EventArgs e)
        {
            List<Book> books = WbPaser.XmlPaser2("data1.xml");
            
            foreach(Book b in books)
            {
                listBox1.Items.Add(b); //b.toString()
            }
        }


    }
}
