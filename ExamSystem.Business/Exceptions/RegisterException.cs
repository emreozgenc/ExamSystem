using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class RegisterException : ApplicationException
    {
        public RegisterException()
        {
        }

        public RegisterException(IList<string> errors) : base(errors)
        {
        }

        public RegisterException(string message) : base(message)
        {
        }

        public RegisterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RegisterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
