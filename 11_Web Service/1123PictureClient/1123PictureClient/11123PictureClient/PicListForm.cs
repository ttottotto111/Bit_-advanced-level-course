using _11123PictureClient.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _11123PictureClient
{
    public partial class PicListForm : Form
    {
        // PictureService 객체를 하나 생성
        PictureService pic = new PictureService();

        public string SelectedPic
        {
            get
            {
                return listBox1.SelectedItem.ToString();
            }
        }

        public PicListForm()
        {
            InitializeComponent();

            // 이미지 파일의 목록을 가져오는 메소드를 호출해서 문자열 배열에 저장한다.
            string[] strPicList = pic.GetPictureList();

            //바인딩코드
            listBox1.DataSource = strPicList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
