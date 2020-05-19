using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[,] arr = new MineItem[5, 5] 
            //{ 
            //    { "0", "1", "1", "1", "0" }, 
            //    { "0", "1", "*", "1", "0" }, 
            //    { "1","3","3","2","0"},
            //    {"1","*","*","1","0" }, 
            //    { "1", "2", "2", "1", "0" }
            //};


            MineItem[,] arr = new MineItem[5, 5]
            {
                { new MineItem { IsBomb = false, NearBombsCount = 0 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 0 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = true, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 3 }, new MineItem { IsBomb = false, NearBombsCount = 3 }, new MineItem { IsBomb = false, NearBombsCount = 2 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = true, NearBombsCount = 1 }, new MineItem { IsBomb = true, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
                { new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 2 }, new MineItem { IsBomb = false, NearBombsCount = 2 }, new MineItem { IsBomb = false, NearBombsCount = 1 }, new MineItem { IsBomb = false, NearBombsCount = 0 } },
            };


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    //Console.Write("{0} ", arr[i, j]);
                    Console.Write("{0} ", arr[i, j]);
                }
                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
