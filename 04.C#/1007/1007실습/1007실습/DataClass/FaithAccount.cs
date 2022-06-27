using System;

namespace _1007실습
{
    /// <summary>
    /// 신용 계좌 
    /// Account Class 상속 
    /// 입금시 1%의 이자가 더해진다.
    /// 상위 클래스의 AddMoney 함수 재정의 
    /// </summary>
    [Serializable]
    class FaithAccount : Account
    {

        #region 생성자(2개)
        public FaithAccount(int id, String name) 
            : base(id, name)
        {
        }

        public FaithAccount(int id, String name, int balance)
            :base(id, name, (int)(balance + balance * 0.01))
        {
        }
        #endregion

        public override void AddMoney(int val)
        {
            base.AddMoney((int)(val + val * 0.01));
        }
    }
}
