using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Student : User
    {
        public ICollection<StudentExam> StudentExams { get; set; }
        public Student()
        {
            Role = UserRole.Student;
        }
    }
}
