namespace ConnectFour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player red = new RedPlayer('r');
            Player blue = new BluePlayer('b');

            Player winner = blue;
            
            while (winner != red)
            {
                ConnectFour.PlayGame(new(), red, blue);
            }

            Console.WriteLine($"Main says {winner.id} won");
        }
    }

    internal class RedPlayer(char id) : Player(id)
    {
        public override int DoMove(Board board)
        {
            var rand = new Random();
            return rand.Next(1, Board.MAX_COLUMNS + 1);
        }
    }

    internal class BluePlayer(char id) : Player(id)
    {
        int counter = 0;
        public override int DoMove(Board board)
        {
            counter++;
            counter = (counter % Board.MAX_COLUMNS) + 1;
            return counter;
        }
    }
}