using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Snake
    {
        public int SnakeTailX { get; set; }
        public int SnakeTailY { get; set; }

        public List<string> snakeParts = new List<string>();
        public List<int> xRoutes = new List<int>();
        public List<int> yRoutes = new List<int>();

        public void PrintSnake()
        {
            RemoveSnakeTail();
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < snakeParts.Count; i++)
            {
                Console.SetCursorPosition(xRoutes[i], yRoutes[i]);
                Console.WriteLine(snakeParts[i]);
            }

            Console.ResetColor();
        }
        private void RemoveSnakeTail()
        {
            if ((SnakeTailY > 0 && SnakeTailY < 23) && (SnakeTailX > 10 && SnakeTailX < 108))
            {
                Console.SetCursorPosition(SnakeTailX, SnakeTailY);
                Console.WriteLine(" ");
            }
        }
        private void AddRouteForNewSnakeBody(int x, int y, ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
            {
                xRoutes.Add(x);
                yRoutes.Add(y + yRoutes.Count);
            }
            else if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
            {
                xRoutes.Add(x - xRoutes.Count);
                yRoutes.Add(y);
            }
            else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
            {
                xRoutes.Add(x);
                yRoutes.Add(y - yRoutes.Count);
            }
            else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
            {
                xRoutes.Add(x + xRoutes.Count);
                yRoutes.Add(y);
            }
        }
        public void ExtendSnake(int x, int y, ConsoleKey key)
        {
            snakeParts.Add("o");
            AddRouteForNewSnakeBody(x, y, key);
        }
    }
}
