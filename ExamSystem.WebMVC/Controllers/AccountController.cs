using ExamSystem.Business.Abstract;
using ExamSystem.Business.Exceptions;
using ExamSystem.Business.Utilities;
using ExamSystem.Entities.Concrete;
using ExamSystem.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamSystem.WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private ISignInService _signInService;
        public AccountController(
            IUserService userService,
            ISignInService signInService
            )
        {
            _userService = userService;
            _signInService = signInService;
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInService.SignOutAsync();
            TempData["SuccessMessage"] = Messages.SignedOutSuccess;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            ViewData["Title"] = "Giriş yap";
            if (User.Identity.IsAuthenticated)
            {
                TempData["SuccessMessage"] = Messages.AlreadySignedIn;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (!ModelState.IsValid)
            {
                WebUtils.AddErrorsFromModel(ModelState);
                return View(model);
            }

            try
            {
                await _signInService.SignInAsync(model.UserName, model.Password);
            }
            catch (SignInException exception)
            {
                ViewBag.ErrorMessages = exception.Errors;
                return View(model);
            }

            TempData["SuccessMessage"] = Messages.SignedInSuccess;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kayıt Ol";
            if (User.Identity.IsAuthenticated)
            {
                TempData["SuccessMessage"] = Messages.AlreadySignedIn;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                WebUtils.AddErrorsFromModel(ModelState);
                return View(model);
            }

            if (model.Password != model.PasswordCopy)
            {
                ModelState.AddModelError(string.Empty, Messages.PasswordsAreNotTheSame);
                return View();
            }

            User user = GetCorrectUserInstanceByRole(model.Role);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.EMail;
            user.Phone = model.Phone;
            user.UserName = model.UserName;
            user.Password = model.Password;

            try
            {
                _userService.Create(user);
            }
            catch (RegisterException exception)
            {

                ViewBag.ErrorMessages = exception.Errors;
                return View(model);
            }
            catch (ValidationException exception)
            {
                ViewBag.ErrorMessages = exception.Errors;
                return View(model);
            }

            TempData["SuccessMessage"] = Messages.RegisteredSuccess;
            return RedirectToAction("SignIn");
        }

        private User GetCorrectUserInstanceByRole(int role)
        {
            var userRole = (UserRole)role;

            switch (userRole)
            {
                case UserRole.Student:
                    return new Student();
                case UserRole.Teacher:
                    return new Teacher();
                default:
                    return new User();
            }

        }
    }
}
