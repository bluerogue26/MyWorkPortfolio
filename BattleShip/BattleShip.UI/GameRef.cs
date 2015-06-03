using System;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using System.Linq;

namespace BattleShip.UI
{

        internal class GameRef
        {
            #region Properties

            public Board Player1 = new Board();
            private string _player1Name = "";

            public Board Player2 = new Board();
            private string _player2Name = "";


            private ShipDirection _shipDirection;
            private ShipType _shipType;

            private int _tempX;
            private int _tempY;
            private string _userInput;

            private bool _turn1 = true;

            #endregion

            public void ShowStartMenu()
            {
                Console.WriteLine("Welcome to Battleship!!");
                Console.WriteLine("Guess where your opponent has placed their ships and take shots");
                Console.Write("Press any key to start");
                Console.ReadKey();
                Console.Clear();

                Console.Write("Enter the name of player 1: ");
                _player1Name = Console.ReadLine();

                Console.Write("Enter the name of Player 2: ");
                _player2Name = Console.ReadLine();
            }

            public void PlaceShips()
            {

                if (_turn1)
                {
                    Player1 = new Board();
                }
                else
                {
                    Player2 = new Board();
                }

                Console.Clear();
                ShowBoard();
                PlaceShipsIntro();

                for (var i = 0; i < 5; i++)
                {

                    Enum.TryParse(Enum.GetName(typeof (ShipType), i), out _shipType);
                    ShipPlacement response;

                    do
                    {
                        GetUserInput(i);

                        var request = new PlaceShipRequest
                        {
                            Coordinate = new Coordinate(_tempX, _tempY),
                            Direction = _shipDirection,
                            ShipType = _shipType
                        };

                        response = _turn1 ? Player1.PlaceShip(request) : Player2.PlaceShip(request);

                        SharePlacementResponse(response);

                    } while (response != ShipPlacement.Ok);


                } 

                Console.Write("Press any key to clear the screen and move on... ");
                Console.ReadKey();
                Console.Clear();
                _turn1 = !_turn1;
            }

            private void GetUserInput(int i)
            {
                do
                {
                    Console.Write("Enter the coordinate to place the end of your {0}: ",
                        Enum.GetName(typeof (ShipType), i));

                    _userInput = Console.ReadLine().ToUpper();
                } while (!IsValid(_userInput));

                do
                {
                    Console.Write("Enter the direction of the ship (Up Down Left or Right): ");
                    _userInput = Console.ReadLine();

                    _userInput = Char.ToUpper(_userInput[0]) + _userInput.Substring(1).ToLower();
                } while (!(Enum.TryParse(_userInput, out _shipDirection)));
            }

            private static void SharePlacementResponse(ShipPlacement response)
            {
                switch (response)
                {
                    case ShipPlacement.Overlap:
                        Console.WriteLine("Two ships may not overlap.\n");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine("Your ship will not fit there.\n");
                        break;
                    case ShipPlacement.Ok:
                        Console.WriteLine("Ship successfully placed.\n");
                        break;
                }
            }

            private void PlaceShipsIntro()
            {
                if (_turn1)
                {
                    Console.WriteLine("Placing {0}'s ships...", _player1Name);
                }
                else
                {
                    Console.WriteLine("Placing {0}'s ships...", _player2Name);
                }

                Console.WriteLine(
                    "Carriers take up 5 spots in a line. Battleships take up 4. \nSubmarines and cruisers each take " +
                    "3. Destroyers take 2.");
                Console.WriteLine("Enter your coordinates following the pattern of B10\n\n");
                ShowBoard();
            }

            public bool IsValid(string s)
            {
                if (s.Length < 2) return false;

                switch (s[0])
                {
                    case 'A':
                    case 'B':
                    case 'C':
                    case 'D':
                    case 'E':
                    case 'F':
                    case 'G':
                    case 'H':
                    case 'I':
                    case 'J':
                    {
                        _tempX = Translator.TranslateX(s);
                        if (Int32.TryParse(s.Substring(1), out _tempY))
                            return true;
                        return false;
                    }
                }
                return false;
            }

