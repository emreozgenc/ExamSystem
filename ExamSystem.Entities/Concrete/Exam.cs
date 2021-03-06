using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Exam : IEntity
    {
        public int ExamId { get; set; }
        public string LessonName { get; set; }
        public int AnswerCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        public ICollection<StudentExam> StudentExams { get; set; }
    }
}
