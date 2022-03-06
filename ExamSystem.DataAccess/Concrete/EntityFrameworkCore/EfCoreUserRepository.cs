using ExamSystem.DataAccess.Abstract;
using ExamSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSystem.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCoreUserRepository : EfCoreGeneralRepository<User, ExamSystemContext>, IUserRepository
    {
        public bool CheckByUserName(string userName)
        {
            using (var context = new ExamSystemContext())
            {
                var checkResult = context.Users.Any(x => x.UserName == userName);
                return checkResult;
            }
        }
    }
}
