using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Question_1.Questions
{
    public class G((List<(int value, int weight)> objects, int weightLimit) query, int answer) : Question<G>
    {
        [JsonInclude]
        (List<(int value, int weight)> objects, int weightLimit) query = query;
        [JsonInclude]
        int answer = answer;

        public static List<G> GenerateSolutions(int numberOfSolutions)
        {
            List<G> returnal = [];

            int MAX_ITEMS = 20;
            int MAX_WEIGHT = 20;
            int MAX_VALUE = 50;

            var rand = new Random();

            for (int i = 0; i < numberOfSolutions; i++)
            {
                int nItems = rand.Next(MAX_ITEMS) + 1;
                int heaviestItem = 0;
                int weightLimit = 0;
                int answer = 0;
                List<(int value, int weight)> items = [];
                for (int j = 0; j < nItems; j++)
                {
                    int weight = rand.Next(MAX_WEIGHT) + 1;
                    if (weight > heaviestItem) heaviestItem = weight;
                    items.Add((rand.Next(MAX_VALUE) + 1, rand.Next(MAX_WEIGHT) + 1));
                }
                weightLimit = (int)(0.1 * rand.Next(5, 16) * heaviestItem);
                int currentWeight = 0;
                var t = new List<(int value, int weight)>(items);
                var query = (t, weightLimit);
                items.Sort(CompareItemsByValueDescending);
                foreach (var (value, weight) in items)
                {
                    if (weight + currentWeight <= weightLimit)
                    {
                        answer += value;
                        currentWeight += weight;
                    }
                }
                returnal.Add(new G(query, answer));
            }
            return returnal;
        }

        public static int CompareItemsByValueDescending((int value, int weight) item1, (int value, int weight) item2)
        {
            if (item1.value < item2.value) return 1;
            else if (item1.value > item2.value) return -1;
            else return 0;
        }
    }
}
