using System;

namespace SnakeGame
{
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
}
