using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _1203_Service
{
    [ServiceContract]
    interface IStuManager
    {
        [OperationContract]
        List<Student> PrintAll();

        [OperationContract]
        bool StuInsert(Student stu);

        [OperationContract]
        Student NumberToStudent(int number);

        [OperationContract]
        bool StuDelete(int number);

        [OperationContract]
        bool StuUpdate(int number, SubjectType type, int grade);
    }
}
