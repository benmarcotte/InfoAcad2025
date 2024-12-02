using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Question_1.Questions
{
    public class B(int position, List<int> numbers, int answer) : Question<B>
    {
        [JsonInclude]
        public int position = position;
        [JsonInclude]
        public List<int> numbers = numbers;
        [JsonInclude]
        public int answer = answer;

        public static List<B> GenerateSolutions(int numberOfSolutions)
        {
            List<B> solution = [];
            var rand = new Random();
            List<int> lengths = [];
            for (int i = 0; i < numberOfSolutions; i++)
            {
                lengths.Add(rand.Next(100) + 1);
            }
            List<(int pos, List<int> nums)> queries = [];
            foreach (int length in lengths)
            {
                List<int> list = [];
                for (int j = 0; j < length; j++)
                {
                    while (true)
                    {
                        int p = rand.Next(1000000);
                        if (!list.Contains(p))
                        {
                            list.Add(p);
                            break;
                        }
                    }
                }
                queries.Add((rand.Next(list.Count) + 1, list)); // + 1 because position is 1-based ("nth smallest position")

            }

            foreach (var (pos, nums) in queries)
            {
                var sorted = new List<int>(nums);
                sorted.Sort();
                solution.Add(new B(pos, nums, sorted[pos - 1])); // reversing the +1
            }
            return solution;
        }
    }
}
