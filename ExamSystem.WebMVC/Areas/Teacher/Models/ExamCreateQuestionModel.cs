using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExamSystem.WebMVC.Areas.Teacher.Models
{
    public class ExamCreateQuestionModel
    {
        [Required]
        [Display(Name = "Sınav numarası")]
        public int ExamId { get; set; }
        public string[] Answers { get; set; }

        [Display(Name = "Soru")]
        [Required(ErrorMessage = "Soru alanı boş bırakılamaz.")]
        public string Text { get; set; }

        [Display(Name = "Soru bilgisi")]
        [Required(ErrorMessage = "Soru bilgisi alanı boş bırakılamaz.")]
        public string Info { get; set; }

        [Display(Name = "Doğru cevap numarası")]
        public int CorrectAnswerIndex { get; set; }
        public string LessonName { get; set; }

        public ExamCreateQuestionModel(int answerCount)
        {
            Answers = new string[answerCount];
            for (int i = 0; i < Answers.Length; i++)
                Answers[i] = string.Empty;
        }

        public ExamCreateQuestionModel()
        {

        }
    }
}
