using System;
using System.Runtime.InteropServices;

class CSTest
{
	#region 외부 DLL 정의문
	[DllImport("User32.dll")]
	public static extern int MessageBox(int hParent, string Message, string Caption, int Type);

	[DllImport("Kernel32.dll")]
	public static extern uint WinExec(string Path, uint nCmdShow);
	#endregion

	static void Main()
	{
		MessageBox(0, "메모장을 실행합니다.", "알림", 0);
		WinExec("notepad.exe", 1);
	}
}
