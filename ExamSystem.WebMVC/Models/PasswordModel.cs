using ExamSystem.Business.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ExamSystem.WebMVC.Models
{
    public class PasswordModel
    {
        [Required(ErrorMessage = Messages.NullOrEmptyPassword)]
        [StringLength(12, ErrorMessage = Messages.PasswordShortOrLong, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre tekrar")]
        public string PasswordCopy { get; set; }
    }
}
