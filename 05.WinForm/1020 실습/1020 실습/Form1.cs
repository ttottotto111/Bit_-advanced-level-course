using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _1020_실습
{
    public partial class Form1 : Form
    {
        private PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter ram = new PerformanceCounter("Memory", "Available MBytes");

        double x;
        double y;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text="Start";
            timer1.Tick += timer1_Tick;
            timer2.Tick += timer2_Tick;
            timer1.Interval = 500;
            timer2.Interval = 500;

            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart2.Series[0].ChartType = SeriesChartType.Line;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int itotalmem = 0; //총메모리
            int itotalMemMB = 0; // 총 메모리 MB단위
            int ifreeMem = 0; // 사용가능 메모리KB단위
            int ifreeMemMB = 0; // 사용가능 메모리 MB단위

            ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
            ManagementObjectCollection moc = cls.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                itotalmem = int.Parse(mo["TotalVisibleMemorySize"].ToString());
                ifreeMem = int.Parse(mo["FreePhysicalMemory"].ToString());
            }
            itotalMemMB = itotalmem / 1024;
            ifreeMemMB = ifreeMem / 1024;
            int iuseMemMb = (itotalmem - ifreeMem);
            int ipu = (int)cpu.NextValue();
            label6.Text = itotalMemMB.ToString();
            label7.Text = iuseMemMb.ToString();
            label8.Text = ifreeMem.ToString();
            label10.Text = ipu + " %";

            chart1.Series[0].Points.AddXY(x, ram.NextValue());
            chart2.Series[0].Points.AddXY(x, ipu);

            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisY.Maximum = itotalMemMB;

            chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
            chart2.ChartAreas[0].AxisY.Maximum = 100;

            x += 1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                timer1.Stop();
                timer2.Stop();
                button1.Text = "Start";
            }
            else
            {
                timer1.Start();
                timer2.Start();
                button1.Text = "Stop";
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
            timer2.Stop();
            timer2.Dispose();
        }

        
    }
}
