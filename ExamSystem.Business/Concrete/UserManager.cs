using ExamSystem.Business.Abstract;
using ExamSystem.Business.Exceptions;
using ExamSystem.Business.Utilities;
using ExamSystem.DataAccess.Abstract;
using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ExamSystem.Business.Concrete
{
    public class UserManager : IUserService
    {
        private const int UserNameMaxLength = 12;
        private const int UserNameMinLength = 6;
        private const int PasswordMaxLength = 12;
        private const int PasswordMinLength = 8;
        private const string MailRegex = @"([\w+\.]+)@(\w+)\.(\w{2,})\.?(\w{2,})?";
        private const string PhoneRegex = @"\(?0?[ -]?\(?(5\d{2})\)?[ -]?(\d{3})[ -]?(\d{2}[ -]?\d{2})";
        private Regex mailRegex;
        private Regex phoneRegex;
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            mailRegex = new Regex(MailRegex);
            phoneRegex = new Regex(PhoneRegex);
        }
        public void Create(User user)
        {
            CheckUserNameIfExists(user.UserName);
            ValidateUser(user);

            var passwordHash = BCryptNet.HashPassword(user.Password);
            user.PasswordHash = passwordHash;

            _userRepository.Create(user);
        }

        private void ValidateUser(User user)
        {
            var validationErrors = new List<string>();
            var userName = user.UserName;
            var password = user.Password;
            var passwordHash = user.PasswordHash;
            var email = user.Email;
            var phone = user.Phone;

            if (string.IsNullOrEmpty(userName))
            {
                validationErrors.Add(Messages.NullOrEmptyUserName);
            }

            if (userName.Length > UserNameMaxLength || userName.Length < UserNameMinLength)
            {
                validationErrors.Add(Messages.UserNameShortOrLong + $" ({UserNameMinLength} - {UserNameMaxLength})");
            }

            foreach (var character in userName)
            {
                var isLetterOrDigit = Char.IsLetterOrDigit(character);
                if (!isLetterOrDigit)
                {
                    validationErrors.Add(Messages.UserNameContainsInvalidCharacters);
                    break;
                }
            }

            if (string.IsNullOrEmpty(passwordHash))
            {
                if (string.IsNullOrEmpty(password))
                {
                    validationErrors.Add(Messages.NullOrEmptyPassword);
                }

                if (password.Length > PasswordMaxLength || password.Length < PasswordMinLength)
                {
                    validationErrors.Add(Messages.PasswordShortOrLong + $" ({PasswordMinLength} - {PasswordMaxLength})");
                }
            }

            if (!string.IsNullOrEmpty(email) && !mailRegex.IsMatch(email))
            {
                validationErrors.Add(Messages.InvalidEmail);
            }

            if (!string.IsNullOrEmpty(phone) && !phoneRegex.IsMatch(phone))
            {
                validationErrors.Add(Messages.InvalidPhone);
            }

            if (validationErrors.Count > 0)
            {
                throw new ValidationException(validationErrors);
            }

        }

        private void CheckUserNameIfExists(string userName)
        {
            var checkResult = _userRepository.CheckByUserName(userName);

            if (checkResult)
            {
                throw new RegisterException(Messages.UserAlreadyExists);
            }
        }

        public void Delete(int userId)
        {
            _userRepository.Delete(userId);
        }

        public User Get(int userId)
        {
            var user = _userRepository.Get(userId);
            return user;
        }

        public void Update(User user)
        {
            ValidateUser(user);
            _userRepository.Update(user);
        }

        public void UpdatePassword(User user)
        {
            ValidateUser(user);
            CheckNewPassword(user);
            var password = user.Password;
            var passwordHash = BCryptNet.HashPassword(password);

            user.PasswordHash = passwordHash;

            _userRepository.Update(user);
        }

        private void CheckNewPassword(User user)
        {
            var oldPassword = _userRepository.Get(user.UserId).PasswordHash;
            var result = BCryptNet.Verify(user.Password, oldPassword);

            if (result)
            {
                throw new PasswordException(Messages.NewPasswordCanNotBeEqualToOld);
            }

        }
    }
}
