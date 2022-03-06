using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class ValidationException : Exception
    {
        private IList<string> _errors;
        public IList<string> Errors
        {
            get
            {
                return _errors;
            }
            private set
            {
                _errors = value;
            }
        }
        public ValidationException(IList<string> errors)
        {
            _errors = errors;
        }
        public ValidationException()
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
