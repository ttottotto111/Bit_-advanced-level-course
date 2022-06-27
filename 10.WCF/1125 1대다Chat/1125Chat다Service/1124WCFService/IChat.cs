using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace _1124WCFService
{
    //서비스 계약 처리 
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract =typeof(IChatCallback))]
    interface IChat
    {
        //첫번째 호출되어야 할 메서드(IsInitiating = true) : 세션이열림
        //https://docs.microsoft.com/ko-kr/dotnet/api/system.servicemodel.operationcontractattribute.isinitiating?view=dotnet-plat-ext-5.0
        [OperationContract(IsOneWay = false, IsInitiating = true, IsTerminating = false)]
        bool Join(string idx);

        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = false)]
        void Say(string idx, string msg);

        //마지막에 호출되어야 할 메서드(IsTerminating= true):세션이닫힘
        [OperationContract(IsOneWay = true, IsInitiating = false, IsTerminating = true)]
        void Leave(string idx);
    }

    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void Receive(string idx, string message);

        [OperationContract(IsOneWay = true)]
        void UserEnter(string idx);

        [OperationContract(IsOneWay = true)]
        void UserLeave(string idx);
    }
}
