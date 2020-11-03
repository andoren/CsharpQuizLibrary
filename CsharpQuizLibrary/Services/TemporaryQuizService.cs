using CsharpQuizLibrary.Dao.Interfaces;
using CsharpQuizLibrary.Models;
using CsharpQuizLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpQuizLibrary.Services
{
    public class TemporaryQuizService : IQuizService
    {
        public TemporaryQuizService(IQuizDao dao)
        {
            this.dao = dao;
        }
        IQuizDao dao;
        public Quiz AddQuiz(Quiz newQuiz)
        {
            return dao.AddQuiz(newQuiz);
        }

        public bool DeleteQuiz(int quizId)
        {
            return dao.DeleteQuiz(quizId);
        }

        public IEnumerable<Quiz> GetRandomQuizzes(int count)
        {
            return dao.GetRandomQuizzes(count);
        }

        public Quiz ModifyQuiz(Quiz quiz)
        {
            return dao.ModifyQuiz(quiz);
        }
    }
}
