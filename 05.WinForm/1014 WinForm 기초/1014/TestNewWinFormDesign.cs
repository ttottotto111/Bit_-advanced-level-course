using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1014
{
    /// <summary>
    /// 디자이너가(개발툴) 알아서 코드를 자동으로 작성....
    /// </summary>
    partial class TestNewWinForm
    {
        public void DesignCode(string strText)
        {
            this.Text = strText;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.Closed += new System.EventHandler(this.Form_Closed);
            this.Show();
        }
    }
}
