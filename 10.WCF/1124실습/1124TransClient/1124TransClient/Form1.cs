﻿using _1124TransClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1124TransClient
{
    public partial class Form1 : Form
    {
        private TransClient tran = new TransClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            textBox2.Text = tran.TransText(text);
        }
    }
}
