using System;
using System.Collections.Generic;
using System.Text;

namespace 예약_관리_프로그램_10_06
{
    class Bus
    {
        private Member[,] Seat =new Member[4, 10];

        #region 생성자
        public  Bus() //배열 초기화
        {
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<10;j++)
                {
                    Seat[i, j] = null;
                }
            }
        }
        #endregion

        #region 예약 & 중복자리 검색
        public void ReserveBusSeat(int x, int y, Member mem)
        {
            //중복체크
            if(SearchSameSeat(x, y) == true)
                Seat[x, y] = mem;//예약
            else
                throw new Exception("중복된 자리 입니다.");
        }

        //중복 자리검색 : 비어있을 때 true
        private bool SearchSameSeat(int x, int y)      //중복 회원검색
        {
            if (Seat[x, y] == null) //비어있을 때
                return true;
            else
                return false;
        }
        #endregion

        #region 예약 취소
        public void CancelReserveBusSeat(int id)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Seat[i, j] != null && Seat[i, j].Id == id)
                    {
                        Seat[i, j] = null;
                        return;
                    }
                }
            }
            throw new Exception("해당 ID는 존재하지 않습니다.");
        }
        #endregion

        #region 출력
        public void BusSeatPrint()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    if (Seat[i, j] == null)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine("");
            }
        }

        #endregion

        //예약 좌석 검색 
        public Member SeatCheck(int x, int y)
        {
            if (Seat[x, y] == null)
                throw new Exception("비어있는 좌석입니다");
            else
                return Seat[x, y];
        }
        
    }
}
