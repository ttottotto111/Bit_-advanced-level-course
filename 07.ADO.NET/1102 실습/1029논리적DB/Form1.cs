using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1029논리적DB
{
    public partial class Form1 : Form
    {
        LogicalDB db = new LogicalDB();

        public Form1()
        {
            InitializeComponent();
        }

        //DataTable 생성
        private void button1_Click(object sender, EventArgs e)
        {
            db.CreateTable();

            db.BindingGridView(dataGridView1);

            //테이블 정보 출력            
            listBox1.Items.Add("- 테이블명 : " + db.BookTableName);
            listBox1.Items.Add("- 컬럼개수 : " + db.BookTableColumnCount + "개");
            listBox1.Items.Add("----------------------------");
            foreach(DataColumn c in db.BookColumns)
            {
                listBox1.Items.Add(string.Format("{0}\t{1}", c.ColumnName, c.DataType));
            }
        }

        //insert
        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int price   = int.Parse(textBox2.Text);
            DateTime dt = dateTimePicker1.Value;

            db.InsertBook(name, price, dt);
        }

        //데이터그리드뷰를 클릭
        //PID를 획득... 
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var pid = dataGridView1.SelectedCells[0].Value.ToString();
                textBox3.Text = pid;

                var name = dataGridView1.SelectedCells[1].Value.ToString();
                textBox3.Text = name;

                var price = int.Parse(dataGridView1.SelectedCells[2].Value.ToString());
                textBox3.Text = price.ToString();

                var dt = dataGridView1.SelectedCells[3].Value;
                dateTimePicker1.Value = (DateTime)dt;
            }
            catch
            {

            }
        }

        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            int pid = int.Parse(textBox3.Text);

            db.DeleteBook(pid);
        }

        //XML  저장
        private void button4_Click(object sender, EventArgs e)
        {
            db.Save();
        }

        //XML 불러오기
        private void button5_Click(object sender, EventArgs e)
        {
            db.Load();
            db.BindingGridView(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
