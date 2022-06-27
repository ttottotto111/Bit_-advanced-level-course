using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConnectionEvent
{
    public partial class Form1 : Form
    {
        private SqlConnection Con;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Server=(local);database=ADOTest;" +
                "Integrated Security=true";
            Con.StateChange += new StateChangeEventHandler(Con_StateChange);
            Con.InfoMessage += new SqlInfoMessageEventHandler(Con_InfoMessage);
        }

        void Con_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            listBox1.Items.Add(e.Message);
        }

        void Con_StateChange(object sender, StateChangeEventArgs e)
        {
            string Mes;
            Mes = string.Format("원래 상태 : {0}, 현재 상태 {1}", 
                e.OriginalState, e.CurrentState);
            listBox1.Items.Add(Mes);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
        }
    }
}