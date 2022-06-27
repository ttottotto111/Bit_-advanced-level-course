using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _1124WCFPictureClient.ServiceReference1;          //<==========
using System.IO;

namespace _1124WCFPictureClient
{
    public partial class Form1 : Form
    {
        private PictureClient pic = new PictureClient();    //<========

        private string SelectPic { get; set; }          //<===선택된 이미지파일명.

        // 이미지 파일을 출력하기 위한
        private Image picImage = null;                         //<===이미지객체 저장 

        private Stream readStream;                  //<== Upload stream

        public Form1()
        {
            InitializeComponent();
        }

        //리스트 가져오기
        private void button1_Click(object sender, EventArgs e)
        {
            // 이미지 파일의 목록을 가져오는 메소드를 호출해서 문자열 배열에 저장한다.
            string[] strPicList = pic.GetPictureList();

            //바인딩코드
            listBox1.DataSource = strPicList;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SelectPic = listBox1.SelectedItem.ToString();

            //가져오기
            picImage = Image.FromStream(new MemoryStream(pic.GetPicture(SelectPic)));

            // 1. 이미지 크기와 창크기를 맞춘다.
            //ClientSize = picImage.Size;

            //2. 타이틀바 출력
            Text = "<파일명 : " + SelectPic + "> PictureService에서 제공받은 그림파일을 보여주는 클라이언트";

            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (picImage == null)
            {
                return;
            }
            Graphics g = e.Graphics;

            // 이미지 파일을 화면에 그린다.
            //g.DrawImage(picImage, ClientRectangle);
            //pictureBox에 출력
            pictureBox1.Image = picImage;
        }

        //이미지 파일 불러오기 
        private void button2_Click(object sender, EventArgs e)
        {
            // 파일열기	대화상자를 생성
            OpenFileDialog dlg = new OpenFileDialog();

            // 확장자를 제한한다.
            dlg.Filter = "그림파일 (*.bmp;*.jpg;*.gif;*.jpeg;*.png;*.tiff)|*.bmp;*.jpg;*.gif;*.jpeg;*.png;*.tiff)";
            dlg.RestoreDirectory = true;    // 현재 디렉토리를 저장해놓는다.

            // OK 버튼을 누르면
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if ((readStream = dlg.OpenFile()) != null)
                {                    
                    FileInfo fi = new FileInfo(dlg.FileName);                    
                    textBox1.Text = fi.Name;
                    textBox2.Text = fi.FullName;                                      
                }
            }
        }

        //파일 업로드 
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] bytePic;
            BinaryReader picReader = new BinaryReader(readStream);
            bytePic = picReader.ReadBytes(Convert.ToInt32(readStream.Length));

            // 업로드 서비스 요청
            if (pic.UploadPicutre(textBox1.Text, bytePic))
            {
                MessageBox.Show("업로드 성공");
            }
            else
            {
                MessageBox.Show("업로드 실패");
            }
            readStream.Close();
        }
    }
}
