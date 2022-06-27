using _11123PictureClient.localhost1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _11123PictureClient
{
    public partial class Form2 : Form
    {
        private DBSaveService db = new DBSaveService();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Save(textBox1.Text, textBox2.Text, textBox3.Text);
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text + "@" + textBox2.Text + "@" + textBox3.Text;
            byte[] member = Encoding.UTF8.GetBytes(str);

            db.SaveByte(member);

            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }


    }
}
