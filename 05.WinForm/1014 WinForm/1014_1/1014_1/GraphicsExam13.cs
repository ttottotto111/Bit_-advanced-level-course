using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1014_1
{
    public partial class GraphicsExam13 : Form
    {
        int signal = 0;
        string[] str = new string[3] { "빨강", "노랑", "녹색" };

        public GraphicsExam13()
        {
            this.Text = "신호등 예제";
            this.Size = new Size(150, 400);
            Timer time = new Timer();// timer객체 생성, 메서드 호출
            time.Interval = 1000;
            time.Enabled = true;
            time.Tick += new EventHandler(time_Tick);
        }

        // 1초에 한번씩 호출
        private void time_Tick(object sender, EventArgs ea)
        {
            Random rnd = new Random();
            signal = rnd.Next(3); // 난수 발생
            Console.WriteLine(str[signal] + " 발생");
            // 특정 영역 갱신
            this.Invalidate(new Rectangle(10, 10, 120, 350));
            // this.Invalidate(); // 화면 전체 갱신
            this.Update();
        }
        // 신호등 외곽선 그리기
        private void DrawOutLine(Graphics g)
        {
            Pen pen = new Pen(Color.White, 3);
            g.FillRectangle(Brushes.Black, 10, 10, 120, 350);
            g.DrawEllipse(pen, 20, 20, 100, 100); //빨강 테두리 그리기
            g.DrawEllipse(pen, 20, 130, 100, 100); // 노랑 테두리 그리기
            g.DrawEllipse(pen, 20, 240, 100, 100); // 녹색 테두리 그리기
        }
        protected override void OnPaint(PaintEventArgs pea)
        {
            Console.WriteLine("Invalidate 영역 = " + pea.ClipRectangle);
            Graphics g = pea.Graphics;
            DrawOutLine(g); // 신호등 외곽선 그리기
            switch (signal)
            {
                case 0: // red
                    g.FillEllipse(Brushes.Red, 20, 20, 100, 100);
                    break;
                case 1: // yellow
                    g.FillEllipse(Brushes.Yellow, 20, 130, 100, 100);
                    break;
                case 2: // green
                    g.FillEllipse(Brushes.Green, 20, 240, 100, 100);
                    break;
            }
        }
    }
}
