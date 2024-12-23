using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Question_1.Questions
{
    public class C(List<Node> nodes, double answer) : Question<C>
    {
        [JsonInclude]
        List<Node> nodes = nodes;
        [JsonInclude]
        double answer = answer;

        public static List<C> GenerateSolutions(int numberOfSolutions)
        {
            var returnal = new List<C>();
            int MAX_NODES = 12;
            int MAX_AREA = 100;

            var rand = new Random();

            for (int i = 0; i < numberOfSolutions; i++)
            {
                var nodes = new List<Node>();
                int nNodes = rand.Next(MAX_NODES) + 1;
                for (int j = 0; j < nNodes; j++)
                {
                    nodes.Add(new Node((rand.Next(MAX_AREA), rand.Next(MAX_AREA))));
                }
                var distances = new List<List<double>>();
                foreach (var node in nodes)
                {
                    var d = new List<double>();
                    foreach (var other in nodes)
                    {
                        d.Add(Math.Sqrt(((node.position.x - other.position.x) * (node.position.x - other.position.x)) + ((node.position.y - other.position.y) * (node.position.y - other.position.y))));
                    }
                    distances.Add(d);
                }

                returnal.Add(new C(nodes, Math.Round(GetShortestDistance(distances, 0, [0], 0), 2))); 
            }

            return returnal;
        }
        static double GetShortestDistance(List<List<double>> distances, double currentDistance, List<int> visitedIndeces, int currentIndex)
        {
            double shortestDistance = double.MaxValue;
            for (int i = 0; i < distances.Count; i++)
            {
                if (!visitedIndeces.Contains(i))
                {
                    List<int> newVisited = [];
                    foreach (int index in visitedIndeces) newVisited.Add(index);
                    newVisited.Add(i);
                    double newShort = GetShortestDistance(distances, currentDistance + distances[currentIndex][i], newVisited, i);
                    if (shortestDistance > newShort) shortestDistance = newShort;
                }
            }
            if (visitedIndeces.Count == distances.Count) return currentDistance + distances[currentIndex][0];
            return shortestDistance;
        }
    }

    public class Node((int x, int y) position)
    {
        [JsonInclude]
        public (int x, int y) position = position;
    }


}
