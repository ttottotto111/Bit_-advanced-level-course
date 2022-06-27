using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
/*
* [WCF Service 구축]
* 1) C# Console 프로젝트 생성
* 2) WCF Service 프레임워크를 사용하려면 참조추가 및 using 처리...
*    참조추가  : System.ServiceModel 어셈블리 추가
*    using처리 : using System.ServiceModel;
*    ---------------------------------------------------------------------
* 3) 인터페이스를 정의[interface 새항목 추가] - 계약 정의
*    IHelloWorld 인터페이스 생성
* 4) 계약을 이용해서 서비스 객체 구현
*    HelloWorldWCFService 클래스 생성 
*    -----------------------------------------------------------------------   
* 5) 구성파일 추가 : 응용프로그램 구성파일 ....config
*    
* 6) exe 기반 호스팅 코드 작성
*    main에 작성
*    ------------------------------------------------------------------------
*/

namespace _1124WCFService
{
    class Program
    {        

        //Config파일을 이용하여 Hosting1코드 수정
        static void Hosting3()
        {
            //System.Configuration 어셈블리 추가
            Uri uri = new Uri(ConfigurationManager.AppSettings["addr"]);

            //1. ServiceHost 객체(호스팅 객체)
            //1) 서비스 객체             
            ServiceHost host = new ServiceHost(typeof(ChatService), uri);           
            host.Open();

            Console.WriteLine("Press Any key to stop the service");            
            Console.WriteLine("address : " + uri.ToString());
            Console.ReadKey(true);

            //4. 호스트 종료
            host.Abort();
            host.Close();
        }
        static void Main(string[] args)
        {
            Hosting3();
        }
    }
}
