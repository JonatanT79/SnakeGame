using System;
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
            Map.CreateMap();
            Player.PlayerStartPosition();
            Movement.MoveSnake(54, 12);
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
        public static void MoveSnake(int x, int y)
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

                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey().Key;
                }
            }
        }
    }
}
