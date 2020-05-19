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
            int BombCount = 0;
            //throw new NotImplementedException();
            for (int x= 0; x < Height; x++)
            {
                for (int y= 0; y < Width; y++)
                {
                    if (MineItems[x, y].IsBomb != true)
                    {
                        for (int i = x - 1; i < x + 2; i++)
                        {
                            for (int j = y - 1; j < y + 2; j++)
                            {
                                if (i < 0)
                                    i = 0;
                                if (j < 0)
                                    j = 0;
                                if (i >= Height)
                                    i = Height-1;
                                if (j >= Width)
                                    j = Width-1;

                                if (MineItems[i, j].IsBomb == true)
                                    BombCount++;
                            }
                        }
                        MineItems[x, y].NearBombsCount = BombCount;
                        BombCount = 0;
                    }
                }
            }
            
        }
    }
}
