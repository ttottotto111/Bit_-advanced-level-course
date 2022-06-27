using System;
/*
 * 캡슐화와 데이터 은닉
 * - 맴버 변수
 * - 생성자
 * - get & set 메서드
 * - 일반 메서드 
 * Member 클래스 정의(이름, 전화번호, 맴버번호)
 * 맴버번호는 맴버가 생성될때마다 1씩 증가하면서 저장(단 시작점은 100)
 * 맴버가 생성될 때 이름만 가지고 생성될 수 있고
 * 이름과 전화번호로 생성이 될수도 있다. 
 * 이름과 전화번호, 회원번호는 언제라도 외부에서 획득이 가능하다.(get)
 * 전화번호는 외부에서 수정이 가능하다.(set)
 * 자신의 정보를 출력할 수 있는 기능을 제공한다. 
 */

namespace _1005
{
    class Member
    {
        //맴버 변수 -> 맴버 필드
        private string name;
        private string phone;       //참조형타입이기 때문에 null이 가능.
        private int memberid;

        private static int s_id = 100;  //모든 인스턴스가 공유 변수 

        #region 생성자
        public Member(string name) : this(name, null)
        {
            //           this.memberid = s_id++;
            //           this.name = name;
            //          this.phone = null;
        }

        public Member(string name, string phone)
        {
            this.memberid = s_id++;
            this.name = name;
            this.phone = phone;
        }
        #endregion

        #region get & set 메서드

        public string getName() { return name; }
        public string getPhone() { return phone; }
        public int getMemberId() { return memberid; }
        public void setPhone(string value) { phone = value; }

        #endregion

        #region 기능 메서드
        public void Print()
        {
            Console.WriteLine("이름 : {0}", name);
            Console.WriteLine("전화번호 : " + phone);
            Console.WriteLine("회원번호 : " + memberid);
        }

        #endregion
    }


    /// <summary>
    /// Member 클래스의 get & set 메서드를 property(속성)로 변경 
    /// </summary>
    class Member1
    {
        //맴버 변수 -> 맴버 필드
        private string name;
        private string phone;       //참조형타입이기 때문에 null이 가능.
        private int memberid;

        private static int s_id = 100;  //모든 인스턴스가 공유 변수 

        #region 생성자
        public Member1(string name) : this(name, null)
        {
            //           this.memberid = s_id++;
            //           this.name = name;
            //          this.phone = null;
        }

        public Member1(string name, string phone)
        {
            //set 프로퍼티가 사용됨.
            //프로퍼티명을 대입연산의 L value에 사용하면 set 호출!
            this.MemberId = s_id++;
            this.Name = name;
            this.Phone = phone;
        }
        #endregion

        #region get & set 메서드 => Property

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public int MemberId
        {
            get { return memberid; }
            private set { memberid = value; }
        }


        #endregion

        #region 기능 메서드
        public void Print()
        {
            //get 프로퍼티
            Console.WriteLine("이름 : {0}", Name);
            Console.WriteLine("전화번호 : " + Phone);
            Console.WriteLine("회원번호 : " + MemberId);
        }

        #endregion
    }


    /// <summary>
    /// enum 타입을 사용하는 맴버변수 추가 
    /// </summary>

    enum MemberType { NOT, STUDENT, EMP, ETC }

    class Member2
    {
        //맴버 변수 -> 맴버 필드
        private string name;
        private string phone;
        private int memberid;
        private MemberType type;    //맴버 추가 

        private static int s_id = 100;

        #region 생성자
        public Member2(string name, MemberType type)
            : this(name, type, null)
        {
        }

        public Member2(string name, MemberType type, string phone)
        {
            //set 프로퍼티가 사용됨.
            //프로퍼티명을 대입연산의 L value에 사용하면 set 호출!
            this.MemberId = s_id++;
            this.Name = name;
            this.Phone = phone;
            this.Type = type;
        }
        #endregion

        #region get & set 메서드 => Property

        public MemberType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public int MemberId
        {
            get { return memberid; }
            private set { memberid = value; }
        }


        #endregion

        #region 기능 메서드
        public void Print()
        {
            //get 프로퍼티
            Console.WriteLine("이름 : {0}", Name);
            Console.WriteLine("전화번호 : " + Phone);
            Console.WriteLine("회원번호 : " + MemberId);
            Console.WriteLine("회원타입 : " + Type);
        }

        #endregion
    }
}
