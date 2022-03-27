using ExamSystem.Business.Abstract;
using ExamSystem.DataAccess.Abstract;
using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Business.Concrete
{
    public class ExamManager : IExamService
    {
        private IExamRepository _examRepository;

        public ExamManager(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public void Create(Exam exam)
        {
            _examRepository.Create(exam);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Exam Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Exam exam)
        {
            throw new NotImplementedException();
        }
    }
}
