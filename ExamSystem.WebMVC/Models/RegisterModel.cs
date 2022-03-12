using ExamSystem.Business.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamSystem.WebMVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = Messages.NullOrEmptyUserName)]
        [StringLength(12, ErrorMessage = Messages.UserNameShortOrLong, MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = Messages.NullOrEmptyPassword)]
        [StringLength(12, ErrorMessage = Messages.PasswordShortOrLong, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre tekrar")]
        public string PasswordCopy { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "*E-Posta adresi")]
        public string EMail { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "*Telefon numarası")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
        [MaxLength(25, ErrorMessage = "Ad alanı en fazla yirmi beş karakter olabilir.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
        [MaxLength(25, ErrorMessage = "Soyad alanı en fazla yirmi beş karakter olabilir.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Display(Name = "Hesap tipi")]
        public int Role { get; set; }

    }
}
