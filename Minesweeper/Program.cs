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
            var mineMap = new MineMap(5, 5);
            mineMap.GenerateBombs(3);
            mineMap.GenerateCountNearBombs();

            //Game 진행
            while (mineMap.CheckEndGame() == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write("{0}  ", mineMap.MineItems[i, j]);
                    }
                    Console.Write("\n\n");
                }
                Console.Write("Y, X:");

                var point = Console.ReadLine()
                    .Split(' ')
                    .Select(x => Convert.ToInt32(x))
                    .ToArray();

                mineMap.Click(point[0], point[1]);
                Console.Clear();

            }

            //결과 출력
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mineMap.MineItems[i, j].IsBomb == false)
                    {
                        Console.Write("{0}  ", mineMap.MineItems[i, j].NearBombsCount);
                    }
                    else
                    {
                        mineMap.MineItems[i, j].IsCovered = false;
                        Console.Write("{0}  ", mineMap.MineItems[i, j].ToString());
                    }
                }
                Console.Write("\n\n");
            }
            Console.WriteLine("Game Over");

            Console.ReadKey();
        }
    }
}
