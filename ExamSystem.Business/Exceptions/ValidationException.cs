using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
        {
        }

        public ValidationException(IList<string> errors) : base(errors)
        {
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
