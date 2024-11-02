using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    public class E(List<(int amount, int faces)> dice, float answer) : Question<E>
    {
        [JsonInclude]
        public List<(int amount, int faces)> dice = dice;

        [JsonInclude]
        public float answer = answer;

        public static List<E> GenerateSolutions(int numberOfSolutions)
        {
            List<E> solutions = [];
            var rand = new Random();
            const int FACE_MAX = 100;
            const int MAX_DICE_OF_TYPE = 100;
            const int MAX_TYPES = 20;
            for (int i = 0; i < numberOfSolutions; i++)
            {
                int numberOfTypes = rand.Next(MAX_TYPES) + 1;
                List<(int amount, int faces)> dice = [];
                float answer = 0;
                for (int j = 0; j < numberOfTypes; j++)
                {
                    dice.Add((rand.Next(MAX_DICE_OF_TYPE) + 1, rand.Next(FACE_MAX) + 1));
                }
                foreach (var (amount, faces) in dice)
                {
                    answer += ((float)(1 + faces) / 2) * amount;
                }
                solutions.Add(new E(dice, answer));
            }
            return solutions;
        }
    }
}
