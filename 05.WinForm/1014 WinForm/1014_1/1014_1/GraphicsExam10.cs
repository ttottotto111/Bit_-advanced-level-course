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
    public partial class GraphicsExam10 : Form
    {
        public GraphicsExam10()
        {
            this.Text = "그라데이션 효과주기";
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics g = pea.Graphics;
            for (int i = 0; i < 256; i++)
            {
                // 색상을 바꿔가며, 좌측 상단에서 대각선 방향으로 선을 그림
                g.DrawLine(new Pen(Color.FromArgb(i, 0, 0)), 10, 10, 265 - i, 10 + i);
            }
        }
    }
}
