using System;
using System.Collections.Generic;
using System.Text;
using _1125UseInstance.ServiceReference1;
using System.Threading;

namespace _1125UseInstance
{
    class Program
    {
        static int c = 0;
        static void GetProductInfoCallback(IAsyncResult ar)
        {
            ProductInfo productInfo = ((ProductServiceClient)ar.AsyncState)
                                           .EndGetProduct(ar);
            Console.WriteLine("{0} : ProductName : {1}", DateTime.Now, productInfo.Name);
            Interlocked.Decrement(ref c);
        }

        static void exam1()
        {
            ProductServiceClient proxy = new ProductServiceClient();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}: GetProduct 메서드 호출", DateTime.Now);
                //비동기 호출(비동기 통지, 통지전달인자값)
                proxy.BeginGetProduct(GetProductInfoCallback, proxy);
                Thread.Sleep(100);
                Interlocked.Increment(ref c);
            }
            while (c > 0)
            {
                Thread.Sleep(100);
            }

        }
        static void Main(string[] args)
        {
            Console.ReadKey(true);
            exam1();
        }
    }
}
