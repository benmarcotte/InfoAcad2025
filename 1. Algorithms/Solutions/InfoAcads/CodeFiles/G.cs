using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    public class G (List<(int value, int weight)> items, int answer) : Question<G>
    {
        [JsonInclude]
        List<(int value, int weight)> items = items;
        [JsonInclude]
        int answer = answer;

        public static List<G> GenerateSolutions(int numberOfSolutions)
        {
            throw new NotImplementedException();
        }
    }
}
