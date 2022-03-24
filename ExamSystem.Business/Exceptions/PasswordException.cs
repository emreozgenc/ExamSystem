using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class PasswordException : ApplicationException
    {
        public PasswordException()
        {
        }

        public PasswordException(IList<string> errors) : base(errors)
        {
        }

        public PasswordException(string message) : base(message)
        {
        }

        public PasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
