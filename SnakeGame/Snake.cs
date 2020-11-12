using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Snake
    {
        public int snakeLenght = 1;
        public void SnakeStartPosition()
        {
            Console.SetCursorPosition(54, 12);
            Console.WriteLine("@");
        }
        public void PrintWholeSnake(int x, int y, ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                Console.SetCursorPosition(x, y + snakeLenght);
                Console.WriteLine(" ");
                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    y++;
                }
            }
            else if(key == ConsoleKey.RightArrow)
            {
                Console.SetCursorPosition(x - snakeLenght, y);
                Console.WriteLine(" ");
                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    x--;
                }
            }
            else if(key == ConsoleKey.DownArrow)
            {
                Console.SetCursorPosition(x, y - snakeLenght);
                Console.WriteLine(" ");
                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    y--;
                }
            }
            else if(key == ConsoleKey.LeftArrow)
            {
                Console.SetCursorPosition(x + snakeLenght, y);
                Console.WriteLine(" ");
                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    x++;
                }
            }
        }
        public void ExtendSnake()
        {
            snakeLenght++;
        }
    }
}
