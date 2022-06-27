using _1105.SearchBook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1105
{
    public partial class Form2 : Form
    {
        private WbsearchBook search = new WbsearchBook();

        public Form2()
        {
            InitializeComponent();
        }

        //검색
        private void button1_Click(object sender, EventArgs e)
        {
            string xmlstring;
            search.Find(textBox1.Text.Trim(), out xmlstring);
            textBox7.Text = xmlstring;
            ListBoxPrint(search.BookList);
        }

        private void ListBoxPrint(List<Book> booklist)
        {
            listBox1.Items.Clear();

            //타이틀만 출력
            foreach(Book book in booklist)
            {
                listBox1.Items.Add(book.Title.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = listBox1.SelectedItem.ToString();
            
            Book book = search.BookNameToBook(name);
            if(book !=null)
            {
                textBox2.Text = book.Title;
                textBox3.Text = book.Author;
                textBox4.Text = book.Price.ToString();
                textBox5.Text = book.Publisher;
                textBox6.Text = book.Description;
                textBox8.Text = book.Image;
                textBox9.Text = book.Link;
                pictureBox1.ImageLocation = book.Image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string shorturl;
            search.MakeURL(textBox9.Text.Trim(), out shorturl);
            ShortPrint(search.UrlList);
            pictureBox2.ImageLocation = textBox10.Text + ".qr";
        }

        private void ShortPrint(List<Shorturl> urllist)
        {
            textBox10.Text="";

            //타이틀만 출력
            foreach (Shorturl surl in urllist)
            {
                textBox10.Text = surl.ShortUrl.ToString();
            }
        }
    }
}
