using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace _1124PictureService
{
    class Program
    {
        static void Hosting3()
        {
          
            ServiceHost host = new ServiceHost(typeof(PictureService));
            host.Open();

            Console.WriteLine("Press Any key to stop the service");
            Console.WriteLine("address : " + "http://localhost:8080/wcf/example/pictureservice");
            Console.ReadKey(true);
            
            host.Close();
        }

        static void Main(string[] args)
        {
            Hosting3();
        }
    }
}
