using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _1203_Service
{
    [DataContract(Name = "Enumclass")]
    public enum SubjectType
    {
        [EnumMember]
        NONE,
        [EnumMember]
        COM,
        [EnumMember]
        IT,
        [EnumMember]
        GAME,
        [EnumMember]
        ETC
    }

    [DataContract(Name = "Stu")]
    public class Student
    {
        [DataMember]
        public readonly int Number;

        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public SubjectType SType { get; set; }


        private int grade;

        [DataMember]
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

        public Student(int _number, string _name, SubjectType _stype, int _grade)
        {
            Number = _number;
            Name = _name;
            SType = _stype;
            Grade = _grade;
        }
    }
}
