using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using _1125UseCalculator.ServiceReference2;

namespace _1125UseCalculator
{
    public partial class Form1 : Form, IChatCallback
    {
        private ChatClient proxy;
        public string NickName { get; set; }

        public Form1()
        {
            InitializeComponent();

            //이중계약 계약 객체 생성
            proxy = new ChatClient(new InstanceContext(this));
        }

        #region 서비스에 의해 호출되는 콜백 함수들                     

        public void Receive(string idx, string message)
        {
            string msg = string.Format("[{0}] {1}", idx, message);
            listBox1.Items.Add(msg);
        }        

        public void UserEnter(string idx)
        {
            string msg = string.Format("{0}님이 대화에 참여하셨습니다.", idx);
            listBox1.Items.Add(msg);
        }

        public void UserLeave(string idx)
        {
            string msg = string.Format("{0}님이 대화방에서 나가셨습니다.", idx);
            listBox1.Items.Add(msg);
        }

        #endregion

              

        #region 버튼 핸들러
        //대화참여
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NickName = textBox1.Text;
                if (NickName == "")
                {
                    MessageBox.Show("ID를 입력하세요");
                    return;
                }

                //서버 접속
                if (proxy.Join(NickName) == false)
                    new Exception("연결 오류");
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 :{0}", ex.Message);
            }
        }

        //나가기
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                proxy.Leave(NickName);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 :{0}", ex.Message);
            }
        }

        //메시지 전송
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string msg = textBox2.Text;

                proxy.Say(NickName, msg);

                textBox2.Text = "";
            }
            catch(Exception )
            {
                MessageBox.Show("먼저 대화에 참여하세요");
            }
        }
        #endregion 
    }
}
