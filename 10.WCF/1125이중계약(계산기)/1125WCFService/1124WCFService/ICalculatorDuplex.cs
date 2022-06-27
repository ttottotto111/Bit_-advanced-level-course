using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1124WCFService
{
    //서비스 계약 처리
    [ServiceContract(SessionMode = SessionMode.Required, 
        CallbackContract = typeof(ICalculatorDuplexCallback))]
    interface ICalculatorDuplex
    {
        [OperationContract(IsOneWay = true)]
        void Clear();

        [OperationContract(IsOneWay = true)]
        void AddTo(double n);

        [OperationContract(IsOneWay = true)]
        void SubtractFrom(double n);

        [OperationContract(IsOneWay = true)]
        void MultiplyBy(double n);

        [OperationContract(IsOneWay = true)]
        void DivideBy(double n);

    }

    public interface ICalculatorDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void Result(double result);
        [OperationContract(IsOneWay = true)]
        void Equation(string eqn);
    }
}
