using System;
using System.Collections.Generic;
using System.Text;

namespace 예약_관리_프로그램_10_06
{
    class Member
    {
        #region 맴버변수 & Property

        private readonly int id;//생성자에서 초기화 수행
        public int Id
        {
            get { return id; }
        }

        public string Name { get; private set; }
		public string Phone { get; set; }		
		
		#endregion

		#region 생성자
		public Member(int id, string name, string phone)//회원가입을 진행하는 경우
		{
			this.id = id;
			Name = name;
			Phone = phone;
		}

		#endregion

		#region 기능구현
		public void ShowAllData()			//회원정보 출력
		{
			Console.WriteLine(" [ID] " + Id + "\t [이름] " + Name + " \t[전화번호] " + Phone);
		}

		#endregion
	}
}
