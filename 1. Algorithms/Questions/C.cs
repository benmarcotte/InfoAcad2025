using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1.Questions
{
    public class C(List<Node> nodes, int answer) : Question<C>
    {
        List<Node> nodes = nodes;
        int answer = answer;

        public static List<C> GenerateSolutions(int numberOfSolutions)
        {
            var returnal = new List<C>();
            int MAX_NODES = 20;
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
                        d.Add(Math.Sqrt(node.position.x - other.position.x ^ 2 + (node.position.y - other.position.y) ^ 2));
                    }
                    distances.Add(d);
                }


            }
            return null;
        }
    }

    public class Node((int x, int y) position)
    {
        public (int x, int y) position = position;
    }

}
