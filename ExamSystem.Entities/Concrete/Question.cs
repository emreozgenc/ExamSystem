using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string Info { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public Answer CorrectAnswer { get; set; }
        public Exam Exam { get; set; }
    }
}
