using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UntypedDataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReadXml_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dataSet1.ReadXml(openFileDialog1.FileName, 
                    XmlReadMode.ReadSchema);
                dataGridView1.DataSource = dataSet1.Tables["tblPeople"];
            }
        }
    }
}