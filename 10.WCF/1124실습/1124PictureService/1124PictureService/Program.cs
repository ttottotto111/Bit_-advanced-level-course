using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace _1124PictureService
{
    class Program
    {
        static void Hosting()
        {
            //1. ServiceHost 객체(호스팅 객체)
            //1) 서비스 객체 
            //2) Address (접두어 : http)
            ServiceHost host = new ServiceHost(
                typeof(TranService), new Uri("http://localhost:8080/wcf/example/transmessage"));

            //2. 호스트에 EndPoint(종점)을 추가한다.
            host.AddServiceEndpoint(
                typeof(Trans),        //Contract(계약) <-- 서비스객체 부모였던 인터페이스
                new BasicHttpBinding(),     //Binding(바인딩) <-- XMLWebService와 100% 동일
                "");

            //============= WSDL 문서 제공하는 코드 추가 ======================
            ServiceMetadataBehavior behavior =
                host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (behavior == null)
            {
                behavior = new ServiceMetadataBehavior();
                host.Description.Behaviors.Add(behavior);
            }
            behavior.HttpGetEnabled = true;
            //===================================================================
            //3. 호스트 시작
            host.Open();

            Console.WriteLine("Press Any key to stop the service");
            Console.WriteLine("address : " + "http://localhost:8080/wcf/example/transmessage");
            Console.ReadKey(true);

            //4. 호스트 종료
            host.Close();
        }

        static void Main(string[] args)
        {
            Hosting();
        }
    }
}
