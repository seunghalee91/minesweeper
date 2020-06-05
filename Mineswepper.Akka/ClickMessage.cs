using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Akka
{
    public class ClickMessage
    {
        public ClickMessage(int y, int x)
        {
            Y = y;
            X = x;
        }
        public int Y { get; set; }
        public int X { get; set; }
    }
}
