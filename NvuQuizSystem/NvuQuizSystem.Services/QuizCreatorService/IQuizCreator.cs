using NvuQuizSystem.Models.Quizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.QuizCreatorService
{
    public interface IQuizCreator
    {
        //public Quiz CreateQuiz(string quizName);

        public Task<Quiz> CreateQuizAsync(string quizName);
    }
}
