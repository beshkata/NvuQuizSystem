using NvuQuizSystem.Models.Quizes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.OpenQuizService
{
    public interface IOpenQuiz
    {
        public Task<Quiz> Open(string path);
    }
}
