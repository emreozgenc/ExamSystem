using ExamSystem.DataAccess.Abstract;
using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCoreQuestionRepository : EfCoreGeneralRepository<Question, ExamSystemContext>, IQuestionRepository
    {
    }
}
