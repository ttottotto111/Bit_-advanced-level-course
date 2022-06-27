using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace _1124WCFService
{
    //서비스 계약 처리 
    [ServiceContract(SessionMode = SessionMode.Required)]
    interface IProductService
    {
        [OperationContract] 
        Product GetProduct();   //인터페이스기때문에 자동으로 public virtual
    }
}
