﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1.Questions
{
    internal interface Question<T> where T : class
    {
        abstract static List<T> GenerateSolutions(int numberOfSolutions);
        abstract static void CorrectPythonSolution(string jsonPath, string pythonPath);
        //abstract static void CorrectSpecificSolution(string jsonPath);
    }
}
