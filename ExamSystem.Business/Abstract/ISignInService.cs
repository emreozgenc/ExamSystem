using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.Business.Abstract
{
    public interface ISignInService
    {
        Task SignInAsync(string userName, string password);
        Task SignOutAsync();
    }
}
