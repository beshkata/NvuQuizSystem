using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

using NvuQuizSystem.Models.Quizes;

namespace NvuQuizSystem.Services.QuizSaveService
{
    public class JsonSaveQuiz : ISaveQuiz
    {
        public async Task SaveAsync(Quiz quiz)
        {
            string fileName = $"{quiz.Name}.json";
            string jsonString = JsonSerializer.Serialize(quiz);

            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, quiz);
            await createStream.DisposeAsync();

            //await File.WriteAllTextAsync(fileName, jsonString);
        }
    }
}
