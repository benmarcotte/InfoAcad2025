using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class Board
    {
        public List<List<char>> grid = [];
        public const int MAX_COLUMNS = 7;
        public const int HEIGHT = 6;
        public int decisiveMove = -1;

        public Board()
        {
            for(int i = 0; i < MAX_COLUMNS; i++)
            {
                grid.Add(new List<char>());
            }
        }

        /// <summary>
        /// Receives and processes a move into the board. Throws an error if the move is illegal.
        /// </summary>
        /// <param name="column"></param>
        /// <param name="player"></param>
        /// <returns>True if the move just won, false otherwise</returns>
        public bool ReceiveMove(int column, char player)
        {
            int columnIndex = column - 1;
            if (column < 1 || column > 7)
            {
                decisiveMove = columnIndex;
                throw new ArgumentOutOfRangeException("Column index out of bounds");
            }
            if (grid[columnIndex].Count == 6)
            {
                decisiveMove = columnIndex;
                throw new ArgumentOutOfRangeException("Column already full");
            }
            grid[columnIndex].Add(player);

            return CheckWin(columnIndex, player);
        }

        /// <summary>
        /// Checks if the topmost token played at the specified column is winning.
        /// </summary>
        /// <param name="columnIndex">The column to check with the new token</param>
        /// <param name="player">The player designation of the new token</param>
        /// <returns></returns>
        bool CheckWin(int columnIndex, char player)
        {
            //checking vertical
            int counter = 0;
            foreach (char c in grid[columnIndex])
            {
                if (c == player)
                {
                    counter++;
                    if (counter == 4)
                    {
                        decisiveMove = columnIndex;
                        return true;
                    }
                }
                else
                {
                    counter = 0;
                }
            }
            counter = 0;
            
            //checking horizontal
            int rowIndex = grid[columnIndex].Count - 1;

            for (int i = 0; i < MAX_COLUMNS; i++)
            {
                if (rowIndex < grid[i].Count)
                {
                    if (grid[i][rowIndex] == player)
                    {
                        counter++;
                        if (counter == 4)
                        {
                            decisiveMove = columnIndex;
                            return true;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                else
                {
                    counter = 0;
                }
            }
            counter = 0;

            //checkin diags
            int column = columnIndex - (HEIGHT - grid[columnIndex].Count);
            int row = HEIGHT - 1;
            while (column < MAX_COLUMNS - 1 && row >= 0)
            {
                if (column >= 0)
                {
                    if (row < grid[column].Count)
                    {
                        if (grid[column][row] == player)
                        {
                            counter++;
                            if (counter == 4)
                            {
                                decisiveMove = columnIndex;
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                column++;
                row--;
            }

            counter = 0;
            column = columnIndex + (HEIGHT - grid[columnIndex].Count);
            row = HEIGHT - 1;
            while (column >= 0 && row >= 0)
            {
                if (column < MAX_COLUMNS)
                {
                    if (row < grid[column].Count)
                    {
                        if (grid[column][row] == player)
                        {
                            counter++;
                            if (counter == 4)
                            {
                                decisiveMove = columnIndex;
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                column--;
                row--;
            }

            return false;
        }

        public bool IsFull()
        {
            foreach (var column in grid)
            {
                if (column.Count < HEIGHT)
                {
                    return false;
                }
            }
            return true;
        }
        public void PrintBoard()
        {
            for (int i = HEIGHT - 1; i >= 0; i--)
            {
                for (int j = 0; j < MAX_COLUMNS; j++)
                {
                    try
                    {
                        Console.Write(grid[j][i]);
                    }
                    catch
                    {
                        Console.Write('0');
                    }
                }
                Console.Write('\n');
            }
            Console.Write('\n');
        }
    }
}
