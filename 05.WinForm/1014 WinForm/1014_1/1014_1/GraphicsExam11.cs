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
    public partial class GraphicsExam11 : Form
    {
        public GraphicsExam11()
        {
            this.Text = "얼굴 그리기";
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            g.DrawArc(Pens.Black, 70, 20, 130, 180, 180, -180); // 아랫턱 그리기
            for (int i = 0; i < 15; i++)
            {
                // 머리카락그리기
                g.DrawArc(Pens.Brown, 50 + 2 * i, 50, 100, 160, 130, 80);
                g.DrawArc(Pens.Brown, 20 + 2 * i, 50, 250, 160, 140, 100);
                g.DrawArc(Pens.Brown, 90 + 2 * i, 50, 100, 160, 200, 260);
                g.DrawArc(Pens.Brown, 80 + 3 * i, 50, 100, 90, 130, 80);
            }
            g.DrawEllipse(Pens.Black, 90, 120, 20, 25);
            // 눈
            g.DrawEllipse(Pens.Black, 155, 120, 20, 25);    // 눈
            g.FillEllipse(Brushes.Blue, 93, 130, 15, 15);   // 눈동자
            g.FillEllipse(Brushes.Blue, 158, 130, 15, 15);  // 눈동자
            g.DrawArc(Pens.Black, 110, 150, 50, 40, 0, 180);
        }

    }
}
