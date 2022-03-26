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
    }
}