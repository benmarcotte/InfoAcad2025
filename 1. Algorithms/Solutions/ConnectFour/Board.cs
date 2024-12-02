using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class Board
    {
        public List<List<char>> board = [];
        int MAX_COLUMNS = 7;
        int HEIGHT = 6;

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
                throw new ArgumentOutOfRangeException("Column index out of bounds");
            if (board[columnIndex].Count == 6)
                throw new ArgumentOutOfRangeException("Column already full");
            board[columnIndex].Add(player);

            return CheckWin(columnIndex, player);
        }

        bool CheckWin(int columnIndex, char player)
        {
            //checkin verticals
            int counter = 0;
            foreach (char c in board[columnIndex])
            {
                if (c == player)
                {
                    counter++;
                    if (counter == 4)
                        return true;
                }
                else
                {
                    counter = 0;
                }
            }
            //checkin horizontals
            int rowIndex = board[columnIndex].Count - 1;


            //checkin diags

        }

    }
}
