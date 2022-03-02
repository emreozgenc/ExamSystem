using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        public bool Banned { get; set; } = false;
        [MaxLength(11)]
        public string Phone { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

    }
    public enum UserRole
    {
        Admin, Teacher, Student
    }
}
