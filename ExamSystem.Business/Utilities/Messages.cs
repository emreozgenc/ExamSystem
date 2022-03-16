using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Business.Utilities
{
    public static class Messages
    {
        public const string UserDoesNotExist = "Girmiş olduğunuz kullanıcı adıyla kayıtlı bir kullanıcı bulunmamaktadır.";
        public const string WrongPassword = "Girmiş olduğunuz şifre yanlıştır.";
        public const string UserAlreadyExists = "Girmiş olduğunuz kullanıcı adına sahip zaten bir kullanıcı bulunmaktadır.";
        public const string NullOrEmptyUserName = "Kullanıcı adı alanı boş bırakılamaz.";
        public const string UserNameShortOrLong = "Kullanıcı adı belirtilen sınırlar içerisinde değil.";
        public const string UserNameContainsInvalidCharacters = "Kullanıcı adı uygunsuz karakterler içeriyor. ([a-z][A-Z][0-9])";
        public const string NullOrEmptyPassword = "Şifre alanı boş bırakılamaz.";
        public const string PasswordShortOrLong = "Şifre belirtilen sınırlar içerisinde değil.";
        public const string PasswordsAreNotTheSame = "Girmiş olduğunuz şifreler eşleşmiyor.";
        public const string AlreadySignedIn = "Zaten daha önce oturum açtınız.";
        public const string SignedOutSuccess = "Başarılı bir şekilde çıkış yapıldı.";
        public const string SignedInSuccess = "Başarılı bir şekilde giriş yaptınız.";
        public const string RegisteredSuccess = "Başarılı bir şekilde kaydınız yapıldı. Giriş yapabilirsiniz.";
        public const string InvalidEmail = "Girmiş olduğunuz e-posta adresi geçerli değildir.";
        public const string InvalidPhone = "Girmiş olduğunuz telefon numarası geçerli değildir.";


    }
}
