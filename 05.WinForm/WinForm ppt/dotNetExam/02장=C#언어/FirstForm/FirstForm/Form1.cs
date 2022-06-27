using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FirstForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void BtnApple_Click(object sender, EventArgs e)
		{
			LblFruit.Text = "Apple";
		}

		private void BtnOrange_Click(object sender, EventArgs e)
		{
			LblFruit.Text = "Orange";
		}
	}
}
