using ExamSystem.Business.Abstract;
using ExamSystem.Business.Exceptions;
using ExamSystem.Business.Utilities;
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

        public Exam GetWithAllDetailsForTeacher(int examId, int teacherUserId)
        {
            CheckIfTeacherHasExam(examId, teacherUserId);

            var exam = _examRepository.GetWithAllDetails(examId);

            return exam;
        }

        private void CheckIfTeacherHasExam(int examId, int teacherUserId)
        {
            var result = _examRepository.TeacherHasExam(examId, teacherUserId);

            if(!result)
            {
                throw new UnauthorizedException(Messages.TeacherDoesNotHaveTheExam);
            }
        }

        public Exam GetWithQuestionsForStudent(int examId, int studentUserId)
        {
            CheckIfStudentHasExam(examId, studentUserId);

            var exam = _examRepository.GetWithQuestions(examId);

            return exam;
        }

        public Exam GetWithTeacherForStudent(int examId, int studentUserId)
        {
            CheckIfStudentHasExam(examId, studentUserId);

            var exam = _examRepository.GetWithTeacher(examId);

            return exam;
        }

        private void CheckIfStudentHasExam(int examId, int studentUserId)
        {
            var result = _examRepository.StudentHasExam(examId, studentUserId);

            if (!result)
            {
                throw new UnauthorizedException(Messages.StudentDoesNotHaveTheExam);
            }
        }

        public void Delete(int examId, int teacherUserId)
        {
            CheckIfTeacherHasExam(examId, teacherUserId);

            _examRepository.Delete(examId);
        }

        public void Update(Exam exam, int teacherUserId)
        {
            CheckIfTeacherHasExam(exam.ExamId, teacherUserId);

            _examRepository.Update(exam);
        }

        public void Create(Exam exam)
        {
            _examRepository.Create(exam);
        }
    }
}
