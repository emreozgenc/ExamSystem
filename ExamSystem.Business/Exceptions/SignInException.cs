using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class SignInException : Exception
    {
        public SignInException()
        {
        }

        public SignInException(string message) : base(message)
        {
        }

        public SignInException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SignInException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
