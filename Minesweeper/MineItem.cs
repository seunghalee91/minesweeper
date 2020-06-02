using ReactiveUI;
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
        public bool IsCovered
        {
            get;
            set;
        } = true;

        public override string ToString()
        {
            if(IsCovered)
            {
                return " ";
            }

            if (IsBomb)
            {
                return "*";
            }
            return NearBombsCount.ToString();
        }
    }
}
