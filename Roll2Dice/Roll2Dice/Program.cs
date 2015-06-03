using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll2Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>
            {
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0},
                {9, 0},
                {10, 0},
                {11, 0},
                {12, 0},
            };
            int die1;
            int die2;
            int sum = 0;
            int rollCount = 0;
            Random rng = new Random();

            for (int i = 0; i < 100; i++)
            {
                rollCount++;
                die1 = rng.Next(1, 7);
                die2 = rng.Next(1, 7);

                sum = die1 + die2;

                counter[sum]++;
            }

            foreach (var item in counter)
            {
                Console.Write(item.Key + " ");
                Console.WriteLine(item.Value);
            }
            Console.ReadLine();
        }
    }
}
