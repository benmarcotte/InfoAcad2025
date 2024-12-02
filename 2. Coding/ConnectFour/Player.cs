using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal interface Player
    {
        abstract int DoMove(Board board);
    }
}
