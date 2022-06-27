using System;

namespace _1007실습
{
    class WbGlobal
    {
        #region 입력기능
        public static string InputString(string msg)
        {
            Console.Write(msg + " : ");
            return Console.ReadLine();
        }

        public static int InputInteger(string msg)
        {
            Console.Write(msg + " : ");
            return int.Parse(Console.ReadLine());
        }

        #endregion

    }
}
