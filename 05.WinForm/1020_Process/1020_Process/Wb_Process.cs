using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1020_Process
{
    class WbProcessData
    {
        public string ProcessName { get; set; }
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public long PrivateMemorySize64 { get; set; }
        public int ThreadsCount { get; set; }
        public string OwnerName { get; set; }
        public long WorkingSet64 { get; set; }
        public ProcessPriorityClass PriorityClass { get; set; }
        public TimeSpan UserProcessorTime { get; set; }
        public string State { get; set; }

         public WbProcessData(string pname, int id, DateTime st, long psize, int tcount, 
            string oname, long wset, ProcessPriorityClass pclass, TimeSpan stime, string state )
        {
            ProcessName = pname;
            Id = id;
            StartTime = st;
            PrivateMemorySize64 = psize;
            ThreadsCount = tcount;
            OwnerName = oname;
            WorkingSet64 = wset;
            PriorityClass = pclass;
            UserProcessorTime = stime;
            State = state;
        }

        //Priority 제외
        public WbProcessData(string pname, int id, DateTime st, long psize, int tcount,
            string oname, long wset, TimeSpan stime, string state)
        {
            ProcessName = pname;
            Id = id;
            StartTime = st;
            PrivateMemorySize64 = psize;
            ThreadsCount = tcount;
            OwnerName = oname;
            WorkingSet64 = wset;            
            UserProcessorTime = stime;
            State = state;
        }
    }
    
    class Wb_Process
    {
        #region 싱글톤        //1. 생성자 은닉
        private Wb_Process()        {                }
        //2. 프로퍼티 선언
        static public Wb_Process Singleton { get; private set; }
        //3. static 생성자에서 객체 생성(단 한번 호출되는 문장)
        static Wb_Process()        {            Singleton = new Wb_Process();        }        #endregion

        private List<WbProcessData> plist = new List<WbProcessData>();

        //프로세스ID -> Process객체 획득
        public Process GetProcessById(int pid)
        {
            Process p = Process.GetProcessById(pid);
            return p;
        }

        #region 프로세스 열거
        public List<WbProcessData> FinalProcessEnum(out int pcount)
        {
            try
            {
                //0. List 전체 데이터 삭제
                plist.Clear();

                Process[] processlist = Process.GetProcesses();

                //1. 실행중인 프로세스 개수
                pcount = processlist.Length;
                
                for (int i = 0; i < processlist.Length; i++)
                {
                    Process theprocess = processlist[i];
                    _WriteProcessInfo(i, theprocess);
                }
                return plist;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                pcount = -1;
                return null;
            }
        }
        //System.Management.dll 참조추가
        //using System.Management;
        private string _GetProcessOwner(int pid)
        {
            try
            {
                string query = "SELECT * FROM WIN32_PROCESS WHERE ProcessID = " + pid;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection processList = searcher.Get();

                foreach (ManagementObject obj in processList)
                {
                    string[] argList = new string[] { string.Empty, string.Empty };
                    int retVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                    return argList[0];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
        private void _WriteProcessInfo(int i, Process processInfo)
        {
            try
            {
                if (processInfo.MachineName != "SYSTEM" || processInfo.MachineName != "LOCAL SERVICE")
                {
                    //객체 생성
                    WbProcessData pdata = new WbProcessData(
                        processInfo.ProcessName, processInfo.Id, processInfo.StartTime,
                        processInfo.PrivateMemorySize64, processInfo.Threads.Count,
                        "", processInfo.WorkingSet64,
                        //_GetProcessOwner(processInfo.Id), processInfo.WorkingSet64,
                        processInfo.UserProcessorTime, "실행중");
                    //저장
                    plist.Add(pdata);
                    //Console.WriteLine("{0}", );//processor time 
                    //if (processInfo.Responding)
                    //{
                    //    Console.WriteLine("실행중");// Status:  Responding to user interface");
                    //    processInfo.Refresh();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("응답없음");// Status:  Not Responding");
                    //}
                }
            }
            catch(Exception)
            {
                //MessageBox.Show("프로세스 열거 에러 : " + e.Message);
            }
        }

        #endregion

        #region 프로세스 실행 및 종료 
        public void CreateProcess(string pname)
        {
            Process.Start(pname);
        }

       
        public void ExitProcess(Process pr)
        {
            pr.Kill();
        }

        #endregion
    }
}
