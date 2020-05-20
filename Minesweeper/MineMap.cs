using System;
using System.Linq;

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

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    MineItems[i, j] = new MineItem();
                }
            }
        }

        public void GenerateCountNearBombs()
        {

            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Height; x++)

                {
                    if (MineItems[y, x].IsBomb) continue;


                    if (y - 1 >= 0)
                    {
                        if (x - 1 >= 0)
                        {
                            if (MineItems[y - 1, x - 1].IsBomb == true) MineItems[y, x].NearBombsCount++;
                        }

                        if (MineItems[y - 1, x].IsBomb == true) MineItems[y, x].NearBombsCount++;

                        if (x + 1 < Width)
                        {
                            if (MineItems[y - 1, x + 1].IsBomb == true) MineItems[y, x].NearBombsCount++;
                        }
                    }

                    if (y + 1 < Height)
                    {
                        if (x - 1 >= 0)
                        {
                            if (MineItems[y + 1, x - 1].IsBomb == true) MineItems[y, x].NearBombsCount++;
                        }

                        if (MineItems[y + 1, x].IsBomb == true) MineItems[y, x].NearBombsCount++;

                        if (x + 1 < Width)
                        {
                            if (MineItems[y + 1, x + 1].IsBomb == true) MineItems[y, x].NearBombsCount++;
                        }
                    }

                    if (x - 1 >= 0)
                    {
                        if (MineItems[y, x - 1].IsBomb == true) MineItems[y, x].NearBombsCount++;
                    }
                    if (x + 1 < Width)
                    {
                        if (MineItems[y, x + 1].IsBomb == true) MineItems[y, x].NearBombsCount++;
                    }
                }
            }
        }

        public void GenerateBombs(int v)
        {
            throw new NotImplementedException();
        }
    }
}
