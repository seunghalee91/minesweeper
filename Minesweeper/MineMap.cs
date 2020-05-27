using ReactiveUI;
using System;
using System.Linq;

namespace Minesweeper
{
    public class MineMap :ReactiveObject
    {
        public MineItem[,] MineItems { get; set; }
        public MineItem[] MineItems2 { get; set; }
         
        public int Width { get; }
        public int Height { get; }
        public int CountBombs { get; private set; }

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

        public void GenerateBombs(int value)
        {
            CountBombs = value;
            Random rand = new Random();
            int x, y;
            int bombCount = 0;

            do
            {
                x = rand.Next(0, Width);
                y = rand.Next(0, Height);
                if (MineItems[x, y].IsBomb == false)
                {
                    MineItems[x, y].IsBomb = true;
                    bombCount++;
                }
            } while (bombCount < value);
        }
        public void Click(int y, int x)
        {
            if (MineItems[y, x].IsCovered == false)
            {
                return;
            }

            MineItems[y, x].IsCovered = false;


            if (MineItems[y, x].NearBombsCount != 0)
            {
                return;
            }

            #region 주변 ItemsClick
            if (y - 1 >= 0)
                {
                    if (x - 1 >= 0)
                    {
                        Click(y - 1, x - 1);
                    }

                    Click(y - 1, x);

                    if (x + 1 < Width)
                    {
                        Click(y - 1, x + 1);
                    }
                }
            if (y + 1 < Height)
            {
                if (x - 1 >= 0)
                {
                    Click(y + 1, x - 1);
                }

                Click(y + 1, x);

                if (x + 1 < Width)
                {
                    Click(y + 1, x + 1);
                }
            }
            if (x - 1 >= 0)
            {
                Click(y, x - 1);
            }
            if (x + 1 < Width)
            {
                Click(y, x + 1);
            }
            #endregion
        }
        public bool CheckEndGame()
        {
            int itemsCount = (Width * Height) - CountBombs;

            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    if (MineItems[i, j].IsCovered == false)
                    {
                        itemsCount--;

                        if (MineItems[i, j].IsBomb == true)
                        {
                            return true;
                        }
                    }
                }
            }

            return itemsCount == 0;
        }
        public void ConvertMap()
        {
            int totalCount = Height * Width;
            MineItems2 = new MineItem[totalCount];
            
            for (int i = 0; i < totalCount; i++)
            {
                MineItems2[i] = MineItems[i / Height, i % Width];
            }
        }
    }
}
