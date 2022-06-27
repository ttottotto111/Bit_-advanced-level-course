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

        /*
         * 1. data2.xml 파일을 debug 폴더(exe 실행파일과 동일 위치)에 저장
         * 2. 해당 xml파일을 분석하여 저장클래스 정의(book 클래스 참조)
         * 3. 파싱 후 결과값을  listbox에 출력
         */ 
        private void button4_Click(object sender, EventArgs e)
        {
            List<Account> acclist = WbPaser.XmlPaser3("data2.xml");

            foreach (Account b in acclist)
            {
                listBox2.Items.Add(b); //b.toString()
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Member> memlist = WbPaser.XmlPaser4("data3.xml");

            foreach (Member b in memlist)
            {
                listBox3.Items.Add(b); //b.toString()
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<Student> stulist = WbPaser.XmlPaser5("data4.xml");

            foreach (Student b in stulist)
            {
                listBox4.Items.Add(b); //b.toString()
            }
        }
    }
}
