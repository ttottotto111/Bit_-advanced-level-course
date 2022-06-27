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
    public partial class ColorForm : Form
    {
        public string StrText { get; set; }

        public ColorForm(string str)
        {
            InitializeComponent();
            StrText = str;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //DC :API BeginPaint로 만들어진 DB
            Graphics grfx = e.Graphics;
            SolidBrush br = new SolidBrush(Color.Red);
            grfx.DrawString(StrText, Font, br, 10, 7);
        }
    }
}
