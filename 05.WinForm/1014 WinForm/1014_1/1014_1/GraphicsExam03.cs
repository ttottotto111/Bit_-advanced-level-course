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
    public partial class GraphicsExam03 : Form
    {
        Button btn = null;
        public GraphicsExam03()
        {
            this.Text = "Graphics 개체 얻기3";
            btn = new Button();
            btn.Text = "버튼위에 GDI+ 출력";
            btn.SetBounds(10, 10, 200, 100);
            btn.Click += new EventHandler(btn_Click);
            this.Controls.Add(btn);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Graphics grfx = btn.CreateGraphics();
            grfx.FillRectangle(new SolidBrush(Color.Purple), btn.ClientRectangle);
            grfx.Dispose();
            // Dispose()시키지 않으면 해당 개체의 Graphics 리소스가 회수되지 않기
            // 때문에 시스템에 문제를 일으킬 수 있슴
            // 아래 구문이 더 깔끔함
            // using(Graphics grfx = btn.CreateGraphics())
            // {
            // grfx.FillRectangle(new SolidBrush(Color.Blue), this.ClientRectangle);
            // }
        }
    }
}
