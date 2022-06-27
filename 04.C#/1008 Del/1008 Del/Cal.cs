using System;
using System.Collections.Generic;
using System.Text;

namespace _1008_Del
{
    class Cal
    {
        public static float Add(int n1, int n2)
        {
            return (float)n1 + n2;
        }
        public static float Sub(int n1, int n2)
        {
            return (float)n1 - n2;
        }
        public static float Mul(int n1, int n2)
        {
            return (float)n1 * n2;
        }
        public static float Div(int n1, int n2)
        {
            if (n2 == 0)
                new Exception("0으로 나눌 수 없습니다.");

            return (float)n1 / n2;
        }
    }

    //[CALBACK = 미리 함수를 등록해 놓고 호출]
    //1. delegate 정의
    delegate void CalResult(float f);
    class Cal1
    {
        //2.delegate 레퍼런스 변수 선언
        private CalResult calResultDel = null;  //callback

        public Cal1(CalResult r)
        {
            //3. 전달된 함수를 delegate에 저장
            calResultDel = r;                   //callback 함수 등록
        }

        public void Add(int n1, int n2)
        {
            float fresult = (float)n1 + n2;
            calResultDel(fresult);
        }
        public void Sub(int n1, int n2)
        {
            float fresult = (float)n1 - n2;
            calResultDel(fresult);
        }
        public void Mul(int n1, int n2)
        {
            float fresult = (float)n1 * n2;
            calResultDel(fresult);
        }
        public void Div(int n1, int n2)
        {
            if (n2 == 0)
                new Exception("0으로 나눌 수 없습니다.");

            float fresult = (float)n1 / n2;
            calResultDel(fresult);
        }
    }
}
