using System;

namespace _1012ClassLibrary1
{
    public class Cal
    {
        public float Add(int n1, int n2)
        {
            return (float)n1 + n2;
        }
        public float Sub(int n1, int n2)
        {
            return (float)n1 - n2;
        }
        public float Mul(int n1, int n2)
        {
            return (float)n1 * n2;
        }
        public float Div(int n1, int n2)
        {
            return (float)n1 / n2;
        }
        public int Mod(int n1, int n2)
        {
            return n1 % n2;
        }
    }
}
