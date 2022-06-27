using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using _1125UseCalculator.ServiceReference1;
using _1125UseCalculator.ServiceReference2;
using System.IO;

namespace _1125UseCalculator
{
    public partial class Form1 : Form, IChatCallback, IFileCallback
    {
        //IChat관련 ===============================
        private ChatClient proxy;
        public string NickName { get; set; }


        //IFile관련 ===============================
        private FileClient fileproxy;
        public Stream ReadStream { get; set; }

        public Form1()
        {
            InitializeComponent();

            //이중계약 계약 객체 생성
            proxy       = new ChatClient(new InstanceContext(this));
            fileproxy   = new FileClient(new InstanceContext(this));
            fileproxy.Join();   //?????????????????????
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

        #region IFileCallback 서비스에 의해 호출되는 콜백 함수
        public void SendFile(string strFileName, byte[] bytePic)
        {
            this.Text = "파일 수신 시작 : " + strFileName;
            WbFile.FileSave(strFileName, bytePic);
            this.Text = "파일 수신 종료 : " + strFileName;
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
                    NickName = "무명";


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

        //찾기버튼
        private void button4_Click(object sender, EventArgs e)
        {
            // 파일열기	대화상자를 생성
            OpenFileDialog dlg = new OpenFileDialog();

            // 확장자를 제한한다.
            dlg.Filter = "전체파일 (*.*)|*.*";
            dlg.RestoreDirectory = true;    // 현재 디렉토리를 저장해놓는다.

            // OK 버튼을 누르면
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if ((ReadStream = dlg.OpenFile()) != null)
                {
                    FileInfo fi = new FileInfo(dlg.FileName);                    
                    textBox3.Text = fi.FullName;
                    textBox4.Text = fi.Name;
                }
            }
        }

        //전송버튼
        private void button5_Click(object sender, EventArgs e)
        {
            byte[] bytePic;
            BinaryReader picReader = new BinaryReader(ReadStream);
            bytePic = picReader.ReadBytes(Convert.ToInt32(ReadStream.Length));

            // 업로드 서비스 요청            
            if (fileproxy.UploadFile(textBox4.Text, bytePic))
            {
                this.Text = "업로드 성공 : " + textBox4.Text;
                //MessageBox.Show("업로드 성공");
            }
            else
            {
                MessageBox.Show("업로드 실패");
            }
            ReadStream.Close();
        }

        
    }
}
