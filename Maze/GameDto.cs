using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class GameDto
    {
        public int playerRow { get; set; }
        public int playerCol { get; set; }
        public char[,] maze { get; set; }

        public Boolean gameWon { get; set; }

        public int goalRow { get; set; }
        public int goalCol { get; set; }



    }
}
