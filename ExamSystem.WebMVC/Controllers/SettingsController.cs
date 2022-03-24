using ExamSystem.Business.Abstract;
using ExamSystem.Business.Exceptions;
using ExamSystem.Business.Utilities;
using ExamSystem.WebMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Security.Claims;

namespace ExamSystem.WebMVC.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private IUserService _userService;
        public SettingsController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Password(PasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                WebUtils.AddErrorsFromModel(ModelState);
                return View(model);
            }

            if (model.Password != model.PasswordCopy)
            {
                ModelState.AddModelError(string.Empty, Messages.PasswordsAreNotTheSame);
                return View(model);
            }

            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userService.Get(userId);
            user.Password = model.Password;

            try
            {
                _userService.UpdatePassword(user);
            }
            catch (ValidationException exception)
            {
                ViewBag.ErrorMessages = exception.Errors;
                return View(model);
            }
            catch (PasswordException exception)
            {
                ViewBag.ErrorMessages = exception.Errors;
                return View(model);
            }

            TempData["SuccessMessage"] = "Şifreniz başarılı bir şekilde değiştirildi.";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Information()
        {
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userService.Get(userId);

            var model = new InformationModel()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EMail = user.Email,
                Phone = user.Phone,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Information(InformationModel model)
        {

            if (!ModelState.IsValid)
            {
                WebUtils.AddErrorsFromModel(ModelState);
                return View(model);
            }

            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userService.Get(userId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Phone = model.Phone;
            user.Email = model.EMail;

            try
            {
                _userService.Update(user);
            }
            catch (ValidationException exception)
            {
                ViewBag.ErrorMessages = exception.Errors;
                return View(model);
            }

            TempData["SuccessMessage"] = "Bilgileriniz başarılı bir şekilde güncellendi.";
            return RedirectToAction("Index", "Home");
        }
    }
}
