using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Management;

namespace WorkManagerFuncTest
{

    class Program
    {
        #region 프로세스 열거 : 프로세스전체개수, 프로세스이름, 프로세스ID, 프로세스메모리사용량,프로세스시작시간,스레드갯수,사용자이름

        private static void FinalProcessEnum()
        {
            try
            {
                Process[] processlist = Process.GetProcesses();

                Console.WriteLine("실행중인 프로세스 개수 : " + processlist.Length + "개");
                Console.WriteLine("인덱스  P이름\tPID\t시작시간\t\t메모리\t스레드 갯수\t사용자이름\t메모리사용량\t우선순위\tcpu\t상태");
                for (int i = 0; i < processlist.Length; i++)
                {
                    Process theprocess = processlist[i];
                    WriteProcessInfo1(i, theprocess);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static void WriteProcessInfo1(int i, Process processInfo)
        {
            if (processInfo.MachineName != "SYSTEM" || processInfo.MachineName != "LOCAL SERVICE")
            {
                Console.Write("[{0,3}]  ", i);
                Console.Write("{0}\t", processInfo.ProcessName);
                Console.Write("{0}\t", processInfo.Id);
                Console.Write("{0}\t", processInfo.StartTime);
                Console.Write("{0}\t", processInfo.PrivateMemorySize64);
                Console.Write("{0}\t", processInfo.Threads.Count);
                Console.Write("{0}\t", _GetProcessOwner(processInfo.Id));
                Console.Write("{0}", processInfo.WorkingSet64); //실메모리 사용량
                //Console.Write("{0}", processInfo.PriorityClass);
                Console.WriteLine("{0}", processInfo.UserProcessorTime);//processor time 
                                                                        //if (processInfo.Responding)
                                                                        //{
                                                                        //    Console.WriteLine("실행중");// Status:  Responding to use
            }
        }

        private static string _GetProcessOwner(int pid)
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

        //==============================================================================================================================
        //==============================================================================================================================


        //강건 : 프로세스이름 + 프로세스ID
        //https://stackoverflow.com/questions/648410/how-can-i-list-all-processes-running-in-windows
        private static void NewMethod()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
            }
        }

        //황동현 : 프로세스이름 + 프로세스ID
        private static void NewMethod1()
        {
            Process[] pr = Process.GetProcesses();
            foreach (Process p in pr)
            {
                Console.WriteLine("ID = {0}, 이름 = {1}", p.Id, p.ProcessName);
            }
        }

        //손을준 : 프로세스전체개수, 프로세스이름, 프로세스ID, 프로세스메모리사용량
        private static void NewMethod2()
        {
            try
            {
                Process[] allProc = Process.GetProcesses();    //시스템의 모든 프로세스 정보 출력
                int i = 1;
                Console.WriteLine("****** 모든 프로세스 정보 ******");
                Console.WriteLine("현재 실행중은 모든 프로세스 수 : {0}", allProc.Length);
                foreach (Process p in allProc)
                {
                    Console.WriteLine("***** {0}번째 프로세스 ******", i++);
                    WriteProcessInfo(p);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        private static void WriteProcessInfo(Process processInfo)
        {
            if (processInfo.MachineName != "SYSTEM" || processInfo.MachineName != "LOCAL SERVICE")
            {

                Console.WriteLine("Process : {0}", processInfo.ProcessName);

                // Console.WriteLine("시작시간 : {0}", processInfo.StartTime);

                Console.WriteLine("프로세스 PID : {0}", processInfo.Id);

                Console.WriteLine("메모리 : {0}", processInfo.PrivateMemorySize);
            }
        }

        //김민범(프로세스 시작시간 추가)
        private static void NewMethod3()
        {
            try
            {
                Process proc = Process.GetCurrentProcess();
                Console.WriteLine("****** 프로세스 정보 ******");
                WriteProcessInfo1(proc);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void WriteProcessInfo1(Process processInfo)
        {

            Console.WriteLine("Process : {0}", processInfo.ProcessName);

            Console.WriteLine("시작시간 : {0}", processInfo.StartTime);

            Console.WriteLine("프로세스 PID : {0}", processInfo.Id);

            Console.WriteLine("메모리 : {0}", processInfo.VirtualMemorySize);

        }

        //손을준(이름, ID,메모리, 스레드갯수,사용자이름)
        private static void NewMethod4()
        {
            try
            {
                Process[] allProc = Process.GetProcesses();    //시스템의 모든 프로세스 정보 출력
                int i = 1;
                Console.WriteLine("****** 모든 프로세스 정보 ******");
                Console.WriteLine("현재 실행중은 모든 프로세스 수 : {0}", allProc.Length);
                foreach (Process p in allProc)
                {
                    Console.WriteLine("***** {0}번째 프로세스 ******", i++);
                    WriteProcessInfo2(p);
                    Console.WriteLine();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }
        public static string GetProcessOwner(int pid)
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

        private static void WriteProcessInfo2(Process processInfo)
        {
            Console.WriteLine("Process : {0}", processInfo.ProcessName);
            Console.WriteLine("프로세스 PID : {0}", processInfo.Id);
            Console.WriteLine("메모리 : {0}", processInfo.WorkingSet64);
            Console.WriteLine("스레드 갯수 : {0}", processInfo.Threads.Count);
            Console.WriteLine("사용자이름 : {0}", GetProcessOwner(processInfo.Id));
        }

        private static void NewMethod5()
        {
            Process[] all = Process.GetProcesses();
            //Process[] all = Process.GetProcessesByName("TOTALCMD64");
            foreach (Process thisProc in all.OrderBy(x => x.ProcessName))
            {
                string Name = thisProc.ProcessName;
                Console.WriteLine("Name : " + Name);
                Console.WriteLine("NonpagedSystemMemorySize64 : " + thisProc.NonpagedSystemMemorySize64);
                Console.WriteLine("PagedMemorySize64 : " + thisProc.PagedMemorySize64);
                Console.WriteLine("PagedSystemMemorySize64 : " + thisProc.PagedSystemMemorySize64);
                Console.WriteLine("PeakPagedMemorySize64 : " + thisProc.PeakPagedMemorySize64);
                Console.WriteLine("PeakVirtualMemorySize64 : " + thisProc.PeakVirtualMemorySize64);
                Console.WriteLine("PeakWorkingSet64 : " + thisProc.PeakWorkingSet64);
                Console.WriteLine("PrivateMemorySize64 : " + thisProc.PrivateMemorySize64);
                Console.WriteLine("PrivilegedProcessorTime : " + thisProc.PrivilegedProcessorTime);
                Console.WriteLine("ProcessorAffinity : " + thisProc.ProcessorAffinity);
                Console.WriteLine("TotalProcessorTime : " + thisProc.TotalProcessorTime);
                Console.WriteLine("UserProcessorTime : " + thisProc.UserProcessorTime);
                Console.WriteLine("VirtualMemorySize64 : " + thisProc.VirtualMemorySize64);
                Console.WriteLine("WorkingSet64 : " + thisProc.WorkingSet64); // 작업관리자에서 보이는 메모리 사용량
                Console.WriteLine();
            }
        }

        //프로세스 추가 정보
        private static void NewMethod6()
        {
            try
            {
                using (Process myProcess = Process.Start("NotePad.exe"))
                {
                    while (!myProcess.HasExited)
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.WriteLine();

                        Console.WriteLine($"Physical memory usage     : {myProcess.WorkingSet}");
                        Console.WriteLine($"Base priority             : {myProcess.BasePriority}");
                        Console.WriteLine($"Priority class            : {myProcess.PriorityClass}");
                        Console.WriteLine($"User processor time       : {myProcess.UserProcessorTime}");
                        Console.WriteLine($"Privileged processor time : {myProcess.PrivilegedProcessorTime}");
                        Console.WriteLine($"Total processor time      : {myProcess.TotalProcessorTime}");
                        Console.WriteLine($"Process's Name            : {myProcess}");
                        Console.WriteLine("-------------------------------------");

                        if (myProcess.Responding)
                        {
                            Console.WriteLine("Status:  Responding to user interface");
                            myProcess.Refresh();
                        }
                        else
                        {
                            Console.WriteLine("Status:  Not Responding");
                        }

                        Thread.Sleep(1000);
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Process exit code: {myProcess.ExitCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The following exception was raised: {e.Message}");
            }
        }
        #endregion

        #region 프로세스 실행(완료)
        private static void NewMethod10()
        {
            Process.Start("cmd.exe", "ShutDown.exe -r -f -t 00");
            Process.Start("calc.exe");
        }
        #endregion

        #region 프로세스 종료(완료)
        private static void NewMethod30()
        {
            //
            Process[] processList = Process.GetProcessesByName("Calculator");

            if (processList.Length > 0)
            {
                processList[0].Kill();
                Console.WriteLine("Calculator를 종료하였습니다.");
            }
            else
            {
                Console.WriteLine("Calculator가 실행되지 않았습니다.");
            }
        }
        #endregion

        #region 시스템 정보(CPU사용율, 메모리 사용, 시스템운영시간,시스템기본정보)

        //강건
        private static void NewMethod40()
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;
            while (true)
            {
                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                ramCounter = new PerformanceCounter("Memory", "Available MBytes");
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("CPU사용율 : " + cpuCounter.NextValue() + "%");
                Console.WriteLine("메모리사용율 : " + ramCounter.NextValue() + "MB");
                Thread.Sleep(1000);
            }
        }

        //구본석 -시스템 
        // 시스템 정보 https://stackoverflow.com/questions/26253423/get-system-information-using-c-sharp
        //using System.Management; 어셈블리 추가
        static void NewMethod41()
        {
            System.Management.SelectQuery query = new System.Management.SelectQuery(@"Select * from Win32_ComputerSystem");
            //initialize the searcher with the query it is supposed to execute
            using (System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(query))
            {
                //execute the query
                foreach (System.Management.ManagementObject process in searcher.Get())
                {
                    //print system info
                    process.Get();
                    Console.WriteLine("/*********Operating System Information ***************/");
                    Console.WriteLine("{0}{1}", "System Manufacturer:", process["Manufacturer"]);
                    Console.WriteLine("{0}{1}", " System Model:", process["Model"]);

                }
            }

            System.Management.ManagementObjectSearcher searcher1 = new System.Management.ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            System.Management.ManagementObjectCollection collection = searcher1.Get();


            foreach (ManagementObject obj in collection)
            {
                if (((string[])obj["BIOSVersion"]).Length > 1)
                    Console.WriteLine("BIOS VERSION: " + ((string[])obj["BIOSVersion"])[0] + " - " + ((string[])obj["BIOSVersion"])[1]);
                else
                    Console.WriteLine("BIOS VERSION: " + ((string[])obj["BIOSVersion"])[0]);
            }
        }

        //서지범(시스템운영시간,시스템기본정보)
        // https://bboks.net/248
        private static void NewMethod42()
        {
            string UserName = Environment.UserName; // 현재 시스템에 로그인된 사용자의 이름
            string UserDomainName = Environment.UserDomainName; // 시스템의 도메인 명
            string SystemDirectory = Environment.SystemDirectory;   // 시스템의 디렉토리
            string OSVersion1 = Environment.OSVersion.VersionString; // 현재 운영체제의 버전
            string MachineName = Environment.MachineName;   // 로컬 시스템의 NetBIOS 이름
            string CurrentDirectory = Environment.CurrentDirectory; // 현재 작업 디렉토리
            string OSVersion2 = Environment.OSVersion.Platform.ToString();   // 현재 운영체제의 플랫폼
            int ProcessorCount = Environment.ProcessorCount; // 현재 운영체제의 프로세서 갯수
            int TickCount = Environment.TickCount;   // 시스템이 운영되고 있는 시간 (밀리세컨드)

            Console.WriteLine("사용자 이름 : " + UserName);
            Console.WriteLine("도메인 명 : " + UserDomainName);
            Console.WriteLine("디렉토리 : " + SystemDirectory);
            Console.WriteLine("운영체제 버전  : " + OSVersion1);
            Console.WriteLine("NetBIOS 이름 : " + MachineName);
            Console.WriteLine("현재 작업 디렉토리 : " + CurrentDirectory);
            Console.WriteLine("운영체제 플랫폼 : " + OSVersion2);
            Console.WriteLine("프로세서 개수 : " + ProcessorCount);
            Console.WriteLine("시스템 운영 시간 : " + TickCount);
        }

        //강건(CPU전체 사용율)
        private static void NewMethod43()
        {
            while (true)
            {
                Console.WriteLine(GetTotalCpuUsage() + "%");
                Thread.Sleep(1000);
            }
        }
        private static double GetTotalCpuUsage()
        {
            try
            {
                var wmi = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor where Name != '_Total'");
                var cpuUsages = wmi.Get().Cast<ManagementObject>().Select(mo => (long)(ulong)mo["PercentProcessorTime"]);
                var totalUsage = cpuUsages.Average();

                return (double)totalUsage;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //출처: https://kdsoft-zeros.tistory.com/168 [삽질하는 개발자...]
        private static void NewMethod44()
        {
            while (true)
            {
                int itotalMem = 0; // 총 메모리 KB 단위 
                int itotalMemMB = 0; // 총 메모리 MB 단위 
                int ifreeMem = 0; // 사용 가능 메모리 KB 단위 
                int ifreeMemMB = 0; // 사용 가능 메모리 MB 단위 
                ManagementClass cls = new ManagementClass("Win32_OperatingSystem");
                ManagementObjectCollection moc = cls.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    itotalMem = int.Parse(mo["TotalVisibleMemorySize"].ToString());
                    ifreeMem = int.Parse(mo["FreePhysicalMemory"].ToString());
                }
                itotalMemMB = itotalMem / 1024; // 총 메모리 MB 단위 변경 
                ifreeMemMB = ifreeMem / 1024; // 사용 가능 메모리 MB 단위 변경 

                Console.SetCursorPosition(0, 0);
                //Progressbar Max Setting... 
                Console.WriteLine("총 메모리MB : " + itotalMemMB);//+ pbTotal.Maximum = itotalMemMB;

                //Label Display 
                Console.WriteLine("총 메모리MB : " + itotalMemMB); //lblTotal.Text = itotalMemMB.ToString();
                Console.WriteLine("사용 가능 메모리 : " + ifreeMemMB); //lblFree.Text = ifreeMemMB.ToString();
                Console.WriteLine("사용메모리 : " + (itotalMemMB - ifreeMemMB).ToString()); //lblUse.Text = (itotalMemMB - ifreeMemMB).ToString();
                Thread.Sleep(1000);
            }

        }
        #endregion

        static void Main(string[] args)
        {
            FinalProcessEnum();
        }
    }
}
