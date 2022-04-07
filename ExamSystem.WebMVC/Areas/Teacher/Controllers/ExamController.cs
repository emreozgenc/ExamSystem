using ExamSystem.Business.Abstract;
using ExamSystem.Business.Exceptions;
using ExamSystem.Entities.Concrete;
using ExamSystem.WebMVC.Areas.Teacher.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Security.Claims;

namespace ExamSystem.WebMVC.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class ExamController : Controller
    {
        private IUserService _userService;
        private IExamService _examService;

        public ExamController(
            IUserService userService,
            IExamService examService
            )
        {
            _userService = userService;
            _examService = examService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExamCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                WebUtils.AddErrorsFromModel(ModelState);
                return View(model);
            }

            var teacherUserId = WebUtils.GetUserIdFromClaims(User);

            var exam = new Exam()
            {
                LessonName = model.LessonName,
                AnswerCount = model.AnswerCount,
                StartTime = model.StartTime,
                FinishTime = model.FinishTime,
                TeacherId = teacherUserId,
            };

            _examService.Create(exam);

            TempData["SuccessMessage"] = $"\"{exam.LessonName}\" sınavı başarılı bir şekilde oluşturuldu.";
            return RedirectToAction("Detail", new { id = exam.ExamId });
        }

        [HttpGet]
        public IActionResult Detail(int id = 1)
        {
            var teacherUserId = WebUtils.GetUserIdFromClaims(User);
            Exam exam = null;
            try
            {
                exam = _examService.GetWithAllDetailsForTeacher(id, teacherUserId);
                ViewData["Title"] = $"{exam.LessonName} - Detay";
            }
            catch (UnauthorizedException exception)
            {
                // To do exception handling
                return RedirectToAction("Index");
            }

            var model = new ExamDetailModel() { Exam = exam };
            return View(model);
        }
    }
}
