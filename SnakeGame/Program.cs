using System;
using System.Xml.Schema;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
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
            ConsoleKeyInfo keyInfo;
            //Lägg till remove '@'

            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                if (keyInfo.Key == ConsoleKey.UpArrow || keyInfo.Key == ConsoleKey.W)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    y--;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow || keyInfo.Key == ConsoleKey.D)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    x++;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.S)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow || keyInfo.Key == ConsoleKey.A)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    x--;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
            }
        }
    }
}
