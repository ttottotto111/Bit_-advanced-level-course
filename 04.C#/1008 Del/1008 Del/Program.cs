using System;

namespace _1008_Del
{
    delegate float CalDel(int n1, int n2);

    class Program
    {
        static void Result(float f)
        {
            Console.WriteLine("결과값 : " + f);
        }
        static void Main(string[] args)
        {
            Cal1 cal = new Cal1(Result);
            cal.Add(10, 20);
            cal.Mul(20, 30);
        }

        private static void NewMethod()
        {
            CalDel caldel = Cal.Add;
            Console.WriteLine(caldel(10, 20));
            Console.WriteLine(caldel.Invoke(10, 20));
        }
    }
}