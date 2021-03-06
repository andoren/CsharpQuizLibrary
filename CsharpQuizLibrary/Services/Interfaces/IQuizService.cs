﻿using CsharpQuizLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpQuizLibrary.Services.Interfaces
{
    public interface IQuizService
    {
        Quiz AddQuiz(Quiz newQuiz);
        Quiz ModifyQuiz(Quiz quiz);
        Boolean DeleteQuiz(int quizId);
        IEnumerable<Quiz> GetRandomQuizzes(int count);
        Quiz GetQuizById(int id);
    }
}
