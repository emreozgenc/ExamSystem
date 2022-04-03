using System;
using System.ComponentModel.DataAnnotations;

namespace ExamSystem.WebMVC.Areas.Teacher.Models
{
    public class ExamCreateModel
    {
        [Display(Name = "Ders adı")]
        [Required(ErrorMessage = "Ders adı alanı boş bırakılamaz.")]
        [DataType(DataType.Text)]
        public string LessonName { get; set; }

        [Display(Name = "Sınav seçenek sayısı")]
        [Required(ErrorMessage = "Sınav seçenek sayısı alanı boş bırakılamaz.")]
        [Range(2, 5, ErrorMessage = "Sınav en az iki en fazla beş şıktan oluşabilir.")]
        public int AnswerCount { get; set; }

        [Display(Name = "Başlangıç tarihi")]
        [Required(ErrorMessage = "Başlangıç tarihi alanı boş bırakılamaz.")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [Display(Name = "Bitiş tarihi")]
        [Required(ErrorMessage = "Bitiş tarihi alanı boş bırakılamaz.")]
        [DataType(DataType.DateTime)]
        public DateTime FinishTime { get; set; }
    }
}
