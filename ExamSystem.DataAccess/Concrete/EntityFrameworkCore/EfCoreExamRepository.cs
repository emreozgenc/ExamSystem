﻿using ExamSystem.DataAccess.Abstract;
using ExamSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCoreExamRepository : EfCoreGeneralRepository<Exam, ExamSystemContext>, IExamRepository
    {
        public Exam GetWithAllDetails(int id)
        {
            using (var context = new ExamSystemContext())
            {
                var exam = context.Exams
                            .Include(x => x.StudentExams)
                            .ThenInclude(x => x.Student)
                            .Include(x => x.Teacher)
                            .Include(x => x.Questions)
                            .ThenInclude(x => x.Answers)
                            .FirstOrDefault(x => x.ExamId == id);

                return exam;
            }
        }

        public Exam GetWithQuestions(int id)
        {
            using (var context = new ExamSystemContext())
            {
                var exam = context.Exams
                            .Include(x => x.Questions)
                            .ThenInclude(x => x.Answers)
                            .FirstOrDefault(x => x.ExamId == id);

                return exam;
            }
        }

        public Exam GetWithQuestionsandStudents(int id)
        {
            using (var context = new ExamSystemContext())
            {
                var exam = context.Exams
                            .Include(x => x.Questions)
                            .ThenInclude(x => x.Answers)
                            .Include(x => x.StudentExams)
                            .ThenInclude(x => x.Student)
                            .FirstOrDefault(x => x.ExamId == id);

                return exam;
            }
        }

        public Exam GetWithQuestionsandTeacher(int id)
        {
            using (var context = new ExamSystemContext())
            {
                var exam = context.Exams
                            .Include(x => x.Questions)
                            .ThenInclude(x => x.Answers)
                            .Include(x => x.Teacher)
                            .FirstOrDefault(x => x.ExamId == id);

                return exam;
            }
        }

        public Exam GetWithTeacher(int id)
        {
            using (var context = new ExamSystemContext())
            {
                var exam = context.Exams
                            .Include(x => x.Teacher)
                            .FirstOrDefault(x => x.ExamId == id);

                return exam;
            }
        }

        public bool StudentHasExam(int examId, int studentUserId)
        {
            using (var context = new ExamSystemContext())
            {
                var result = context.StudentExams
                                    .Any(x => x.StudentId == studentUserId && x.ExamId == examId);

                return result;
            }
        }

        public bool TeacherHasExam(int examId, int teacherUserId)
        {
            using (var context = new ExamSystemContext())
            {
                var examTeacherId = context.Exams
                                        .Where(x => x.ExamId == examId)
                                        .Select(x => x.TeacherId)
                                        .FirstOrDefault();

                var result = teacherUserId == examTeacherId;

                return result;
            }
        }
    }
}
