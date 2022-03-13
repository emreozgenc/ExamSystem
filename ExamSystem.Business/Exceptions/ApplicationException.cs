using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ExamSystem.Business.Exceptions
{
    public class ApplicationException : Exception
    {
        protected IList<string> _errors;
        public IList<string> Errors
        {
            get => _errors;
            private set => _errors = value;
        }

        public ApplicationException()
        {
        }

        public ApplicationException(IList<string> errors)
        {
            _errors = errors;
        }

        public ApplicationException(string message) : base(message)
        {
            _errors = new List<string>();
            _errors.Add(message);
        }

        public ApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
