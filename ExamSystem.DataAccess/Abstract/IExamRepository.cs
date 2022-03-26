using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.DataAccess.Abstract
{
    public interface IExamRepository : IRepository<Exam>
    {
        Exam GetWithTeacher(int id);
        Exam GetWithQuestions(int id);
        Exam GetWithQuestionsandTeacher(int id);
    }
}
