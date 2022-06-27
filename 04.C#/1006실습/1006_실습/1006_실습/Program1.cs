using System;

namespace 예약_관리_프로그램_10_06
{
    class Program
    {
        static void Main(string[] args)
        {
            APP app = new APP();

            app.Init();
            app.Run();
            app.Exit();
        }
    }
}
