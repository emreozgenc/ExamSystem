using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Teacher : User
    {
        public ICollection<Exam> Exams { get; set; }
        public Teacher()
        {
            Role = UserRole.Teacher;
        }
    }
}
