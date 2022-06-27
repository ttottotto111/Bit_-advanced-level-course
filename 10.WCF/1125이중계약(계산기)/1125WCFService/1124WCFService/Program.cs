using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;

namespace _1124WCFService
{
    class Program
    {
        
        static void Hosting3()
        {
            //1.ServiceHost 객체(호스팅 객체)
            //1) 서비스 객체
            //2) Address (접두어 : http)
            ServiceHost host = new ServiceHost(typeof(CalculatorService));

            //=============WSDL 문서 제공하는 코드 추가=====================
            
            //config 파일로 이동

            //3.호스팅 시작
            //  서비스 객체를 정의할 때 전달한 서비스 객체명을 config파일에서 검색 후 설정
            host.Open();

            Console.WriteLine("Press Any Key to stop the service");
            //System.Configuratio 어셈블리 참조 추가
            Uri uri = new Uri(ConfigurationManager.AppSettings["addr"]);
            Console.WriteLine("address : " + "http://localhost:8080/wcf/example/calculatorservice");
            Console.ReadKey(true);

            //4.호스트 종료
            host.Close();
        }

        static void Main(string[] args)
        {
            Hosting3();
        }
    }
}
