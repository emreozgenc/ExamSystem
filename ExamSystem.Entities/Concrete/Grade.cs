using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Grade : IEntity
    {
        public int GradeId { get; set; }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public int Point { get; set; }

    }
}
