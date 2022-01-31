using NvuQuizSystem.Models.Quizes;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.QuizSaveService
{
    public interface ISaveQuiz
    {
        public Task SaveAsync(Quiz quiz);
    }
}
