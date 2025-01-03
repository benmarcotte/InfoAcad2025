using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cipher
{
    internal class Generator
    {
        public static void Main(string[] args)
        {
            string outputPath = "C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\2. Coding\\Cipher\\cipher.csv";
            string inputPath = "C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\2. Coding\\Cipher\\plaintext.csv";
            Generate(outputPath, inputPath);
        }

        public static void Generate(string outputPath, string inputPath)
        {
            int MAX_LENGTH = 127;
            int LETTERS = 26;
            int ASCII_MIN = 65;
            int ASCII_MAX = 90;

            var rand = new Random();

            var cipherFile = new StreamWriter(outputPath);
            var plaintextFile = new StreamReader(inputPath);
            for (int i = 0; i < 10000; i++)
            {
                string plaintext = "";
                string[] plaintextArray;
                string line = plaintextFile.ReadLine();
                if (line.Length < 2) continue;
                if (line[0] == '\"')
                {
                    if (line.Split('\"')[1] == "") continue;
                    plaintext = "\"" + line.Split('\"')[1] + "\"";
                }
                else
                {
                    plaintextArray = line.Split(',');
                    foreach (var str in plaintextArray[1..])
                    {
                        plaintext += str + ",";
                    }

                    try
                    {
                        plaintext = plaintext[..(plaintext.Length - 1)].ToString();
                    }
                    catch
                    {
                        i--;
                        continue;
                    }

                    if (plaintext.Length == 0)
                        plaintext = plaintextArray[0];
                }

                plaintext = Regex.Replace(plaintext, " {2,}", " ");
                plaintext = plaintext.Trim();

                if (plaintext[0..2] == "\" ") plaintext = plaintext.Remove(1, 1);
                
                int cipherKey = rand.Next(1, LETTERS);
                string ciphertext = "";
                foreach (char c in plaintext)
                {
                    if (Regex.IsMatch(c.ToString(), "[A-Za-z]"))
                    {
                        if (c >= 97 && c <= 122)
                            ciphertext += (char)(cipherKey + c > 122 ? cipherKey + c - 26 : cipherKey + c);
                        else
                            ciphertext += (char)(cipherKey + c > 90 ? cipherKey + c - 26 : cipherKey + c);
                    }
                    else 
                        ciphertext += c;
                }
                cipherFile.WriteLine($"{plaintext}, {ciphertext}");
            }
            cipherFile.Close();
        }
    }
}
