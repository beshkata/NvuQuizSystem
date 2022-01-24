using Common.Guards;
using NvuQuizSystem.Models.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Models.Questions
{
    public class Question
    {
        private readonly List<Answer> answers;

        public Question(string body)
        {
            answers = new List<Answer>();
            Id = Guid.NewGuid().ToString();
            Body = body;
        }

        public string Id { get; set; }

        public string Body { get; set; }

        public int AnswersCount => answers.Count();

        public IReadOnlyCollection<Answer> Answers => answers.AsReadOnly();

        public bool AddAnswer(Answer answer)
        {
            Guard.AgainstNull(answer);
            answers.Add(answer);
            return true;
        }

        public bool IsValid()
        {
            if (answers.Any(a => a.IsCorrect) && answers.Any(a => a.IsCorrect == false))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Body);
            foreach (var answer in answers)
            {
                stringBuilder.AppendLine(answer.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
