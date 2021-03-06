using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.QuizVariantsOutputService
{
    public class QuizVariantsOutputTxt : IQuizVariantsOutput
    {
        public async Task VariantsOutputTxtAsync(string path, 
            List<string> variants, 
            List<List<char>> VariantsCorrectAnswers)
        {
            StringBuilder sb = new StringBuilder();
            StreamWriter writer = new StreamWriter(path);

            using(writer)
            {
                foreach (var variant in variants)
                {
                    await writer.WriteLineAsync(variant);
                }

                for (int i = 0; i < VariantsCorrectAnswers.Count; i++)
                {
                    await writer.WriteLineAsync($"Вариант {i+1}");
                    sb = new StringBuilder();
                    for (int j = 0; j < VariantsCorrectAnswers[i].Count; j++)
                    {
                        sb.Append($"{j + 1}:{VariantsCorrectAnswers[i][j]}; ");
                    }
                    await writer.WriteLineAsync(sb.ToString());
                }
            }
        }
    }
}
