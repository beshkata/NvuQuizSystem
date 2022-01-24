using NvuQuizSystem.Core.Controlers;
using NvuQuizSystem.Models.Answers;
using NvuQuizSystem.Models.Questions;
using NvuQuizSystem.Models.Quizes;
using NvuQuizSystem.Services.QuizCreatorService;
using NvuQuizSystem.Services.QuizVariantsCreatorService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NvuQuizSystem
{
    class Program
    {

        static async Task Main()
        {
            IQuizCreator quizCreator = new TxtQuizCreator("input.txt");
            Quiz quiz;
            QuizVariantsCreator creator;
            try
            {
                quiz = await quizCreator.CreateQuizAsync("MyQuiz");
                creator = new QuizVariantsCreator(quiz);
                List<string> variants = creator.CreateVariants(5, 3);

                //Console.WriteLine(quiz.ToString());

                for (int i = 0; i < variants.Count; i++)
                {
                    Console.WriteLine(variants[i]);
                    Console.WriteLine(string.Join(", ", creator.VariantsCorrectAnswers[i]));
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
