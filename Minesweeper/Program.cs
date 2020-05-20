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

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} ", mineMap.MineItems[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
