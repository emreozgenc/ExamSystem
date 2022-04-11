using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Business.Abstract
{
    public interface IExamService
    {
        Exam GetWithQuestionsForStudent(int examId, int studentUserId);
        Exam GetWithTeacherForStudent(int examId, int studentUserId);
        Exam GetWithAllDetailsForTeacher(int examId, int teacherUserId);
        void Delete(int examId, int teacherUserId);
        void Update(Exam exam, int teacherUserId);
        void Create(Exam exam);
        bool TeacherHasExam(int examId, int teacherUserId);
        bool StudentHasExam(int examId, int studentUserId);

    }
}
