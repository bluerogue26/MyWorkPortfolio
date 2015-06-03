using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Utilities
{
    public static class GetUserInput
    {
        public static string GetInput(string prompt)
        {
            string input;

            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine(prompt);

                input = Console.ReadLine();
                if (input.Trim().Length > 0)
                    break;
            } while (true);

            return input;
        }

        public static string AlterUserInput(string prompt)
        {
            string input;

            Console.WriteLine("---------------------------");
            Console.WriteLine(prompt);

            input = Console.ReadLine();

            return input;
        }
    }
}
