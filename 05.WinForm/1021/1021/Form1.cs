using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

            label6.Visible = false;
            textBox5.Visible = false;

            label20.Visible = false;
            textBox15.Visible = false;
        }

        #region 계좌 개설
        //[계좌 개설]계좌번호 생성 버튼
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AccountType type = (AccountType)comboBox1.SelectedIndex;

                //컨트롤에 전달
                string id = AccManager.Singleton.MakeAccountID(type);

                textBox1.Text = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //[계좌 개설] 콤보박스 - 계좌 선택
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //정기입금액 ui(활성, 비활성)
            if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 3)
                textBox4.ReadOnly = false;
            else
                textBox4.ReadOnly = true;

            //이자율 ui (동적생성, 제거)
            if (comboBox1.SelectedIndex == 2)
                label6.Visible = textBox5.Visible = true;
            else
                label6.Visible = textBox5.Visible = false;
        }

        //[계좌 개설] 계좌개설 버튼
        private void button2_Click(object sender, EventArgs e)
        {
            AccountType type = (AccountType)comboBox1.SelectedIndex;
            string id = textBox1.Text;
            if (id.Equals(string.Empty))
            {
                MessageBox.Show("ID를 입력하세요");
                return;
            }
            string name = textBox2.Text;
            int money = int.Parse(textBox3.Text);

            //컨트롤에 전달
            if (AccManager.Singleton.InsertAccount(type, id, name, money) == false)
                MessageBox.Show("계좌 생성 실패(ID중복)");
            else
            {
                comboBox1.SelectedIndex = 0;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }


        #endregion

        #region [계좌검색] 검색정보입력

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
                label8.Text = "계좌번호";
            else if (comboBox2.SelectedIndex == 1)
                label8.Text = "이름";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string key = textBox6.Text;

                if (comboBox2.SelectedIndex == 0)
                {
                    NormalAcc acc = AccManager.Singleton.IdToAccount(key);
                    AccListPrint(acc);
                }
                else
                {
                    List<NormalAcc> acc = AccManager.Singleton.NameToAccount(key);
                    AccListPrint(acc);
                }

                textBox6.Text = "";
            }
            catch(Exception)
            {

            }
        }

        private void AccListPrint(NormalAcc acc)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(acc.Id);
        }

        private void AccListPrint(List<NormalAcc> acc)
        {
            listBox1.Items.Clear();
            foreach(NormalAcc data in acc)
            {
                listBox1.Items.Add(data.Id);
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button3_Click(sender, e);
            }
        }

        #endregion

        #region [계좌검색] 리스트박스

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string accid = listBox1.SelectedItem.ToString();
                NormalAcc acc = AccManager.Singleton.IdToAccount(accid);

                //오른쪽에 출력
                AccInfoTopPrint(acc);
                AccInfoBottomPrint(acc.AccList);
            }
            catch(Exception)
            {

            }
        }

        private void AccInfoBottomPrint(List<AccountIOList> acclist)
        {
            listView1.Items.Clear();

            foreach (AccountIOList iolist in acclist)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                    iolist.Id, iolist.StimeDay, iolist.StimeTime,
                    iolist.Input.ToString(), iolist.Output.ToString(),
                    iolist.Balance.ToString()
                     }));
            }

        }
        private void AccInfoTopPrint(NormalAcc acc)
        {
            textBox7.Text = acc.Type.ToString();
            textBox8.Text = acc.Name;
            textBox9.Text = acc.StimeDay;
            textBox10.Text = acc.Id;
            textBox11.Text = acc.Balance.ToString() + "원";
            textBox12.Text = acc.StimeTime;
        }

        //입출금 버튼
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            textBox16.Text = textBox7.Text;
            textBox17.Text = textBox8.Text;
            textBox18.Text = textBox9.Text;
            textBox19.Text = textBox10.Text;
            textBox20.Text = textBox11.Text;
            textBox21.Text = textBox12.Text;
        }

        //시뮬레이션 버튼
        private void button10_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        //삭제버튼
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox10.Text;
                AccManager.Singleton.DeleteAccount(id);

                //컨트롤 출력 초기화
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                listView1.Items.Clear();
                listBox1.Items.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("삭제 에러 : " + ex.Message);
            }
        }


        #endregion

        #region 입출금

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedIndex == 0)
            {
                label20.Visible = textBox15.Visible = false;
                label19.Text = "입금액";
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                label20.Visible = textBox15.Visible = false;
                label19.Text = "출금액";
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                label20.Visible = textBox15.Visible = true;
                label19.Text = "이체금액";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string curid = textBox19.Text;
            int money = int.Parse(textBox14.Text);
            string transid = textBox15.Text;
            try
            {

                if (comboBox4.SelectedIndex == 0) //입금
                {
                    AccManager.Singleton.InputMoney(curid, money);
                }
                else if (comboBox4.SelectedIndex == 1) //출금
                {
                    AccManager.Singleton.OutputMoney(curid, money);
                }
                else if (comboBox4.SelectedIndex == 2) //이체
                {
                    AccManager.Singleton.TransMoney(curid, transid, money);
                }

                textBox14.Text = "";
                textBox15.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("거래요청 에러 : " + ex.Message);
            }

        }



        #endregion

        #region 시뮬레이션

        //콤보박스에 계좌번호 출력
        private void button7_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            foreach(KeyValuePair<string,NormalAcc> data in AccManager.Singleton.Acclist)
            {
                comboBox3.Items.Add(data.Key);
            }
        }

        //시뮬레이션 시작
        private void button8_Click(object sender, EventArgs e)
        {
            string id = comboBox3.SelectedItem.ToString();
            int count = int.Parse(textBox13.Text);

            //리턴정보를 L-VALUE로 획득
            Simulation data = AccManager.Singleton.SimulRun(id, count);

            textBox22.Text = data.Count.ToString();
            textBox23.Text = data.Inputcount.ToString();
            textBox24.Text = data.Outputcount.ToString();
            textBox25.Text = data.Balance.ToString();
        }


        #endregion

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisX.Interval = (int.Parse(textBox22.Text) / 10);
                chart1.ChartAreas[0].AxisY.Interval = (int.Parse(textBox25.Text) / 50000);

                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = int.Parse(textBox22.Text);
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = 200000;

                for (int i = 1; i < int.Parse(textBox22.Text); i++)
                {
                    chart1.Series[0].Points.AddXY(i, int.Parse(listView1.Items[i].SubItems[5].Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("계좌검색을 먼저 해주세요.");
            }
        }

       
    }
}
