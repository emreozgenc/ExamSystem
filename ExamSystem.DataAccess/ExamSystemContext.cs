using ExamSystem.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.DataAccess
{
    public class ExamSystemContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<StudentExam> StudentExams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=examsystem.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentExam>()
                .HasKey(x => new { x.StudentId, x.ExamId });

            builder.Entity<StudentExam>()
                .HasOne(x => x.Student)
                .WithMany(x => x.StudentExams)
                .HasForeignKey(x => x.StudentId);

            builder.Entity<StudentExam>()
                .HasOne(x => x.Exam)
                .WithMany(x => x.StudentExams)
                .HasForeignKey(x => x.ExamId);

        }
    }
}
