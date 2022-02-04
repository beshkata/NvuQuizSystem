using NvuQuizSystem.Models.Answers;
using NvuQuizSystem.Models.Questions;
using NvuQuizSystem.Models.Quizes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.QuizCreatorService
{
    public class TxtQuizCreator : IQuizCreator
    {
        public TxtQuizCreator(string path)
        {
            Path = path;
        }
        public string Path { get; set; }

        public async Task<Quiz> CreateQuizAsync(string quizName)
        {
            StreamReader reader = new StreamReader(Path);

            Quiz quiz = new Quiz(quizName);

            string line = await reader.ReadLineAsync();

            Question question;

            Answer answer;

            using (reader)
            {
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }
                    line.Trim();
                    if (line.StartsWith("???"))
                    {
                        string questionBody = line.Remove(0, 3);
                        question = new Question(questionBody.Trim());

                        line = await reader.ReadLineAsync();
                        line.Trim();

                        while (line.StartsWith("???") == false)
                        {
                            line.Trim();
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }

                            if (line.StartsWith("!!!"))
                            {
                                string answerBody = line.Remove(0, 3);
                                answer = new Answer(answerBody.Trim(), true);
                            }
                            else
                            {
                                answer = new Answer(line, false);
                            }
                            question.AddAnswer(answer);
                            line = await reader.ReadLineAsync();
                            if (line == null)
                            {
                                break;
                            }
                            line.Trim();
                        }
                        if (question.IsValid())
                        {
                            quiz.AddQuestion(question);
                        }
                    }
                }
            }

            return quiz;
        }
    }
}
