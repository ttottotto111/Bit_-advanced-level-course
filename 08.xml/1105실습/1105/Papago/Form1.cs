using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string jsonstr =  WbPapago.Sample(textBox1.Text);

            //방법 1
            JObject jobj = JObject.Parse(jsonstr);
            textBox2.Text = jobj["message"]["result"]["translatedText"].ToString();
        }
    }
}
