using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    internal interface Question<T> where T : class
    {
        abstract static List<T> GenerateSolutions(int numberOfSolutions);
    }
}
