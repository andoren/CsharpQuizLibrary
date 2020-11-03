using CsharpQuizLibrary.Dao.Interfaces;
using CsharpQuizLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpQuizLibrary.Dao
{
     public class TemporaryQuizDao : IQuizDao
    {
  
        private static readonly Random rnd = new Random();
        private List<Quiz> tempDb = new List<Quiz>() {
             new Quiz(1, "Question" + 1, "Explanation" + 1, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4)),
             new Quiz(2, "Question" + 2, "Explanation" + 2, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4)),
             new Quiz(3, "Question" + 3, "Explanation" + 3, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4)),
             new Quiz(4, "Question" + 4, "Explanation" + 4, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4)),
             new Quiz(5, "Question" + 5, "Explanation" + 5, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4)),
             new Quiz(6, "Question" + 6, "Explanation" + 6, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4)),
             new Quiz(7, "Question" + 7, "Explanation" + 7, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4))
        };
        public Quiz AddQuiz(Quiz newQuiz)
        {
            Quiz quiz = new Quiz(tempDb.Count + 1, newQuiz.Question, newQuiz.Explanation, newQuiz.Answers, newQuiz.CorrectAnswer);
            
            return quiz;
        }

        public bool DeleteQuiz(int quizId)
        {
            int countBeforeDelete = tempDb.Count;
            tempDb.RemoveAt(quizId - 1); 
            return countBeforeDelete != tempDb.Count;
        }

        public IEnumerable<Quiz> GetRandomQuizzes(int count)
        {
            Quiz[] data = new Quiz[count];
            for (int i = 0; i < count; i++)
            {
                int id = rnd.Next(0, 500);
                data[i] = new Quiz(id, "Question" + id, "Explanation" + id, new string[4] { "Answer1", "Answer2", "Answer3", "Answer4" }, "Answer" + rnd.Next(1, 4));
            }
            return data;
        }

        public Quiz ModifyQuiz(Quiz quiz)
        {
            Quiz quizToModify = tempDb.Where(x=> x.Id == quiz.Id).FirstOrDefault();
            quizToModify.Answers = quiz.Answers;
            quizToModify.CorrectAnswer= quiz.CorrectAnswer;
            quizToModify.Explanation = quiz.Explanation;
            quizToModify.Question = quiz.Question;
            return quiz;
        }
    }
}
