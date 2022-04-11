using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Question : IEntity
    {
        [Key]
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string Info { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Exam Exam { get; set; }

        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
    }
}
