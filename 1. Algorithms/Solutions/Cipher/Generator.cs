using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cipher
{
    internal class Generator
    {
        public static void Main(string[] args)
        {
            string path = "C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\1. Algorithms\\Solutions\\Cipher\\ciphers.csv";
            Generate(path);
        }

        public static void Generate(string path)
        {
            int MAX_LENGTH = 127;
            int LETTERS = 26;
            int ASCII_MIN = 65;
            int ASCII_MAX = 90;

            var rand = new Random();

            var cipherFile = new StreamWriter(path);
            for (int i = 0; i < 10000; i++)
            {
                int length = rand.Next(MAX_LENGTH) + 1;
                string plaintext = "";
                for (int j = 0; j < length; j++)
                    plaintext += (char)rand.Next(ASCII_MIN, ASCII_MAX + 1);
                int cipherKey = rand.Next(1, LETTERS + 1);
                string ciphertext = "";
                foreach (char c in plaintext)
                {
                    ciphertext += (char)(cipherKey + c > 90 ? cipherKey + c - 26 : cipherKey + c);
                }
                cipherFile.WriteLine($"{plaintext}, {ciphertext}");
            }
            cipherFile.Close();
        }
    }
}
