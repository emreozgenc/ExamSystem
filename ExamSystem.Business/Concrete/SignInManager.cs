using ExamSystem.Business.Abstract;
using ExamSystem.Business.Exceptions;
using ExamSystem.Business.Utilities;
using ExamSystem.DataAccess.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ExamSystem.Business.Concrete
{
    public class SignInManager : ISignInService
    {
        private IUserRepository _userRepository;
        private IHttpContextAccessor _httpContextAccessor;
        public SignInManager(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SignInAsync(string userName, string password)
        {
            CheckUserIfExists(userName);

            var user = _userRepository.GetByUserName(userName);

            var passwordHash = user.PasswordHash;
            var passwordCheck = BCryptNet.Verify(password, passwordHash);

            if(passwordCheck)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipals = new ClaimsPrincipal(claimsIdentity);

                await _httpContextAccessor.HttpContext.SignInAsync(claimsPrincipals);

            }
            else
            {
                throw new SignInException(Messages.WrongPassword);
            }
            
        }

        private void CheckUserIfExists(string userName)
        {
            var checkResult = _userRepository.CheckByUserName(userName);

            if (!checkResult)
            {
                throw new SignInException(Messages.UserDoesNotExist);
            }
        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}
