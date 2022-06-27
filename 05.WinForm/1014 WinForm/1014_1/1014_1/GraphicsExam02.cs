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
    public partial class GraphicsExam02 : Form
    {
        public GraphicsExam02()
        {
            this.Text = "Graphics 개체 얻기2";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics grfx = e.Graphics;
            grfx.FillRectangle(new SolidBrush(Color.Yellow), this.ClientRectangle);
        }
    }
}
