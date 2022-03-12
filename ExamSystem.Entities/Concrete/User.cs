using ExamSystem.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(20)]
        [MinLength(5)]
        [Required]
        public string UserName { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public bool Banned { get; set; } = false;

        [Required]
        public bool Passive { get; set; } = true;

        [MaxLength(11)]
        public string Phone { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public UserRole Role { get; set; }

    }
    public enum UserRole
    {
        Admin = 0, Teacher = 1, Student = 2
    }
}
