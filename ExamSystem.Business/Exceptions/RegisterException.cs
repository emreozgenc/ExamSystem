using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class RegisterException : Exception
    {
        public RegisterException()
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
