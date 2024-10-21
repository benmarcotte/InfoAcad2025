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
            var options = new JsonSerializerOptions { WriteIndented = true };

            var aFile = new StreamWriter("C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\1. Algorithms\\Solutions\\Jsons\\A.json");
            aFile.Write(JsonSerializer.Serialize(A.GenerateSolutions(), options));
            aFile.Close();

            var bFile = new StreamWriter("C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\1. Algorithms\\Solutions\\Jsons\\B.json");
            bFile.Write(JsonSerializer.Serialize(B.GenerateSolutions(), options));
            bFile.Close();

            var cFile = new StreamWriter("C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\1. Algorithms\\Solutions\\Jsons\\C.json");
            cFile.Write(JsonSerializer.Serialize(C.GenerateSolutions(), options));
            cFile.Close();
        }
    }
}
