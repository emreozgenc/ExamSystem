using ExamSystem.Business.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ExamSystem.WebMVC.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = Messages.NullOrEmptyUserName)]
        [DataType(DataType.Text)]
        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = Messages.NullOrEmptyPassword)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
