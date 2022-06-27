using System;

namespace _1005
{
    /// <summary>
    /// 첫번째 만드는 실습 코드
    /// </summary>
    class Program
    {

        #region 기본문법
        //출력기능
        static void exam1()
        {
            Console.Write("Hello, World\n");
            Console.WriteLine("Hello, World");

            Console.WriteLine("출력 : {0}, {1}, {2}",
                                        10, '한', "한글문자가능");
        }

        //입력기능 : Console.Read : 문자를 입력받는 전용함수 
        static void exam2()
        {
            Console.Write("입력 : ");
            int number = Console.Read();
            Console.WriteLine("결과값 {0} => {1}", (char)number, number);
            //string + int  ==> string + string => string
            Console.WriteLine("결과값 " + number);
        }

        //입력기능 : Console.ReadLine() : string 입력 전용 함수
        //                               모든 타입 입력 처리  
        static void exam3()
        {
            Console.Write("이름(문자열) : ");
            string name = Console.ReadLine();

            Console.Write("나이(정수) : ");
            string tempage = Console.ReadLine();
            int age = int.Parse(tempage);

            Console.Write("몸무게(실수) : ");
            float weight = float.Parse(Console.ReadLine());

            Console.Write("성별(한글문자) : ");
            string tempgender = Console.ReadLine();
            char gender = tempgender[0];

            Console.Write("성별(영문자) : ");
            char gender1 = Console.ReadLine()[0];

            Console.WriteLine(">> 이름 : {0}", name);
            Console.WriteLine(">> 나이 : {0}", age);
            Console.WriteLine(">> 몸무게 : {0}", weight);
            Console.WriteLine(">> 성별(한글) : {0}", gender);
            Console.WriteLine(">> 성별(영문) : {0}", gender1);

        }

        //입력기능 : Console.ReadKey(); 특수키들 입력받을 때 
        static void exam4()
        {
            ConsoleKeyInfo info = Console.ReadKey();
            //검정색 맴버 : 맴버변수 => 프로퍼티
            if (info.Key == ConsoleKey.F1)
            {
                Console.WriteLine("F1키가 눌렸습니다.");
            }
            else if (info.KeyChar == 'C')
            {
                Console.WriteLine("C가 눌렸습니다");
            }

        }
        //=========================================================


        //변수 : 값형식과 참조형식================================

        //값 형식 : 기본형 타입
        static void exam5()
        {
            int num;  //정수를 저장할 저장공간 생성 : 스택메모리 
            num = 10;
            Console.WriteLine("NUM : " + num);
        }

        //참조형식 : 클래스, 배열....string(참조형식이지만 값형식처럼 사용)
        static void exam6()
        {
            Program pr; //Program을 저장할 저장공간 생성(X)
                        //Program의 주소를 저장할 공간 생성(0)
            pr = new Program(); //new 연산자를 통해서 Program 저장공간 생성
                                //생성된 Program의 주소를 pr이 저장 

            //delete pr;  //delete연산자 없다.-> 가비지가 알아서 제거
        }

        //String or string ??(참조형식이지만 값형식처럼 사용)
        static void exam7()
        {
            char[] chars = { 'a', 'b', 'c', 'd', '\0', 'A', 'B', 'C', 'D', '\0' };

            //String은 클래스타입 -> 참조형타입이다. 
            String str1 = new String(chars);

            //하지만, 기본형 타입처럼 쓸 수 있는 기능을 지원
            string str2 = "aaa";

            Console.WriteLine(str1 + str2);
        }

        //object : 참조형 타입(클래스)
        //         반듯이 주소값을 저장하고 있다.
        static void exam8()
        {
            int num = 10;
            Object obj1 = num;

            Program pro = new Program();
            Object obj2 = pro;

        }

        //숫자 타입은 문자열과 변환연산이 가능하다.
        //int -> string : toString()
        //string -> int : parse()
        static void exam9()
        {
            string temp = "12.123";
            float f = float.Parse(temp);

            string temp1 = f.ToString();
        }

        //nullable
        static void exam10()
        {
            int? num1 = 10;
            num1 = 20;
            num1 = 30;
            Console.WriteLine("NUM1의 값 : " + num1);
            num1 = null;
            Console.WriteLine("NUM1의 값 : " + num1);
        }

        //Object와 var
        static void exam11()
        {
            var ar = 10;
            int arvalue = ar;
            Console.WriteLine(ar);
        }

        static void exam12_fun1(int number)
        {
            number = 20;
        }
        static void exam12_fun2(ref int number)
        {
            number = 15;
        }
        static void exam12_fun3(out int number)
        {
            number = 10;
        }
        static void exam12()
        {
            int num = 10;
            exam12_fun1(num);       //call by value
            Console.WriteLine(num); //20

            exam12_fun2(ref num);   //call by reference
            Console.WriteLine(num); //15

            exam12_fun3(out num);
            Console.WriteLine(num);
        }

        //ref와 out의 차이점
        //ref는 함수 호출 과정에서 값을 변경해도 되고, 변경하지 않아도 된다.
        //out은 함수 호출 과정에서 반드시 값을 변경해야 한다.
        static void exam13_fun1(int n1, ref int n2, out int n3)
        {
            Console.WriteLine(n2);
            n3 = 0; //반드시 있어야할 코드
        }
        //값 전달 : 반드시 초기화된 변수를 전달 (num1은 초기화가 안되어 있다.)
        //ref전달 : 반드시 초기화된 변수를 전달 (num2은 초기화가 안되어 있다.)
        //out전달 : 초기화 안한 변수를 전달할 수 있다.
        static void exam13()
        {
            int num1 = 0;
            int num2 = 0;
            exam13_fun1(num1, ref num2, out num2);
        }
        #endregion

        #region Member 클래스 사용

        static void exam14()
        {
            Member mem1 = new Member("홍길동");
            Member mem2 = new Member("김길동", "010-1234-1234");
            mem1.Print();
            mem2.Print();
            Console.WriteLine("----------------------------------");
            mem2.setPhone("010-1111-1111");
            mem1.Print();
            Console.WriteLine("홍길동의 전화번호 : {0}", mem1.getPhone());
        }

        static void exam15()
        {
            Member2 mem1 = new Member2("홍길동", MemberType.STUDENT);
            Member2 mem2 = new Member2("김길동", MemberType.EMP, "010-1234-1234");
            mem1.Print();
            mem2.Print();
            Console.WriteLine("----------------------------------");
            mem1.Phone = "010-1111-1111";
            mem1.Print();
            Console.WriteLine("홍길동의 전화번호 : {0}", mem1.Phone);
        }

        #endregion

        static void Main(string[] args)
        {
            exam2();
        }
    }
}
