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
    public partial class GraphicsExam01 : Form
    {
        public GraphicsExam01()
        {
            this.Text = "Graphics 개체 얻기1";
            // paint 이벤트 핸들러 등록
            this.Paint += new PaintEventHandler(GDIExam_Paint);
        }

        private void GDIExam_Paint(object sender, PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            grfx.FillRectangle(new SolidBrush(Color.Black), this.ClientRectangle);
        }

    }
}
