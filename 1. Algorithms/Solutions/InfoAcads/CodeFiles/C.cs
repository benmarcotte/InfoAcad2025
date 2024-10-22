using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoAcads.CodeFiles
{
    public class C(Sudoku sudoku, bool isValidAnswer) : Question<C>
    {
        Sudoku sudoku = sudoku;
        bool isValidAnswer = isValidAnswer;

        public static List<C> GenerateSolutions(int numberOfSolutions)
        {
            throw new NotImplementedException();
        }
    }

    public class Sudoku
    {
        List<List<int>> rows;
        List<List<int>> colums;
        List<List<int>> sectors;

        public enum SudokuConstructorOptions
        {
            Valid,
            Random
        }

        public Sudoku(SudokuConstructorOptions option, int density)
        {
            if(option == SudokuConstructorOptions.Valid)
            {
                GenerateValid(density);
            }
            else
            {
                GenerateRandom(density);
            }
        }

        private void GenerateValid(int density)
        {
            throw new NotImplementedException();
        }

        public void GenerateRandom(int density)
        {
            
        }

    }
}
