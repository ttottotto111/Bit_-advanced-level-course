using System; 
 
namespace IntegralTypes 
{ 
    class MainApp 
    { 
        static void Main(string[] args) 
        { 
            sbyte a = -10; 
            byte  b = 40; 
 
            Console.WriteLine("a={0}, b={1}", a, b); 
 
            short  c = -30000; 
            ushort d = 60000; 
             
            Console.WriteLine("c={0}, d={1}", c, d); 
 
            int  e = -10000000; // 0�� 7�� 
            uint f = 300000000; // 0�� 8�� 
 
            Console.WriteLine("e={0}, f={1}", e, f); 
 
            long g  = -500000000000; // 0�� 11�� 
            ulong h = 2000000000000000000; // 0�� 18�� 
 
            Console.WriteLine("g={0}, h={1}", g, h); 
        } 
    } 
}
