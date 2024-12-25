using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class ConnectFour(Board board, Player red, Player blue)
    {
        Board board = board;
        Player red = red;
        Player blue = blue;

        public static Player PlayGame(Board board, Player red, Player blue)
        {
            bool winnerDeclared = false;
            Player currentPlayer = red;

            while (!winnerDeclared)
            {
                try
                {
                    winnerDeclared = board.ReceiveMove(currentPlayer.DoMove(board), currentPlayer.id);
                }
                catch
                {
                    winnerDeclared = true;
                    Console.Write($"{currentPlayer} made an illegal move at column {board.decisiveMove}, ");
                    if (currentPlayer == red) currentPlayer = blue;
                    else if (currentPlayer == blue) currentPlayer = red;
                }
                if (winnerDeclared) 
                { 
                    Console.WriteLine($"{currentPlayer} won at {board.decisiveMove}");
                    board.PrintBoard();
                    return currentPlayer;
                }
                if (currentPlayer == red) currentPlayer = blue;
                else if (currentPlayer == blue) currentPlayer = red;

                if (board.IsFull())
                {
                    winnerDeclared = true;
                    Console.WriteLine("draw");
                    board.PrintBoard();
                    return new DrawPlayer('d');
                }
            }
            Console.WriteLine("Exhaustive draw");
            board.PrintBoard();
            return new DrawPlayer('d');
        }

        internal class DrawPlayer(char id) : Player(id)
        {
            public override int DoMove(Board board)
            {
                return -1;
            }
        }
    }
}
