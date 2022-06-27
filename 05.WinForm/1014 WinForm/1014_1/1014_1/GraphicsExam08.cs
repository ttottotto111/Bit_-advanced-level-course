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
    public partial class GraphicsExam08 : Form
    {
        Point[] point1 = new Point[5];
        Point[] point2 = new Point[3];
        public GraphicsExam08()
        {
            this.Text = "다각형과 타원 그리기";
            this.Size = new Size(300, 400);
            point1[0] = new Point(10, 20);
            point1[1] = new Point(20, 70);
            point1[2] = new Point(50, 100);
            point1[3] = new Point(10, 150);
            point1[4] = new Point(100, 100);
            point2[0] = new Point(100, 10);
            point2[1] = new Point(10, 100);
            point2[2] = new Point(190, 100);

        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            Pen pen = new Pen(Color.Red, 2);// 빨간색2의 두께를 갖는 선으로
            g.DrawPolygon(pen, point1);// 5개 점을 경유하는 다각형 그림

            pen = new Pen(Color.Blue, 3);// 파랑색 3의 두께를 갖는 선으로
            g.DrawPolygon(pen, point2); // 3개의 점을 경유하는 다각형

            pen = new Pen(Color.Black, 1);// 두께 1의 검은색 선으로
            for (int i = 0; i < 200; i += 20) // 9개의 타원을 그림
            {
                g.DrawEllipse(pen, 70, 130, i, i + 50);
            }
        }
    }
}
