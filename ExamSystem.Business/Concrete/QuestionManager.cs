using ExamSystem.Business.Abstract;
using ExamSystem.DataAccess.Abstract;
using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private IQuestionRepository _questionRepository;

        public QuestionManager(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void Create(Question entity)
        {
            _questionRepository.Create(entity);
        }

        public void Delete(int entityId)
        {
            _questionRepository.Delete(entityId);
        }

        public Question Get(int entityId)
        {
            var question = _questionRepository.Get(entityId);
            return question;
        }

        public void Update(Question entity)
        {
            _questionRepository.Update(entity);
        }
    }
}
