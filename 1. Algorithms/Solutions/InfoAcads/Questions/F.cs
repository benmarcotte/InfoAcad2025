using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Question_1.Questions
{
    public class F(string word, bool isPalindrome) : Question<F>
    {
        [JsonInclude]
        public string word = word;
        [JsonInclude]
        public bool answer = isPalindrome;

        public static List<F> GenerateSolutions(int numberOfSolutions)
        {
            var rand = new Random();
            int MAX_LENGTH = 50;
            char[] ascii = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
            List<F> returnal = [];
            for (int i = 0; i < numberOfSolutions; i++)
            {
                bool pal = rand.Next(2) == 0 ? true : false;

                Stack<char> chars = [];

                int length = rand.Next(MAX_LENGTH) + 1;
                string str = "";
                for (int j = 0; j < length; j++)
                {
                    var c = ascii[rand.Next(ascii.Length)];
                    str += c;
                    chars.Push(c);
                }

                if (pal)
                {
                    if (rand.Next(2) == 0 && length > 1) chars.Pop();
                    while (chars.Count > 0)
                        str += chars.Pop();
                }
                else
                {
                    for (int j = 0; j < length; j++)
                    {
                        str += ascii[rand.Next(ascii.Length)];
                    }
                }
                returnal.Add(new F(str, pal));
            }
            return returnal;
        }
    }
}
