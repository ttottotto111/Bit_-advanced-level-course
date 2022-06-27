using System;
using System.Collections.Generic;
using System.Text;

namespace 예약_관리_프로그램_10_06
{
    class MemManager
    {
        //key 계좌의 id value account
        private Dictionary<int, Member> memlist = new Dictionary<int, Member>();
		private Bus bus = new Bus();

		#region 1. 회원가입
		public void MakeMember()              // 계좌 개설을 위한 함수
		{
            Console.WriteLine("회원 가입-----------------");
            try
			{
                int id;
                string name, phone;

                InsertMember(out id, out name, out phone);
                Member mem = new Member(id, name, phone);
				memlist.Add(id, mem);
				Console.WriteLine("회원 가입이 완료되었습니다.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("회원 가입이 실패하었습니다.");
				Console.WriteLine("원인 : " + ex.Message);
			}
		}

        //사용자 입력
        private void InsertMember(out int id, out string name, out string phone)
        {
            id = WbGlobal.InputInteger(" 회원 ID ");
            SearchSameMem(id);
            name = WbGlobal.InputString("이름");
            phone = WbGlobal.InputString(" 전화번호 ");
        }

        //중복 id체크 기능
        private void SearchSameMem(int id)      //중복 회원검색
        {
            if (id == 0)
                throw new Exception("ID '0'은 불가능 합니다.");
            if (memlist.ContainsKey(id) == true)
                throw new Exception("중복된 ID가 있습니다.");
        }
        #endregion


        #region 회원 탈퇴
        public void DeleteMember()
		{
			try
			{
				int id = WbGlobal.InputInteger(" 회원  ID ");
				if (memlist.Remove(id) == false)
				{
					throw new Exception(" 해당 회원이 없습니다");
				}
				Console.WriteLine("삭제 완료");
			}
			catch (Exception ex)
			{
				Console.WriteLine("회원 탈퇴 에러가 발생했습니다.");
				Console.WriteLine("원인" + ex.Message);
			}
		}
		#endregion

		#region 전화번호 수정
		public void EditMemberPhone()     //조회
		{
			try
			{
				int id = WbGlobal.InputInteger(" 회원  ID ");
				Member mem = memlist[id];
				string phone = WbGlobal.InputString(" 수정할 전화번호 입력 ");
				mem.Phone = phone;
				Console.WriteLine("수정 완료");
			}
			catch (Exception ex)
			{
				Console.WriteLine("조회 에러가 발생했습니다.");
				Console.WriteLine("원인" + ex.Message);
			}
		}
		#endregion

		#region 회원 검색
		public void SelectMember()     //조회
		{
			try
			{
				int id = WbGlobal.InputInteger(" 회원  ID ");
				Member mem = memlist[id]; 
				mem.ShowAllData();
				Console.WriteLine("조회 완료");
				return;
			}
			catch (Exception ex)
			{
				Console.WriteLine("조회 에러가 발생했습니다.");
				Console.WriteLine("원인" + ex.Message);
			}
		}
		#endregion

		#region 전체 회원 출력
		public void SearchAllMember()       // 전체 저장정보 출력.순회
		{
			Console.WriteLine("저장개수 : " + memlist.Count);
			Console.WriteLine("---------------------------------------");
			foreach (KeyValuePair<int, Member> kvp in memlist)
			{
				//Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
				Member mem = kvp.Value;
				mem.ShowAllData();
			}
		}
        #endregion
        
        //===========================================

        #region 회원 좌석 예약
		public void ReserveBusSeat()
        {
			try
			{
				int id = WbGlobal.InputInteger(" 회원  ID ");
				Member mem = memlist[id];
                int x = WbGlobal.InputInteger("X좌표");
                int y = WbGlobal.InputInteger("Y좌표");

                //버스 클래스의 좌석 예약으로 이동
                bus.ReserveBusSeat(x,y,mem);
				Console.WriteLine("예약 완료");
			}
			catch (Exception ex)
			{
				Console.WriteLine("좌석 예약 중 에러가 발생했습니다.");
				Console.WriteLine("원인" + ex.Message);
			}
		}
		#endregion

		#region 회원 좌석 예약 취소
		public void CancelReserveBusSeat()
		{
			try
			{
				int id = WbGlobal.InputInteger(" 회원  ID ");
				bus.CancelReserveBusSeat(id);//버스 클래스의 좌석 예약으로 이동
				Console.WriteLine("예약 취소 완료");
			}
			catch (Exception ex)
			{
				Console.WriteLine("좌석 예약 취소 중 에러가 발생했습니다.");
				Console.WriteLine("원인" + ex.Message);
			}
		}
		#endregion

		#region 좌석 검색
		public void SearchBusSeat()
		{
			try
			{
				int x = WbGlobal.InputInteger(" 좌석 행 ");
				int y = WbGlobal.InputInteger(" 좌석 열 ");				
                Member mem = bus.SeatCheck(x, y);
                Console.WriteLine("조회 결과\n");
                mem.ShowAllData();				
			}
			catch (Exception ex)
			{
				Console.WriteLine("좌석 예약 조회 중 에러가 발생했습니다.");
				Console.WriteLine("원인" + ex.Message);
			}
		}
		#endregion

		#region 버스 출력
		public void BusSeatPrint()
        {
			bus.BusSeatPrint();
        }
        #endregion
    }
}
