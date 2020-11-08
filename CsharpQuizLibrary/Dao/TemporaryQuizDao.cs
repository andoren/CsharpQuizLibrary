using CsharpQuizLibrary.Dao.Interfaces;
using CsharpQuizLibrary.Models;
using CsharpQuizLibrary.Models.Exceptions.QuizExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpQuizLibrary.Dao
{
     public class TemporaryQuizDao : IQuizDao
    {
  
        private static readonly Random rnd = new Random();
        private static List<Quiz> tempDb = new List<Quiz>() {
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
            if (tempDb.Where(quiz=> quiz.Question.ToLower().Equals(newQuiz.Question.ToLower())).FirstOrDefault() != null) {
                throw new DuplicateQuizException($"This question has been added to the DB already:  {newQuiz.Question}");
            }
            else {
                newQuiz.Id = tempDb.Count + 1;
                tempDb.Add(newQuiz);
                return tempDb.Last();
            }
           
        }

        public bool DeleteQuiz(int quizId)
        {
            Quiz quizToRemove = GetQuizById(quizId);
            tempDb.Remove(quizToRemove);
            return true;
        }

        public Quiz GetQuizById(int id)
        {
            Quiz quiz = tempDb.Where(quiz => quiz.Id == id).FirstOrDefault();
            if (quiz == null) throw new QuizNotFoundException($"Quiz cannot be found by this ID: {id}");
            else return quiz;
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

            Quiz quizToModify = GetQuizById(quiz.Id);
            quizToModify.Answers = quiz.Answers;
            quizToModify.CorrectAnswer= quiz.CorrectAnswer;
            quizToModify.Explanation = quiz.Explanation;
            if (!quizToModify.Question.Equals(quiz.Question)) {
                if (tempDb.Where(q => q.Id != quiz.Id && q.Question.ToLower().Equals(quiz.Question.ToLower())).FirstOrDefault() != null)
                {
                    throw new DuplicateQuizException($"This question has been added to the DB already:  {quiz.Question}");
                }
                quizToModify.Question = quiz.Question;
            }
            
            return quiz;
        }
    }
}
