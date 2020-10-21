using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Map.CreateMap();
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
                Console.WriteLine("#");
            }
        }
    }
}
