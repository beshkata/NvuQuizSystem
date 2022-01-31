using NvuQuizSystem.Models.Quizes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.OpenQuizService
{
    public class JsonOpenQuiz : IOpenQuiz
    {
        public async Task<Quiz> Open(string path)
        {
            string fileName = path;
            using FileStream openStream = File.OpenRead(fileName);
            Quiz quiz =
                await JsonSerializer.DeserializeAsync<Quiz>(openStream);

            return quiz;
        }
    }
}
