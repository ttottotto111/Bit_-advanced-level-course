using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1131정답지
{
    class StuManager
    {
        #region 싱글톤
        private static StuManager singleton;
        public static StuManager Singleton { get { return singleton; } }

        static StuManager()
        {
            singleton = new StuManager();
        }        

        private StuManager() { }

        #endregion

        List<Student> stulist = new List<Student>();

        #region  기능
        public void PrintAll()
        {
            foreach(Student stu in stulist)
            {
                Console.WriteLine(stu);
            }
        }

        public void InsertStudent()
        {
            try
            {
                Console.Write("학번 : ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("이름 : ");
                string name = Console.ReadLine();

                Console.Write("학과([1]컴퓨터,[2]게임,[3]기타) : ");
                ShapeType stype = (ShapeType)int.Parse(Console.ReadLine());

                Console.Write("학년 : ");
                int grade = int.Parse(Console.ReadLine());

                Student stu = new Student(number, name, stype, grade);

                stulist.Add(stu);
                Console.WriteLine("저장되었습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러 메시지 : ", ex.Message);
                Console.WriteLine("저장 실패");
            }
        }

        private Student NumberToStudent(int number)
        {
            foreach (Student stu in stulist)
            {
                if (stu.Number == number)                
                    return stu;                
            }
            throw new Exception("없다");
        }

        public void DeleteStudent()
        {
            try
            {
                Console.Write("학번 : ");
                int number = int.Parse(Console.ReadLine());

                Student stu = NumberToStudent(number);

                stulist.Remove(stu);

                Console.WriteLine("삭제 성공");
            }
            catch(Exception ex)
            {
                Console.WriteLine("에러 메시지 : " + ex.Message);
                Console.WriteLine("삭제 실패");
            }
        }

        public void SelectStudent()
        {
            try
            {
                Console.Write("학번 : ");
                int number = int.Parse(Console.ReadLine());

                Student stu = NumberToStudent(number);

                stu.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러 메시지 : " + ex.Message);
                Console.WriteLine("검색 실패");
            }
        }

        public void UpdateStudent()
        {
            try
            {
                Console.Write("학번 : ");
                int number = int.Parse(Console.ReadLine());

                Student stu = NumberToStudent(number);

                Console.Write("학과([1]컴퓨터,[2]게임,[3]기타) : ");
                ShapeType stype = (ShapeType)int.Parse(Console.ReadLine());

                Console.Write("학년 : ");
                int grade = int.Parse(Console.ReadLine());

                stu.SType = stype;
                stu.Grade = grade;

                Console.WriteLine("수정 성공");
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러 메시지 : " + ex.Message);
                Console.WriteLine("수정 실패");
            }
        }


        #endregion
    }
}
