using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException()
        {
        }

        public UnauthorizedException(IList<string> errors) : base(errors)
        {
        }

        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
