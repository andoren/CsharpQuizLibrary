using System;
using System.Runtime.Serialization;

namespace CsharpQuizLibrary.Models.Exceptions.QuizExceptions
{
    [Serializable]
    public class DuplicateQuizException : Exception
    {
        public DuplicateQuizException()
        {
        }

        public DuplicateQuizException(string message) : base(message)
        {
        }

        public DuplicateQuizException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateQuizException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}