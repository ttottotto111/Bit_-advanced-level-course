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
    public partial class GraphicsExam07 : Form
    {
        public GraphicsExam07()
        {
            this.Text = "그래픽 그리기";
            this.Size = new Size(300, 300);
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            Pen pen = new Pen(Color.Black, 2);
            g.DrawLine(pen, 10, 10, 190, 190);
            g.DrawRectangle(pen, 10, 10, 100, 100);
            g.DrawEllipse(pen, 50, 50, 100, 100);
            g.DrawArc(pen, 100, 100, 80, 80, 0, -90);
        }

    }
}
