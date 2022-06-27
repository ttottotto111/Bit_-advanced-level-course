using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1124
{
    //서비스 계약 처리
    [ServiceContract]
    interface IHelloWorld
    {
        [OperationContract]
        string SayHello();      //자동으로 public virtual

        void foo();             //외부공개가 되지 않음
    }
}
