using System;
using System.Collections.Generic;
using System.Text;

namespace ExamSystem.Entities.Concrete
{
    public class Admin : User
    {
        public Admin()
        {
            Role = UserRole.Admin;
        }
    }
}
