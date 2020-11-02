using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Schema;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Remove this when movement is fixed
            //Console.WriteLine("Press any key to begin");
            //Console.ReadKey();
            //Console.Clear();
            Movement movement = new Movement();
            Map.CreateMap();
            Player.PlayerStartPosition();
            movement.MoveSnake(54, 12);
            //Exit Text
            Console.SetCursorPosition(0, 25);
        }
    }
    class Map
    {
        public static void CreateMap()
        {
            //print horizontel
            for (int i = 0; i < 99; i++)
            {
                Console.SetCursorPosition(i + 10, 0);
                Console.Write("#");
            }
            for (int i = 0; i < 99; i++)
            {
                Console.SetCursorPosition(i + 10, 23);
                Console.Write("#");
            }

            //Print vertical
            for (int i = 0; i < 23; i++)
            {
                Console.SetCursorPosition(10, i);
                Console.Write("#");
            }

            for (int i = 0; i < 24; i++)
            {
                Console.SetCursorPosition(108, i);
                Console.Write("#");
            }
        }
    }
    class Player
    {
        public static void PlayerStartPosition()
        {
            Console.SetCursorPosition(54, 12);
            Console.WriteLine("@");
        }
    }
    class Movement
    {
        public void MoveSnake(int x, int y)
        {
            //TODO: fix so user can choose which direction to begin moving
            ConsoleKey keyInfo = ConsoleKey.LeftArrow;

            while (true)
            {
                if (keyInfo == ConsoleKey.UpArrow || keyInfo == ConsoleKey.W)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    y--;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo == ConsoleKey.RightArrow || keyInfo == ConsoleKey.D)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    x++;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo == ConsoleKey.DownArrow || keyInfo == ConsoleKey.S)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo == ConsoleKey.LeftArrow || keyInfo == ConsoleKey.A)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    x--;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }

                DateTime beginWait = DateTime.Now;
                while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < 0.2) { }

                //TODO: Remove "boost" when holding a key
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    if (IsValidKey(key))
                    {
                        keyInfo = key;
                    }
                }
            }
        }
        public bool IsValidKey(ConsoleKey key)
        {
            if
            (
                key != ConsoleKey.RightArrow &&
                key != ConsoleKey.UpArrow &&
                key != ConsoleKey.LeftArrow &&
                key != ConsoleKey.DownArrow &&
                key != ConsoleKey.D &&
                key != ConsoleKey.W &&
                key != ConsoleKey.A &&
                key != ConsoleKey.S
            )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
