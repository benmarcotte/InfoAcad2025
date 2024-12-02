using Question_1.Questions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Question_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true };
            string path = "C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\1. Algorithms\\Solutions\\InfoAcads\\Question_1\\Jsons\\";



            //cant do more than 9
            var aFile = new StreamWriter(path + "A.json");
            aFile.Write(JsonSerializer.Serialize(A.GenerateSolutions(9), options));
            aFile.Close();

            var bFile = new StreamWriter(path + "B.json");
            bFile.Write(JsonSerializer.Serialize(B.GenerateSolutions(20), options));
            bFile.Close();

            //var cFile = new StreamWriter("C:\\Users\\Ben\\Downloads\\FichiersAcadInfo\\FichiersAcadInfo\\1. Algorithms\\Solutions\\Jsons\\C.json");
            //cFile.Write(JsonSerializer.Serialize(C.GenerateSolutions(0), options));
            //cFile.Close();

            var dFile = new StreamWriter(path + "D.json");
            dFile.Write(JsonSerializer.Serialize(D.GenerateSolutions(25), options));
            dFile.Close();

            var eFile = new StreamWriter(path + "E.json");
            eFile.Write(JsonSerializer.Serialize(E.GenerateSolutions(25), options));
            eFile.Close();

            var fFile = new StreamWriter(path + "F.json");
            fFile.Write(JsonSerializer.Serialize(F.GenerateSolutions(25), options));
            fFile.Close();

            var gFile = new StreamWriter(path + "G.json");
            gFile.Write(JsonSerializer.Serialize(G.GenerateSolutions(25), options));
            gFile.Close();

            var hFile = new StreamWriter(path + "H.json");
            hFile.Write(JsonSerializer.Serialize(H.GenerateSolutions(25), options));
            hFile.Close();

            var iFile = new StreamWriter(path + "I.json");
            iFile.Write(JsonSerializer.Serialize(I.GenerateSolutions(5), options));
            iFile.Close();
        }
    }
}
