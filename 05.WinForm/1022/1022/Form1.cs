using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1022
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
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        #region 선수생성

        //등번호 생성버튼
        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            string id = string.Empty;
            id += r.Next(1, 100);
            textBox1.Text = id;
        }

        //선수생성버튼
        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            if (id.Equals(string.Empty))
            {
                MessageBox.Show("등번호가 없습니다.");
                return;
            }

            string name = textBox2.Text;

            PositionType position = (PositionType)comboBox1.SelectedIndex;
            BatterType bat = (BatterType)comboBox2.SelectedIndex;

            //컨트롤에 전달
            if (PlayerManager.Singleton.InsertPlayer(id, name, position, bat) == false)
                MessageBox.Show("계좌 생성 실패(ID중복)");
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                comboBox1.SelectedIndex = 0;
                comboBox2.SelectedIndex = 0;
            }
        }


        #endregion

        #region 선수검색

        //선수검색 버튼
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string key = textBox3.Text;

                if (comboBox3.SelectedIndex == 0)
                {
                    Hitter hit = PlayerManager.Singleton.IdToAccount(key);
                    AccListPrint(hit);
                }
                else
                {
                    List<Hitter> hit = PlayerManager.Singleton.NameToAccount(key);
                    AccListPrint(hit);
                }

                textBox3.Text = "";
            }
            catch (Exception)
            {

            }
        }
        private void AccListPrint(Hitter hit)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add(hit.Id);
        }

        private void AccListPrint(List<Hitter> hit)
        {
            listBox1.Items.Clear();
            foreach (Hitter data in hit)
            {
                listBox1.Items.Add(data.Id);
            }
        }

        //리스트박스 선택
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string accid = listBox1.SelectedItem.ToString();
                Hitter hit = PlayerManager.Singleton.IdToAccount(accid);

                //오른쪽에 출력
                AccInfoTopPrint(hit);
                AccInfoBottomPrint(hit.Plist);
            }
            catch (Exception)
            {

            }
        }

        //상단 정보출력
        private void AccInfoTopPrint(Hitter hit)
        {
            textBox4.Text = hit.Id;
            textBox5.Text = hit.Name;       
            textBox8.Text = hit.Play.ToString();
            textBox9.Text = hit.Count.ToString();
            textBox10.Text = hit.Average.ToString();

            #region 포지션
            if (hit.Potype.ToString()=="SACKER1")
            {
                textBox6.Text ="1루수";
            }
            else if(hit.Potype.ToString() == "SACKER2")
            {
                textBox6.Text = "2루수";
            }
            else if (hit.Potype.ToString() == "SACKER3")
            {
                textBox6.Text = "3루수";
            }
            else if (hit.Potype.ToString() == "SHORTSTOP")
            {
                textBox6.Text = "유격수";
            }
            else if (hit.Potype.ToString() == "LEFT")
            {
                textBox6.Text = "좌익수";
            }
            else if (hit.Potype.ToString() == "MID")
            {
                textBox6.Text = "중견수";
            }
            else if (hit.Potype.ToString() == "RIGHT")
            {
                textBox6.Text = "우익수";
            }
            else if (hit.Potype.ToString() == "CATCHER")
            {
                textBox6.Text = "포수";
            }
            #endregion

            #region 타석
            if (hit.Battype.ToString() == "LEFTHITTER")
            {
                textBox7.Text = "좌타자";
            }
            else if (hit.Battype.ToString() == "RIGHTHITTER")
            {
                textBox7.Text = "우타자";
            }
            else if (hit.Battype.ToString() == "SWITCHHITTER")
            {
                textBox7.Text = "스위치타자";
            }

            #endregion
        }

        //하단 정보출력
        private void AccInfoBottomPrint(List<PlayerIOList> plist)
        {
            listView1.Items.Clear();

            foreach (PlayerIOList iolist in plist)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                    iolist.Hit1.ToString(), iolist.Hit2.ToString(), iolist.Hit3.ToString(),
                    iolist.Homerun.ToString(), iolist.Balls.ToString(),
                    iolist.Dball.ToString(),iolist.Sout.ToString(),iolist.Out.ToString()
                     }));
            }

        }

        //연산으로 이동버튼
        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;

            textBox11.Text = textBox4.Text;
            textBox12.Text = textBox5.Text;
            textBox13.Text = textBox6.Text;
            textBox14.Text = textBox7.Text;
            textBox15.Text = textBox8.Text;
            textBox16.Text = textBox9.Text;
            textBox17.Text = textBox10.Text;
        }


        #endregion

        #region 연산

        private void button4_Click(object sender, EventArgs e)
        {
            string pid = textBox11.Text;
            try
            {
                if(comboBox4.SelectedIndex==1)
                {
                    PlayerManager.Singleton.Update(pid, 1);
                }
                else if (comboBox4.SelectedIndex == 2)
                {
                    PlayerManager.Singleton.Update(pid, 2);
                }
                else if (comboBox4.SelectedIndex == 3)
                {
                    PlayerManager.Singleton.Update(pid, 3);
                }
                else if (comboBox4.SelectedIndex == 4)
                {
                    PlayerManager.Singleton.Update(pid, 4);
                }
                else if (comboBox4.SelectedIndex == 5)
                {
                    PlayerManager.Singleton.Update(pid, 5);
                }
                else if (comboBox4.SelectedIndex == 6)
                {
                    PlayerManager.Singleton.Update(pid, 6);
                }
                else if (comboBox4.SelectedIndex == 7)
                {
                    PlayerManager.Singleton.Update(pid, 7);
                }
                else if (comboBox4.SelectedIndex == 8)
                {
                    PlayerManager.Singleton.Update(pid, 8);
                }

                string accid = textBox11.Text;
                Hitter hit = PlayerManager.Singleton.IdToAccount(accid);

                //오른쪽에 출력
                AccInfoBottomPrint2(hit.Plist);
                AccInfoTopPrint2(hit);
            }
            catch(Exception ex)
            {
                MessageBox.Show("타석 결과 추가 에러 : " + ex.Message);
            }
        }

        //리스트뷰에 출력
        private void AccInfoBottomPrint2(List<PlayerIOList> plist)
        {
            listView2.Items.Clear();

            foreach (PlayerIOList iolist in plist)
            {
                listView2.Items.Add(new ListViewItem(new string[] {
                    iolist.Hit1.ToString(), iolist.Hit2.ToString(), iolist.Hit3.ToString(),
                    iolist.Homerun.ToString(), iolist.Balls.ToString(),
                    iolist.Dball.ToString(),iolist.Sout.ToString(),iolist.Out.ToString()
                     }));
            }

        }

        //정보출력
        private void AccInfoTopPrint2(Hitter hit)
        {
            textBox11.Text = hit.Id;
            textBox12.Text = hit.Name;
            textBox15.Text = hit.Play.ToString();
            textBox16.Text = hit.Count.ToString();
            textBox17.Text = hit.Average.ToString();

            #region 포지션
            if (hit.Potype.ToString() == "SACKER1")
            {
                textBox13.Text = "1루수";
            }
            else if (hit.Potype.ToString() == "SACKER2")
            {
                textBox13.Text = "2루수";
            }
            else if (hit.Potype.ToString() == "SACKER3")
            {
                textBox13.Text = "3루수";
            }
            else if (hit.Potype.ToString() == "SHORTSTOP")
            {
                textBox13.Text = "유격수";
            }
            else if (hit.Potype.ToString() == "LEFT")
            {
                textBox13.Text = "좌익수";
            }
            else if (hit.Potype.ToString() == "MID")
            {
                textBox13.Text = "중견수";
            }
            else if (hit.Potype.ToString() == "RIGHT")
            {
                textBox13.Text = "우익수";
            }
            else if (hit.Potype.ToString() == "CATCHER")
            {
                textBox13.Text = "포수";
            }
            #endregion

            #region 타석
            if (hit.Battype.ToString() == "LEFTHITTER")
            {
                textBox14.Text = "좌타자";
            }
            else if (hit.Battype.ToString() == " RIGHTHITTER")
            {
                textBox14.Text = "우타자";
            }
            else if (hit.Battype.ToString() == "SWITCHHITTER")
            {
                textBox14.Text = "스위치타자";
            }

            #endregion
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region 시뮬레이션

        //시뮬레이션
        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            listView3.Items.Clear();

            textBox18.Text = textBox4.Text;
            textBox19.Text = textBox5.Text;
            textBox20.Text = textBox6.Text;
            textBox21.Text = textBox7.Text;
            textBox22.Text = textBox8.Text;
            textBox23.Text = textBox9.Text;
            textBox24.Text = textBox10.Text;
        }

        //시뮬레이션 실행버튼
        private void button7_Click(object sender, EventArgs e)
        {
            string pid = textBox18.Text;
            int count = int.Parse(textBox25.Text);
            int number;

            Random r = new Random();

            for(int i=0; i<count; i++)
            {
                number = r.Next(0,9);
                PlayerManager.Singleton.Update(pid, number);
            }

            string accid = textBox18.Text;
            Hitter hit = PlayerManager.Singleton.IdToAccount(accid);

            AccInfoTopPrint3(hit);
            AccInfoBottomPrint3(hit.Plist);

        }
        
        //좌측 정보출력
        private void AccInfoTopPrint3(Hitter hit)
        {
            textBox18.Text = hit.Id;
            textBox19.Text = hit.Name;
            textBox22.Text = hit.Play.ToString();
            textBox23.Text = hit.Count.ToString();
            textBox24.Text = hit.Average.ToString();

            #region 포지션
            if (hit.Potype.ToString() == "SACKER1")
            {
                textBox20.Text = "1루수";
            }
            else if (hit.Potype.ToString() == "SACKER2")
            {
                textBox20.Text = "2루수";
            }
            else if (hit.Potype.ToString() == "SACKER3")
            {
                textBox20.Text = "3루수";
            }
            else if (hit.Potype.ToString() == "SHORTSTOP")
            {
                textBox20.Text = "유격수";
            }
            else if (hit.Potype.ToString() == "LEFT")
            {
                textBox20.Text = "좌익수";
            }
            else if (hit.Potype.ToString() == "MID")
            {
                textBox20.Text = "중견수";
            }
            else if (hit.Potype.ToString() == "RIGHT")
            {
                textBox20.Text = "우익수";
            }
            else if (hit.Potype.ToString() == "CATCHER")
            {
                textBox20.Text = "포수";
            }
            #endregion

            #region 타석
            if (hit.Battype.ToString() == "LEFTHITTER")
            {
                textBox21.Text = "좌타자";
            }
            else if (hit.Battype.ToString() == " RIGHTHITTER")
            {
                textBox21.Text = "우타자";
            }
            else if (hit.Battype.ToString() == "SWITCHHITTER")
            {
                textBox21.Text = "스위치타자";
            }

            #endregion
        }

        private void AccInfoBottomPrint3(List<PlayerIOList> plist)
        {
            listView3.Items.Clear();

            foreach (PlayerIOList iolist in plist)
            {
                listView3.Items.Add(new ListViewItem(new string[] {
                    iolist.Hit1.ToString(), iolist.Hit2.ToString(), iolist.Hit3.ToString(),
                    iolist.Homerun.ToString(), iolist.Balls.ToString(),
                    iolist.Dball.ToString(),iolist.Sout.ToString(),iolist.Out.ToString()
                     }));
            }

        }
        #endregion


    }
}
