using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    public class A(int n, int answer) : Question<A>
    {
        [JsonInclude]
        public int n = n;
        [JsonInclude]
        public int answer = answer;

        public static List<A> GenerateSolutions(int numberOfSolutions)
        {
            var returnal = new List<A>();
            for (int i = 0; i < numberOfSolutions; i++)
            {
                returnal.Add(new A(i, ComputeSequence(i)));
            }
            return returnal;
        }

        static int ComputeSequence(int n)
        {
            if (n == 0 || n == 1) return 1;
            else return ComputeSequence(n - 2) * (ComputeSequence(n - 1) + 1);
        }
    }
}
