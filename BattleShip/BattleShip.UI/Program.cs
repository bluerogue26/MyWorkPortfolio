using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 55;

            GameRef game = new GameRef();

            game.ShowStartMenu();

            do
            {
                game.PlaceShips(); 

                game.PlaceShips(); 

                game.Play();

                if (!PlayAgain())
                    break;
            } while (true);
        }

        static bool PlayAgain()
        {
            string answer;

            Console.Clear();

            do
            {
                Console.Write("Would you like to play again? Y/N : ");
                answer = Console.ReadLine().ToUpper();
            } while (!(answer == "Y" || answer == "N"));

            if (answer == "Y")
                return true;
            return false;
        }
    }
}
