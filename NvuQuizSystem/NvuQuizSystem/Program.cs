using NvuQuizSystem.Core.Controlers;
using NvuQuizSystem.Models.Answers;
using NvuQuizSystem.Models.Questions;
using NvuQuizSystem.Models.Quizes;
using NvuQuizSystem.Services.QuizCreatorService;
using NvuQuizSystem.Services.QuizVariantsCreatorService;
using NvuQuizSystem.Services.QuizVariantsOutputService;
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
            //try
            //{
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine(ex.Message);
            //}
            quiz = await quizCreator.CreateQuizAsync("Тест ЯХБЗ");
            creator = new QuizVariantsCreator(quiz);
            List<string> variants = creator.CreateVariants(90, 15);

            //Console.WriteLine(quiz.ToString());

            await QuizVariantsOutputTxt.VariantsOutputTxtAsync("Output.txt", variants, creator.VariantsCorrectAnswers);


        }

    }
}
