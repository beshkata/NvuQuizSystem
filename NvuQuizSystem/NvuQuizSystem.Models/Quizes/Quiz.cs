using Common.Guards;
using NvuQuizSystem.Models.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Models.Quizes
{
    public class Quiz
    {
        private readonly List<Question> questions;

        public Quiz(string name)
        {
            questions = new List<Question>();
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<Question> Questions => questions.AsReadOnly();

        public int QuestionsCount => questions.Count();

        public bool AddQuestion(Question question)
        {
            Guard.AgainstNull(question);
            questions.Add(question);
            return true;
        }

        public bool DeleteQuestion(Question question)
        {
            Guard.AgainstNull(question);
            if (questions.Contains(question))
            {
                questions.Remove(question);
                return true;
            }
            else
            {
                throw new ArgumentException($"Quiz {this.Name} does not contain such a question");
            }
        }

        public bool DeleteQuestion(string questionId)
        {
            Guard.AgainstNull(questionId);
            Question question = questions.FirstOrDefault(q => q.Id == questionId);

            if (question == null)
            {
                throw new ArgumentException($"There is no question with id {questionId} in quiz {this.Name}.");
            }

            questions.Remove(question);
            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);

            foreach (var question in questions)
            {
                sb.AppendLine(question.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
