using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace _1124WCFService
{
    //서비스 객체 : 반드시 계약 인터페이스를 상속 받아야 한다.
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.PerSession, 
        ConcurrencyMode =ConcurrencyMode.Multiple)]
    class ProductService : IProductService
    {
        public ProductService()
        {
            Console.WriteLine("{0}: 서비스의 새로운 인스턴스 생성!!", DateTime.Now);
        }

        public Product GetProduct()
        {
            Console.WriteLine("{0} : GetProduct 호출, Thread Id {1}", 
                            DateTime.Now, Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);

            Product p = new Product();
            p.ProductId = 1234;
            p.ProductName = "ABC Chocolate";
            p.Price = 1500.0;
            p.Company = "Lotteee";
            p.CreateDate = DateTime.Parse("2010-01-22");

            return p;
        }
    }
}
