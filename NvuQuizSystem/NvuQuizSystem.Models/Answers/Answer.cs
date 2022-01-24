using System;

namespace NvuQuizSystem.Models.Answers
{
    public class Answer
    {
        public Answer(string body, bool isCorrect)
        {
            Id = Guid.NewGuid().ToString();
            Body = body;
            IsCorrect = isCorrect;
        }
        public string Id { get; set; }

        public string Body { get; set; }

        public bool IsCorrect { get; set; }

        public override string ToString()
        {
            return $"{Body} {IsCorrect}";
        }
    }
}