            public void Play()
            {
                FireShotResponse response;

                do
                {
                    ShowBoard();

                    Console.WriteLine("{0}'s turn to take a shot!", _turn1 ? _player1Name : _player2Name);

                    do
                    {
                        Console.Write("Enter the coordinate you wish to fire at: ");
                        _userInput = Console.ReadLine();
                    } while (!IsValid(_userInput.ToUpper()));

                    response = (_turn1)
                        ? Player2.FireShot(new Coordinate(_tempX, _tempY))
                        : Player1.FireShot(new Coordinate(_tempX, _tempY));

                    ShareShotStatus(response);

                    if (response.ShotStatus == ShotStatus.Duplicate || response.ShotStatus == ShotStatus.Invalid)
                    {
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Press any key to clear the screen and switch players...");
                    Console.ReadKey();
                    Console.Clear();
                    _turn1 = !_turn1;

                } while (response.ShotStatus != ShotStatus.Victory);
            }

            private void ShareShotStatus(FireShotResponse response)
            {
                switch (response.ShotStatus)
                {
                    case ShotStatus.Invalid:
                        Console.WriteLine("That isn't a valid coordinate");
                        break;
                    case ShotStatus.Duplicate:
                        Console.WriteLine("You've already fired there!");
                        break;

                    case ShotStatus.Miss:
                        Console.WriteLine("You missed!");
                        break;
                    case ShotStatus.Hit:
                        Console.WriteLine("You hit a ship!");
                        break;
                    case ShotStatus.HitAndSunk:
                        Console.WriteLine("You sunk {1}'s {0}!", response.ShipImpacted,
                            (_turn1) ? _player2Name : _player1Name);
                        break;
                    case ShotStatus.Victory:
                        Console.WriteLine("You sunk the last ship! You win!");
                        break;
                }
            }

            public void ShowBoard()
            {
                Console.Clear();
                Board Player = (_turn1) ? Player2 : Player1;

                Console.WriteLine("         A\t B\t C\t D\t E\t F\t G\t H\t I\t J\n");
                Console.WriteLine("      _______________________________________________________________________________");
                Console.WriteLine("     |       |       |       |       |       |       |       |       |       |       |");
                for (int i = 1; i < 11; i++) //rows
                {
                    Console.Write("{0,-2}", i);
                    

                    for (int j = 1; j < 11; j++) // columns
                    {
                        Coordinate co = new Coordinate(j, i);
                        if (j == 10)
                        {
                            if (Player.ShotHistory.ContainsKey(co))
                            {
                                if (Player.ShotHistory[co] == ShotHistory.Hit)
                                {
                                    Console.Write("   |   ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("H");
                                    Console.ResetColor();
                                    Console.Write("   |");
                                }
                                else if (Player.ShotHistory[co] == ShotHistory.Miss)
                                {
                                    Console.Write("   |   ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("M");
                                    Console.ResetColor();
                                    Console.Write("   |");
                                }
                            }
                            else
                            {
                                Console.Write("   |   ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("~");
                                Console.ResetColor();
                                Console.Write("   |");
                            }
                        }
                        else
                        {
                            if (Player.ShotHistory.ContainsKey(co))
                            {
                                if (Player.ShotHistory[co] == ShotHistory.Hit)
                                {
                                    Console.Write("   |   ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("H");
                                }
                                else if (Player.ShotHistory[co] == ShotHistory.Miss)
                                {
                                    Console.Write("   |   ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("M");
                                }
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.Write("   |   ");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("~");
                                Console.ResetColor();
                            }
                        }
                    }
                    if (i == 10)
                    {
                        Console.Write("\n     |_______|_______|_______|_______|_______|_______|_______|_______|_______|_______|\n");
                    }
                    else
                    {
                        Console.Write("\n     |_______|_______|_______|_______|_______|_______|_______|_______|_______|_______|\n");
                        Console.Write("     |       |       |       |       |       |       |       |       |       |       |\n");
                    }
                }


                Console.WriteLine("\nReminder: Carriers are 5, Battleships are 4, Cruisers and Submarines are 3," +
                                  " and Destroyers are 2\n");
            }
    }
}