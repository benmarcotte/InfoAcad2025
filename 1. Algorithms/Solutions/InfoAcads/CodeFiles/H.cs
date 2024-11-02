using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    public class H (int number, int answer) : Question<H>
    {
        [JsonInclude]
        public int number = number;
        [JsonInclude]
        public int answer = answer;

        public static List<H> GenerateSolutions(int numberOfSolutions)
        {
            List<H> returnal = [];
            var rand = new Random();
            int MAX_NUMBER = 100000; //one billion

            for(int i = 0; i < numberOfSolutions; i++)
            {
                int query = (rand.Next(1, MAX_NUMBER)/rand.Next(1, 7))+3;
                for (int j = 2; j <= query; j++)
                {
                    if (query % j == 0)
                    {
                        returnal.Add(new H(query, j));
                        break;
                    }
                }
            }
            return returnal;
        }
    }
}
