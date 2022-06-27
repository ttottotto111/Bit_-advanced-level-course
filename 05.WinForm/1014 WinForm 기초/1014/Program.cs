using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1014
{
    class Program //: Form
    {
        //public Program(string strText)
        //{
        //    //프로퍼티 초기화
        //    this.Text = strText;

        //    //이벤트 등록
        //    this.Load += new System.EventHandler(this.Form_Load);
        //    this.FormClosed += new FormClosedEventHandler(this.Form_Closed);
        //    this.FormClosing += new FormClosingEventHandler(this.Form_Closing);
        //    this.Show();
        //}

        //#region 핸들러

        //public void Form_Load(object obj, EventArgs e)
        //{
        //    DialogResult r;
        //    r = MessageBox.Show("Form_Load", "알림", 
        //            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        //    if(r == DialogResult.OK)
        //    {

        //    }
        //}

        //public void Form_Closed(object obj, FormClosedEventArgs e)
        //{
            
        //}

        //public void Form_Closing(object obj, FormClosingEventArgs e)
        //{
        //    DialogResult r;
        //    r = MessageBox.Show("종료하시겠습니까?", "알림",
        //            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
        //    if (r == DialogResult.OK)
        //    {
        //        e.Cancel = false;
        //    }
        // else
        //    {
        //        e.Cancel = true;
        //    }
        //}

        //#endregion

        static void Main(string[] args)
        {
            //Application.Run(new Program("상속받아 구현된 윈도우"));
            Application.Run(new TestNewWinForm("상속받아 구현된 윈도우"));
        }
    }
}
