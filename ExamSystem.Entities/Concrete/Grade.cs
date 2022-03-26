using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Grade : IEntity
    {
        public int GradeId { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public Exam Exam { get; set; }

        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        public int Point { get; set; }

    }
}
