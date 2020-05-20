using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public partial class MineItem 
    {
        public bool IsBomb
        {
            get;
            set;
        }
        public int NearBombsCount
        {
            get;
            set;
        }

        public override string ToString()
        {
            if (IsBomb)
            {
                return "*";
            }
            return NearBombsCount.ToString();
        }
    }
}
