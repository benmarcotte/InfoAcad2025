using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    public class I(int number, bool answer) : Question<I>
    {
        [JsonInclude]
        int number = number;
        [JsonInclude]
        public bool answer = answer;
        public static List<I> GenerateSolutions(int numberOfSolutions)
        {
            var returnal = new List<I>();
            int MAX_INT = 20;
            var rand = new Random();
            for (int i = 0; i < numberOfSolutions; i++)
            {
                int t = rand.Next(MAX_INT);
                returnal.Add(new I(t, t%2==0));
            }
            return returnal;
        }
    }
}
