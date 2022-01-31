using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.QuizVariantsOutputService
{
    public interface IQuizVariantsOutput
    {
        public Task VariantsOutputTxtAsync(string path,
    List<string> variants,
    List<List<char>> VariantsCorrectAnswers);

    }
}
