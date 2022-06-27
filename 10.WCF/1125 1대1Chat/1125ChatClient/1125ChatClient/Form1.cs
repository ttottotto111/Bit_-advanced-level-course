using _1125ChatClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1125ChatClient
{
    public partial class Form1 : Form, IChatCallback
    {
        private string idx;
        private IChat chat;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //2 ===================================================
            InstanceContext site = new InstanceContext(this);
            chat = new _1125ChatClient.ServiceReference1.ChatClient(site);

        }

        #region IChatCallback 인터페이스 함수 생성
        public void Receive(string idx, string message)
        {
            string msgtemp = string.Format("{0}", message);
            listBox1.Items.Add(msgtemp);
        }

        public void UserEnter(string idx)
        {
            string msgtemp = string.Format("{0}님이 로그인하셨습니다.", idx);
            listBox1.Items.Add(msgtemp);
        }
        #endregion


        //로그인
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (button1.Text == "로그인")
                {
                    Connect();
                }
                else
                    DisConnect();
            }
            else
            {
                MessageBox.Show("아이디를 입력하세요.");
            }
        }

        #region 로그인/로그아웃 핸들러

        private void Connect()
        {
            try
            {
                idx = textBox1.Text.ToString();

                //서버 접속
                if (chat.Join(idx))
                {
                    MessageBox.Show("접속 성공");
                }
                else
                    MessageBox.Show("접속 실패");



                button1.Text = "로그아웃";
                string login = string.Format("{0}님이 로그인하셨습니다.", textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("접속 오류 :{0}", ex.Message);
            }
        }

        private void DisConnect()
        {
            try
            {
                chat.Leave(idx);
                button1.Text = "로그인";

                string logout = string.Format("{0}님이 로그아웃하셨습니다.", textBox1.Text);
                listBox1.Items.Add(logout);
            }
            catch (Exception ex)
            {
                MessageBox.Show("나가기 오류 :{0}", ex.Message);
            }
        }
        #endregion

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("로그아웃"))
            {
                string msg = textBox2.Text;

                string temp = string.Format("[{0}]", msg);

                chat.Say(idx, msg);

                textBox2.Clear();
            }
            else
                MessageBox.Show("로그인을 하시오");
        }
    }
}
