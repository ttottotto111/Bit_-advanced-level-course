using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace _1005_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App();

            app.Init();
            app.Run();
            app.Exit();
        }
    }
}
