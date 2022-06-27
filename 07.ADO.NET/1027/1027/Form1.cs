using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1027
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        #region 도서관리
        private void button1_Click(object sender, EventArgs e)
        {
            if (Control.Singleton.DBLogin == false)
            {
                Control.Singleton.DBConnect();

                if (Control.Singleton.DBLogin == true)
                {
                    List<Book> booklist = Control.Singleton.SelectAllBooks();
                    List<Custom> customlist = Control.Singleton.SelectAllCustom();

                    BookListPrint(booklist);
                    CustomListPrint(customlist);

                    button1.Text = "DB 연결해제";
                }
            }
            else
            {
                Control.Singleton.DBDisConnect();

                if (Control.Singleton.DBLogin == false)
                    button1.Text = "DB 연결";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int price = int.Parse(textBox2.Text);
            string des = textBox3.Text;

            Control.Singleton.InsertProduct(name, price, des);
            List<Book> booklist = Control.Singleton.SelectAllBooks();
            BookListPrint(booklist);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void BookListPrint(List<Book> booklist)
        {
            listView1.Items.Clear();

            foreach(Book book in booklist)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                   book.PID.ToString(), book.Name, book.Price.ToString() }));
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int pid = int.Parse(listView1.SelectedItems[0].Text);

                Book book = Control.Singleton.SelectPidToBook(pid);

                //컨트롤에 출력
                textBox1.Text = book.Name;
                textBox2.Text = book.Price.ToString();
                textBox3.Text = book.Description;
                textBox4.Text = book.PID.ToString();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pid = int.Parse(textBox4.Text);

            Control.Singleton.DeleteProduct(pid);
            List<Book> booklist = Control.Singleton.SelectAllBooks();
            BookListPrint(booklist);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int pid = int.Parse(textBox4.Text);
            int price = int.Parse(textBox2.Text);

            Control.Singleton.UpdateProduct(pid, price);
            List<Book> booklist = Control.Singleton.SelectAllBooks();
            BookListPrint(booklist);
        }

        #endregion

        #region 고객관리

        //리스트뷰에 출력
        private void CustomListPrint(List<Custom> customlist)
        {
            listView2.Items.Clear();

            foreach (Custom custom in customlist)
            {
                listView2.Items.Add(new ListViewItem(new string[] {
                   custom.CID.ToString(), custom.Name, custom.Phone, custom.Addr }));
            }
        }

        //리스트뷰 클릭시 정보출력
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int cid = int.Parse(listView2.SelectedItems[0].Text);

                Custom custom = Control.Singleton.SelectCidToCustom(cid);

                //컨트롤에 출력
                textBox7.Text = custom.CID.ToString();
                textBox8.Text = custom.Name;
                textBox6.Text = custom.Phone;
                textBox5.Text = custom.Addr;

            }
            catch
            {

            }
        }

        //고객 추가
        private void button7_Click(object sender, EventArgs e)
        {
            string name = textBox8.Text;
            string phone = textBox6.Text;
            string addr = textBox5.Text;

            Control.Singleton.InsertCustom(name, phone, addr);
            List<Custom> custom = Control.Singleton.SelectAllCustom();
            CustomListPrint(custom);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int cid = int.Parse(textBox7.Text);

            Control.Singleton.DeleteCustom(cid);
            List<Custom> custom = Control.Singleton.SelectAllCustom();
            CustomListPrint(custom);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int pid = int.Parse(textBox7.Text);
            string phone = textBox6.Text;
            string addr = textBox5.Text;

            Control.Singleton.UpdateCustom(pid, phone);
            Control.Singleton.UpdateAddr(pid, addr);
            List<Custom> custom = Control.Singleton.SelectAllCustom();
            CustomListPrint(custom);
        }


        #endregion


        #region 구매

        //리스트뷰에 출력 ===> 고객
        private void CustomPrint(List<Custom> customlist)
        {
            listView3.Items.Clear();

            foreach (Custom custom in customlist)
            {
                listView3.Items.Add(new ListViewItem(new string[] {
                   custom.CID.ToString(), custom.Name, custom.Phone}));
            }
        }

        //고객검색
        private void button8_Click(object sender, EventArgs e)
        {
            string name = textBox9.Text;

            List<Custom> custom = Control.Singleton.SelectCustom(name);
            CustomPrint(custom);
        }

        //고객 정보출력
        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int cid = int.Parse(listView3.SelectedItems[0].Text);

                Custom custom = Control.Singleton.SelectCidToCustom(cid);

                //컨트롤에 출력
                textBox11.Text = custom.CID.ToString();
                textBox12.Text = custom.Name;

            }
            catch
            {

            }
        }

        //리스트뷰에 출력 ===> 도서
        private void ProductPrint(List<Book> booklist)
        {
            listView4.Items.Clear();

            foreach (Book book in booklist)
            {
                listView4.Items.Add(new ListViewItem(new string[] {
                   book.PID.ToString(), book.Name, book.Price.ToString()}));
            }
        }

        //도서검색
        private void button9_Click(object sender, EventArgs e)
        {
            string name = textBox10.Text;

            List<Book> book = Control.Singleton.SelectProduct(name);
            ProductPrint(book);
        }

        //도서 정보출력
        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int pid = int.Parse(listView4.SelectedItems[0].Text);

                Book book = Control.Singleton.SelectPidToBook(pid);

                //컨트롤에 출력
                textBox13.Text = book.PID.ToString();
                textBox14.Text = book.Name;

            }
            catch
            {

            }
        }

        //구매 버튼
        private void button10_Click(object sender, EventArgs e)
        {
            int cid = int.Parse(textBox11.Text);
            int pid = int.Parse(textBox13.Text);
            int count = int.Parse(textBox15.Text);

            Control.Singleton.BookBuy(cid, pid, count);
        }


        #endregion

        #region 검색

        //고객명 검색
        private void button11_Click(object sender, EventArgs e)
        {
            string name = textBox16.Text;

            List<CustomBuy> custombuy = Control.Singleton.SelectCustomBuy(name);
            CustomBuyPrint(custombuy);
        }

        //리스트뷰에 출력
        private void CustomBuyPrint(List<CustomBuy> buylist)
        {
            listView5.Items.Clear();

            foreach (CustomBuy buy in buylist)
            {
                listView5.Items.Add(new ListViewItem(new string[] {
                   buy.Pid.ToString(), buy.Pname, buy.Price.ToString(), buy.Count.ToString(), buy.Dt}));
            }
        }

        //도서명 검색
        private void button12_Click(object sender, EventArgs e)
        {
            string name = textBox17.Text;

            List<BookBuy> bookbuy = Control.Singleton.SelectBookBuy(name);
            BookBuyPrint(bookbuy);
        }

        //리스트뷰 출력
        private void BookBuyPrint(List<BookBuy> buylist)
        {
            listView6.Items.Clear();

            foreach (BookBuy buy in buylist)
            {
                listView6.Items.Add(new ListViewItem(new string[] {
                   buy.Cid.ToString(), buy.Name, buy.Phone, buy.Addr}));
            }
        }

        #endregion

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        //도서저장 프로시저
        private void button13_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int price = int.Parse(textBox2.Text);
            string des = textBox3.Text;

            Control.Singleton.InsertProduct1(name, price, des);

            List<Book> booklist = Control.Singleton.SelectAllBooks();
            BookListPrint(booklist);
        }
    }
}
