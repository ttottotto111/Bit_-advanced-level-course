using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1019DC실습
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 도형 그리기
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //컨트롤에 전달 : 저장
                ShapeControl.Singleton.ShapeInsert(this, e.X, e.Y);

                //화면 출력 요청
                Invalidate();
            }
        }

        //무효화 처리 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //컨트롤에 출력 요청
            ShapeControl.Singleton.ShapePrintAll(e.Graphics); 
        }

        //키보드 입력 처리
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {   
            ShapeControl.Singleton.ShapeSizeUpdate(e.KeyCode);
        }       

        private void 프로그램종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //R, G, B 메뉴에 대한 공통 핸들러
        private void 빨강RToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (빨강RToolStripMenuItem == sender || 빨강RToolStripMenuItem1 == sender)
            {
                ShapeControl.Singleton.PenColorUpdate(Color.FromArgb(255, 0, 0));
                toolStripStatusLabel1.Text = "빨강";
            }
            else if(파랑BToolStripMenuItem == sender || 파랑BToolStripMenuItem1 == sender)
            {
                ShapeControl.Singleton.PenColorUpdate(Color.FromArgb(0, 0, 255));
                toolStripStatusLabel1.Text = "파랑";
            }
            else if(녹색GToolStripMenuItem == sender || 녹색GToolStripMenuItem1 == sender)
            {
                ShapeControl.Singleton.PenColorUpdate(Color.FromArgb(0, 255, 0));
                toolStripStatusLabel1.Text = "녹색";
            }                
        }

        //메뉴 상태 처리 핸들러
        private void menuStrip1_MenuActivate(object sender, EventArgs e)
        {
            //빨간색ToolStripMenuItem.Checked = (InColor == Color.Red);
            //파란색ToolStripMenuItem.Checked = (InColor == Color.Blue);
            Color c = ShapeControl.Singleton.CurShape.PenColor;
            빨강RToolStripMenuItem.Enabled = (c != Color.FromArgb(255,0,0));
            파랑BToolStripMenuItem.Enabled = (c != Color.FromArgb(0, 0, 255));
            녹색GToolStripMenuItem.Enabled = (c != Color.FromArgb(0, 255, 0));
        }

        //컨텍스트 메뉴 상태 처리 핸들러
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            Color c = ShapeControl.Singleton.CurShape.PenColor;
            빨강RToolStripMenuItem1.Checked = (c == Color.FromArgb(255, 0, 0));
            파랑BToolStripMenuItem1.Checked = (c == Color.FromArgb(0, 0, 255));
            녹색GToolStripMenuItem1.Checked = (c == Color.FromArgb(0, 255, 0));
        }

        //색상 선택...
        private void 색상선택SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //공통다이얼로그 -Modal
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ShapeControl.Singleton.PenColorUpdate(dlg.Color);
                toolStripStatusLabel1.Text = dlg.Color.ToString();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ShapeControl.Singleton.PenColorUpdate(Color.FromArgb(255, 0, 0));
        }
    }
}
