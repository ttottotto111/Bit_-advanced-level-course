using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1131정답지
{
    enum ShapeType
    {
        NONE,
        COMMIT,
        GAME,
        ETC            
    }


    class Student
    {
        private readonly int number;        //학번
        private string name;                //이름
        private ShapeType stype;            //학과
        private int   grade;                //학년(1~4)

        public  int Number { get { return number; }  }
        public int Grade
        {
            get { return grade; }
            set {
                if (value < 0 || value > 4)
                    throw new Exception("해당 학년은 존재하지 않습니다");
                grade = value;
            }
        }

        public ShapeType SType
        {
            get { return stype; }
            set { stype = value; }
        }

        public Student(int _number, string _name, ShapeType _stype, int _grade)
        {
            number = _number;
            name = _name;
            stype = _stype;
            Grade = _grade;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", number, name, stype, grade);
        }

        public void Print()
        {
            Console.WriteLine("학번 : " + number);
            Console.WriteLine("이름 : " + name);
            Console.WriteLine("학과 : " + stype);
            Console.WriteLine("학년 : " + grade);
        }
    }
}
