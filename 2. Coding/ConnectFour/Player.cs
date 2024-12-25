using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal abstract class Player(char id)
    {
        public char id = id;
        public abstract int DoMove(Board board);
    }
}
