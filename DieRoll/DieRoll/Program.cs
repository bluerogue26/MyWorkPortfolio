using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DieRoll
{
    class Program
    {
        static void Main(string[] args)
        {
            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int count5 = 0;
            int count6 = 0;
            int dieRoll;
            int rollCount = 0;
            Random rng = new Random();

            for (int i = 0; i < 100; i++)
            {
                rollCount++;
                dieRoll = rng.Next(1, 7);
                if (dieRoll == 1)
                {
                    count1++;
                }
                else if (dieRoll == 2)
                {
                    count2++;
                }
                else if (dieRoll == 3)
                {
                    count3++;
                }
                else if (dieRoll == 4)
                {
                    count4++;
                }
                else if (dieRoll == 5)
                {
                    count5++;
                }
                else
                {
                    count6++;
                }
            }
            Console.WriteLine("Out of {0} rolls, there were \n{1} ones \n{2} twos \n{3} threes \n{4} fours \n{5} fives \n{6} sixes", rollCount, count1, count2, count3, count4, count5, count6);
            Console.ReadLine();
        }
    }
}
