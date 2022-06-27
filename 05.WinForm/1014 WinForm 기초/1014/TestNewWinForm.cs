using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1014
{
    /// <summary>
    /// 직접 코드를 작성 
    /// </summary>
    partial class TestNewWinForm : Form
    {
        //생성자
        public TestNewWinForm(string txt)
        {
            DesignCode(txt);
        }

        #region 이벤트 핸들러
        private void Form_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Console.WriteLine("MouseMove 이벤트 발생!!!");
            Console.WriteLine("(x,y)=({0},{1})", e.X, e.Y);
        }

        private void Form_Closed(object sender, System.EventArgs e)
        {
            Console.WriteLine("윈도우가 Closed 됩니다.");
        }
        #endregion 
    }
}
