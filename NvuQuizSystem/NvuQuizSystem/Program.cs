using NvuQuizSystem.Core.Controlers;
using NvuQuizSystem.Models.Answers;
using NvuQuizSystem.Models.Questions;
using NvuQuizSystem.Models.Quizes;
using NvuQuizSystem.Services.OpenQuizService;
using NvuQuizSystem.Services.QuizCreatorService;
using NvuQuizSystem.Services.QuizSaveService;
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
            //quiz = await quizCreator.CreateQuizAsync("Тест НВП");



            //ISaveQuiz saveQuiz = new JsonSaveQuiz();
            //await saveQuiz.SaveAsync(quiz);
            IOpenQuiz openQuiz = new JsonOpenQuiz();
            quiz = await openQuiz.Open("Тест НВП.json");
            creator = new QuizVariantsCreator(quiz);
            List<string> variants = creator.CreateVariants(90, 20);
            QuizVariantsOutputTxt quizVariantsOutputTxt = new QuizVariantsOutputTxt();
            await quizVariantsOutputTxt.VariantsOutputTxtAsync($"{quiz.Name}Variants.txt", variants, creator.VariantsCorrectAnswers);

            //Console.WriteLine(quiz.ToString());

        }

    }
}
