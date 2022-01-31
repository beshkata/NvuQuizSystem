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
        //private readonly List<Answer> answers;

        public Question(string body)
        {
            Answers = new List<Answer>();
            Id = Guid.NewGuid().ToString();
            Body = body;
        }

        public string Id { get; set; }

        public string Body { get; set; }

        public int AnswersCount => Answers.Count();

        //public IReadOnlyCollection<Answer> Answers => answers.AsReadOnly();

        public ICollection<Answer> Answers { get; set; }

        public bool AddAnswer(Answer answer)
        {
            Guard.AgainstNull(answer);
            Answers.Add(answer);
            return true;
        }

        public bool IsValid()
        {
            if (Answers.Any(a => a.IsCorrect) && Answers.Any(a => a.IsCorrect == false))
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
            foreach (var answer in Answers)
            {
                stringBuilder.AppendLine(answer.ToString());
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
