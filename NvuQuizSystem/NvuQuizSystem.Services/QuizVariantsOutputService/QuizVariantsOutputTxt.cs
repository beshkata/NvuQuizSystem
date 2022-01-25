using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NvuQuizSystem.Services.QuizVariantsOutputService
{
    public class QuizVariantsOutputTxt
    {
        public static async Task VariantsOutputTxtAsync(string path, 
            List<string> variants, 
            List<List<char>> VariantsCorrectAnswers)
        {
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
                    await writer.WriteLineAsync(string.Join(", ", VariantsCorrectAnswers[i]));
                }
            }
        }
    }
}
