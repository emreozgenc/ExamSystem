using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        bool CheckByUserName(string userName);
        User GetByUserName(string userName);
    }
}
