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
            string[,] arr = new string[5, 5] 
            { 
                { "0", "1", "1", "1", "0" }, 
                { "0", "1", "*", "1", "0" }, 
                { "1","3","3","2","0"},
                {"1","*","*","1","0" }, 
                { "1", "2", "2", "1", "0" }
            };

            for(int i=0;i<5;i++)
            {
                for(int j=0;j<5;j++)
                {
                    Console.Write("{0} ", arr[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
