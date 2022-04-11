using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Answer : IEntity
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public Question Question { get; set; }

        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public bool IsCorrectAnswer { get; set; }
    }
}
