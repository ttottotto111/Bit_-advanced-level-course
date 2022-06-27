using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1020_Process
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintProcessList();
            timer1.Start();            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        //이름\tPID\t시작시간\t\t메모리\t스레드 갯수\t사용자이름\t메모리사용량\t우선순위\tcpu\t상태";
        //Timer를 통해 1초에 한번씩 갱신....
        private void PrintProcessList()
        {
            listView1.Items.Clear();

            int count;
            List<WbProcessData> plist = Wb_Process.Singleton.FinalProcessEnum(out count);
            //리스트뷰에 출력
            foreach (WbProcessData pdata in plist)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                    pdata.ProcessName, pdata.Id.ToString(), pdata.StartTime.ToString(),
                    pdata.PrivateMemorySize64.ToString(),
                    pdata.ThreadsCount.ToString(), pdata.OwnerName,
                    pdata.WorkingSet64.ToString(),pdata.UserProcessorTime.ToString(),
                    pdata.State
                     }));
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            PrintProcessList();
        }

        private void 새작업실행NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //모달
            Form2 dlg = new Form2();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Wb_Process.Singleton.CreateProcess(dlg.ProcessName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("에러 : " + ex.Message);
                }
            }
            dlg.Dispose();
        }

        private void 끝내기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        

        //리스트뷰 선택 정보 갱신      

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        //작업끝내기

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다.");
            }
            else
            {
                ListView.SelectedListViewItemCollection select = listView1.SelectedItems;
                int pid = int.Parse(select[0].SubItems[1].Text);
                Process pr = Wb_Process.Singleton.GetProcessById(pid);
                Wb_Process.Singleton.ExitProcess(pr);
            }
            timer1.Start();
        }
    }
}
