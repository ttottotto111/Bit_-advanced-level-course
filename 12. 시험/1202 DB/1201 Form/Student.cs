using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1201_Form
{
    public enum SubjectType
    {
        NONE,
        COM,
        IT,
        GAME,
        ETC
    }

    public class Student
    {
        private readonly int number;        //학번
        private string name;                //이름
        public SubjectType stype;            //학과
        private int grade;                //학년(1~4)

        public int Number { get { return number; } }

        public string Name { get { return name; } }
        public int Grade
        {
            get { return grade; }
            set
            {
                if (value < 0 || value > 4)
                    throw new Exception("해당 학년은 존재하지 않습니다");
                grade = value;
            }
        }

        public SubjectType SType
        {
            get { return stype; }
            set { stype = value; }
        }

        public Student()
        {

        }
        public Student(int _number, string _name, SubjectType _stype, int _grade)
        {
            number = _number;
            name = _name;
            stype = _stype;
            Grade = _grade;
        }
    }
}
