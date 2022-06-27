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
    public partial class GraphicsExam04 : Form
    {
        ListBox lstbox = null;

        public GraphicsExam04()
        {
            this.Text = "Graphics 개체 얻기4";
            lstbox = new ListBox();
            lstbox.SetBounds(10, 10, 200, 100);
            lstbox.Items.Add("사과");
            lstbox.Items.Add("포도");
            lstbox.Items.Add("수박");
            lstbox.Items.Add("참외");
            lstbox.Items.Add("복숭아");
            lstbox.DrawItem += new
            System.Windows.Forms.DrawItemEventHandler(GDIExam_DrawItem);
            lstbox.MeasureItem += new
            System.Windows.Forms.MeasureItemEventHandler(GDIExam_MeasureItem);
            this.Controls.Add(lstbox);
            this.Load += new EventHandler(GDIExam_Load);

        }
        private void GDIExam_Load(object sender, EventArgs e)
        {
            lstbox.DrawMode = DrawMode.OwnerDrawVariable;
            //lstbox.DrawMode = DrawMode.OwnerDrawFixed;
        }
        // 먼저 호출됨
        private void GDIExam_MeasureItem(object sender, MeasureItemEventArgs
        e)
        {
            Graphics g = e.Graphics;
            Console.WriteLine("{0} : MeasureItem 이벤트 실행", e.ToString());
        }

        // ListBox가 다시 그려질 때마다 호출됨(데이터 갯수만큼 호출됨)
        private void GDIExam_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush = Brushes.Black;
            switch (e.Index)
            {
                case 0:
                    brush = Brushes.Red;
                    break;
                case 1:
                    brush = Brushes.Violet;
                    break;
                case 2:
                    brush = Brushes.Green;
                    break;
                case 3:
                    brush = Brushes.Yellow;
                    break;
                case 4:
                    brush = Brushes.Pink;
                    break;
            }
            g.DrawString(lstbox.Items[e.Index].ToString(),
            e.Font, brush, e.Bounds, StringFormat.GenericDefault) ;
            Console.WriteLine("{0} : DrawItem 이벤트 실행", e.ToString());

        }
    }
}
