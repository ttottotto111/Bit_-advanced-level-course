using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1123.localhost;

namespace _1123
{
    class Program
    {
        static void Main(string[] args)
        {
            CalService sv = new CalService();

            Console.WriteLine(sv.Add(10, 20));
            Console.WriteLine(sv.Sub(50, 20));
            Console.WriteLine(sv.Mul(3, 20));
        }
    }
}
