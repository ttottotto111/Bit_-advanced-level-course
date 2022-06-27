using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1119
{
    class AccList : List<Account>
    {
        //유일한 계좌번호[5자리]를 반환하는 함수
        public int GetAccNumber()
        {
            Random r = new Random();
            while (true)
            {
                int temp = r.Next(10000, 100000);
                if (isCheckNumber(temp) == true)
                    return temp;
            }            
        }

        //동일한 계좌번호가 없을 경우 true반환
        private bool isCheckNumber(int number)
        {
            foreach (Account acc in this)
            {
                if (acc.accId == number)
                    return false;
            }
            return true;
        }
    }
}
