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
    public partial class GraphicsExam06 : Form
    {
        Button btn1 = null;
        Button btn2 = null;

        public GraphicsExam06()
        {
            this.Text = "Graphics 개체 얻기7";
            btn1 = new Button();
            btn1.Text = "Graphics.FromHwnd 이용";
            btn1.SetBounds(10, 10, 200, 100);
            btn1.Click += new EventHandler(btn_Click);

            btn2 = new Button();
            btn2.Text = "Graphics.FromHdc 이용";
            btn2.SetBounds(10, 130, 200, 100);
            btn2.Click += new EventHandler(btn_Click);

            this.Controls.Add(btn1);
            this.Controls.Add(btn2);

        }

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool Ellipse(
        IntPtr hdc, // handle to DC
        int nLeftRect, // x-coord of upper-left corner of rectangle
        int nTopRect, // y-coord of upper-left corner of rectangle
        int nRightRect, // x-coord of lower-right corner of rectangle
        int nBottomRect // y-coord of lower-right corner of rectangle
        );
        public void btn_Click(object sender, EventArgs e)
        {
            if ((Button)sender == btn1)
            {
                IntPtr hwnd = new IntPtr();
                hwnd = this.Handle;
                Graphics grfx = Graphics.FromHwnd(hwnd);
                grfx.FillRectangle(Brushes.Black, this.ClientRectangle);
                grfx.Dispose();
                hwnd = btn1.Handle;
                grfx = Graphics.FromHwnd(hwnd);
                grfx.DrawRectangle(new Pen(Color.Pink, 5), 10, 10, 180, 80);
                grfx.Dispose();
            }
            else
            {
                IntPtr hwnd = new IntPtr();
                hwnd = this.Handle;
                Graphics grfx = Graphics.FromHwnd(hwnd);
                grfx.FillRectangle(Brushes.Purple, this.ClientRectangle);

                Graphics g = this.btn2.CreateGraphics();
                g.DrawEllipse(Pens.Blue, 10, 10, 100, 70);
                IntPtr hdc = new IntPtr();
                hdc = g.GetHdc(); //API 함수를 사용하기위해 얻어냄
                Ellipse(hdc, 100, 10, 50, 50);
                Graphics new_g = Graphics.FromHdc(hdc);
                new_g.DrawRectangle(new Pen(Color.Blue, 5), 10, 10, 180, 80);
                g.ReleaseHdc(hdc);
                g.Dispose();
            }
        }
    }
}
