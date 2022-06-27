using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1103xml과db연결
{
    public partial class Form1 : Form
    {
        private List<Item> itemlist;

        public Form1()
        {
            InitializeComponent();
        }
        #region XML 사이트 연결& 파싱
        private void button2_Click(object sender, EventArgs e)
        {
            string path = "http://175.125.91.94/oasis/service/rest/meta13/getKSCD0801";
            WbXMLRead.XmlRead(path, textBox1);
            #region XML 파싱
            itemlist = WbPaser.XmlPaser(path);
            #endregion
        }
        #endregion



        #region 데이터 베이스 연동
        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = WbDataBase.Singleton.Connect();

            //datagridview를 database 테이블과 바인딩 처리
            BindingGridView(dataGridView1, ds.Tables["News"]);

            #region 아이템 추가
            foreach (Item item in itemlist)
            {
                WbDataBase.Singleton.InsertItem(item);
            }

            WbDataBase.Singleton.Update();
            
            #endregion
        }

        public void BindingGridView(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = dt;
        }
        #endregion

        
    }
}
