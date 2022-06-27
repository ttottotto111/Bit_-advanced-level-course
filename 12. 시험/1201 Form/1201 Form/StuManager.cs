using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1201_Form
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

        public List<Student> PrintAll()
        {
            return stulist;
        }

        //학생추가
        public bool Insert(Student stu)
        {
            try
            {
                stulist.Add(stu);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //검색함수
        public Student NumberToStudent(int number)
        {
            foreach (Student stu in stulist)
            {
                if (stu.Number == number)
                    return stu;
            }
            throw new Exception("없다");
        }

        //삭제함수
        public bool Delete(int number)
        {
            try
            {
                Student stu = NumberToStudent(number);
                stulist.Remove(stu);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //수정함수
        public bool Update(int number, SubjectType type, int grade)
        {
            try
            {
                Student stu = NumberToStudent(number);
                stu.SType = type;
                stu.Grade = grade;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
