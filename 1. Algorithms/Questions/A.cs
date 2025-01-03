using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Question_1.Questions
{
    public class A(int n, int answer) : Question<A>
    {
        [JsonInclude]
        public int n = n;
        [JsonInclude]
        public int answer = answer;
        static StringBuilder pythonOutput = null;

        public static List<A> GenerateSolutions(int numberOfSolutions)
        {
            var returnal = new List<A>();
            for (int i = 0; i < numberOfSolutions; i++)
            {
                returnal.Add(new A(i, ComputeSequence(i)));
            }
            return returnal;
        }

        public static void CorrectPythonSolution(string jsonPath, string pythonPath)
        {
            int correct;
            List<A> answers = JsonSerializer.Deserialize<List<A>>(jsonPath)!;
            Process pythonProcess = new();
            pythonProcess.StartInfo.FileName = pythonPath;
            pythonProcess.StartInfo.UseShellExecute = false;
            pythonProcess.StartInfo.RedirectStandardOutput = true;
            pythonOutput = new();
            pythonProcess.OutputDataReceived += pythonOutputHandler;

        }

        private static void pythonOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                // Add the text to the collected output.
                pythonOutput.Append(Environment.NewLine +
                    $"{outLine.Data}");
            }
        }

        static int ComputeSequence(int n)
        {
            if (n == 0 || n == 1) return 1;
            else return ComputeSequence(n - 2) * (ComputeSequence(n - 1) + 1);
        }
    }
}
