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
    public partial class ColorMainForm : Form
    {
        public ColorMainForm()
        {
            InitializeComponent();

            Array arr = System.Enum.GetValues(typeof(KnownColor));
            ColorForm[] frm = new ColorForm[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                frm[i] = new ColorForm(arr.GetValue(i).ToString());
                frm[i].StrText = arr.GetValue(i).ToString();
                frm[i].BackColor = Color.FromName(arr.GetValue(i).ToString());
                frm[i].SetBounds(0, 0, 200, 50);
                frm[i].MdiParent = this;
                frm[i].Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
