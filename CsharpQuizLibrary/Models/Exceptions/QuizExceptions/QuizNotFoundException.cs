using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpQuizLibrary.Models.Exceptions.QuizExceptions
{
    public class QuizNotFoundException:Exception
    {
        public QuizNotFoundException(string Message):base(Message)
        {

        }
    }
}
