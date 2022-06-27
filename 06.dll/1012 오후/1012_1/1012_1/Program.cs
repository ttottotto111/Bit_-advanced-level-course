using System;
using _1012ClassLibrary1;

namespace _1012_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cal cal = new Cal();
            Console.WriteLine(cal.Add(10, 20));
            Console.WriteLine(cal.Sub(10, 20));
            Console.WriteLine(cal.Div(10, 20));
            Console.WriteLine(cal.Mul(10, 20));
            Console.WriteLine(cal.Mod(10, 20));
        }
    }
}
