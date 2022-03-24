using ExamSystem.Business.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamSystem.WebMVC.Models
{
    public class InformationModel
    {
        [Required(ErrorMessage = Messages.NullOrEmptyUserName)]
        [StringLength(12, ErrorMessage = Messages.UserNameShortOrLong, MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }

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
    }
}
