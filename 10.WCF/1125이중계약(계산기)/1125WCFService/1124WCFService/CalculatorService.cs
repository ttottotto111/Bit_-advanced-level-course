using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1124WCFService
{
    //서비스 객체 : 반드시 계약 인터페이스를 상속 받아야 한다.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    class CalculatorService : ICalculatorDuplex
    {
        double result;

        ICalculatorDuplexCallback callback = null;

        public CalculatorService()
        {
            result = 0.0D;

            callback = OperationContext.Current.GetCallbackChannel<ICalculatorDuplexCallback>();
        }

        public void Clear()
        {
            result = 0.0D;
            callback.Equation("Clear메서드 호출 성공(result값을 0으로 초기화)");
            callback.Result(result);
        }

        public void AddTo(double n)
        {
            result = result + n;
            callback.Equation("AddTo메서드 호출 성공");
            callback.Result(result);
        }

        public void SubtractFrom(double n)
        {
            result = result - n;
            callback.Equation("SubtractFrom메서드 호출 성공");
            callback.Result(result);
        }

        public void MultiplyBy(double n)
        {
            result = result * n;
            callback.Equation("MultiplyBy메서드 호출 성공");
            callback.Result(result);
        }

        public void DivideBy(double n)
        {
            if (n == 0)
                throw new Exception("0으로 나눌 수 없습니다");

            result = result / n;
            callback.Equation("DivideBy메서드 호출 성공");
            callback.Result(result);
        }

        
    }
}
