using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class MineMap
    {
        public MineItem[,] MineItems { get; set; }
        public int Width { get; }
        public int Height { get; }

        public MineMap(int width, int height)
        {
            Width = width;
            Height = height;

            MineItems = new MineItem[Width, Height];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    MineItems[i, j] = new MineItem();
                }
            }
        }

        public void GenerateCountNearBombs()
        {
            throw new NotImplementedException();
        }
    }
}
