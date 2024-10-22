using InfoAcads.CodeFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InfoAcads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };

            //cant do more than 9
            var aFile = new StreamWriter("C:\\Users\\thebe\\Documents\\InfoAcad2025\\1. Algorithms\\Solutions\\InfoAcads\\Jsons\\A.json");
            aFile.Write(JsonSerializer.Serialize(A.GenerateSolutions(9), options));
            aFile.Close();

            var bFile = new StreamWriter("C:\\Users\\thebe\\Documents\\InfoAcad2025\\1. Algorithms\\Solutions\\InfoAcads\\Jsons\\B.json");
            bFile.Write(JsonSerializer.Serialize(B.GenerateSolutions(20), options));
            bFile.Close();

            //var cFile = new StreamWriter("C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\1. Algorithms\\Solutions\\Jsons\\C.json");
            //cFile.Write(JsonSerializer.Serialize(C.GenerateSolutions(0), options));
            //cFile.Close();

            var dFile = new StreamWriter("C:\\Users\\thebe\\Documents\\InfoAcad2025\\1. Algorithms\\Solutions\\InfoAcads\\Jsons\\D.json");
            dFile.Write(JsonSerializer.Serialize(D.GenerateSolutions(25), options));
            dFile.Close();
        }
    }
}
