using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WB.Database;
using Wb.XMLPaser;

namespace _1103XML
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        #region 프로그램 시작 시점
        private void Form4_Load(object sender, EventArgs e)
        {
            AccountGridViewInit();
            AccountIOGridViewInit();
            AccountSelectIOGridViewInit();
        }

        private void AccountGridViewInit()
        {
            AccountDB.Singleton.CreateTable();
            dataGridView1.DataSource = AccountDB.Singleton.Account_Table;
        }
        private void AccountIOGridViewInit()
        {
            AccountIODB.Singleton.CreateTable();
            dataGridView2.DataSource = AccountIODB.Singleton.AccountIO_Table;
        }
        private void AccountSelectIOGridViewInit()
        {
            AccountSelectIODB.Singleton.CreateTable();
            dataGridView3.DataSource = AccountSelectIODB.Singleton.AccountIO_Table;
        }
        #endregion 

        //Account 버튼 클릭
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = AccountXML.Singleton.XmlRead("accounts.xml");

            List<Wb.XMLPaser.Account> acclist = AccountXML.Singleton.XmlPaser("accounts.xml");
            AccountDB.Singleton.InsertAllAccount(acclist);

            //------------콤보박스에 출력
            comboBox1.Items.Add("id를 선택하세요");
            List<int> accidlist = AccountDB.Singleton.GetAccIDList();
            foreach(int accid in accidlist)
            {
                comboBox1.Items.Add(accid);
            }
            comboBox1.SelectedIndex = 0;
        }

        //AccountIO버튼 클릭
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = AccountIOXML.Singleton.XmlRead("acclistio.xml");

            List<Wb.XMLPaser.AccountIO> acclist = AccountIOXML.Singleton.XmlPaser("acclistio.xml");
            AccountIODB.Singleton.InsertAllAccountIO(acclist);
        }

        //계좌번호를 갖고 있는 콤보박스 선택시 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                return;

            int accid  = int.Parse(comboBox1.Text);

            //Account정보 출력
            Wb.XMLPaser.Account acc = AccountDB.Singleton.AccIdToAccount(accid);
            textBox3.Text = acc.Id.ToString();
            textBox4.Text = acc.Name;
            textBox5.Text = acc.Balance.ToString();

            //AccoutSelectList정보 출력
            List<Wb.XMLPaser.AccountIO> iolist = 
                AccountIODB.Singleton.AccIdToAccountIOList(accid);
            AccountSelectIODB.Singleton.InsertAllAccountIO(iolist);
        }
    }
}
