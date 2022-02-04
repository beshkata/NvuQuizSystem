using NvuQuizSystem.Models.Answers;
using NvuQuizSystem.Models.Questions;
using NvuQuizSystem.Models.Quizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.QuizVariantsCreatorService
{
    public class QuizVariantsCreator
    {
        private Random random;
        public QuizVariantsCreator(Quiz quiz)
        {
            Quiz = quiz;
            VariantsCorrectAnswers = new List<List<char>>();
            random = new Random();
        }

        public Quiz Quiz { get; set; }

        public List<List<char>> VariantsCorrectAnswers { get; }


        public List<string> CreateVariants(int variantsNumber, int variantQuestionsCount)
        {
            if (variantQuestionsCount > Quiz.QuestionsCount)
            {
                throw new ArgumentException($"Number of variant's questions must be less or equal than {Quiz.QuestionsCount}");
            }

            List<string> variants = new List<string>();


            for (int i = 1; i <= variantsNumber; i++)
            {
                List<Question> questions = Quiz.Questions.ToList();
                List<string> usedQuestions = new List<string>();

                StringBuilder sb = new StringBuilder();
                List<char> currentVariantCorrectAnswers = new List<char>();
                sb.AppendLine($"Вариант {i}");
                sb.AppendLine("звание, три имена ...............................................................");

                for (int j = 1; j <= variantQuestionsCount; j++)
                {
                    Question question = questions[random.Next(0, Quiz.QuestionsCount)];

                    while (usedQuestions.Any(q => q == question.Id))
                    {
                        question = questions[random.Next(0, Quiz.QuestionsCount)];
                    }

                    usedQuestions.Add(question.Id);

                    sb.AppendLine($"{j}. {question.Body}");

                    List<Answer> answers = question.Answers.ToList();
                    List<string> usedAnswers = new List<string>();
                    for (int k = 0; k < question.AnswersCount; k++)
                    {

                        Answer answer = answers[random.Next(0, question.AnswersCount)];

                        while (usedAnswers.Any(a => a == answer.Id))
                        {
                            answer = answers[random.Next(0, question.AnswersCount)];
                        }

                        if (answer.IsCorrect)
                        {
                            currentVariantCorrectAnswers.Add((char)(97 + k));
                        }
                        usedAnswers.Add(answer.Id);

                        sb.AppendLine($"{(char)(97 + k)}. {answer.Body}");
                    }
                    sb.AppendLine(new string('-', 20));
                }

                variants.Add(sb.ToString());
                VariantsCorrectAnswers.Add(currentVariantCorrectAnswers);
            }


            return variants;
        }
    }
}
