using System;

namespace SnakeGame
{
    class Map
    {
        public void CreateMap()
        {
            const int MAP_LEFT_MAX = 10, MAP_RIGHT_MAX = 108, HORIZONT_LENGHT = 99, VERTICAL_LENGHT = 23;
            Console.ForegroundColor = ConsoleColor.Red;

            //print horizontel
            for (int i = 0; i < HORIZONT_LENGHT; i++)
            {
                Console.SetCursorPosition(MAP_LEFT_MAX + i, 0);
                Console.Write("#");
            }
            for (int i = 0; i < HORIZONT_LENGHT; i++)
            {
                Console.SetCursorPosition(MAP_LEFT_MAX + i, VERTICAL_LENGHT);
                Console.Write("#");
            }

            //Print vertical
            for (int i = 0; i < VERTICAL_LENGHT; i++)
            {
                Console.SetCursorPosition(MAP_LEFT_MAX, i);
                Console.Write("#");
            }

            for (int i = 0; i < VERTICAL_LENGHT; i++)
            {
                Console.SetCursorPosition(MAP_RIGHT_MAX, i);
                Console.Write("#");
            }

            Console.ResetColor();
        }
    }
}
