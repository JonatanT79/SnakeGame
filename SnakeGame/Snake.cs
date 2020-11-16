using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Snake
    {
        public int SnakeHeadX { get; set; }
        public int SnakeHeadY { get; set; }
        public int SnakeTailX { get; set; }
        public int SnakeTailY { get; set; }

        public List<string> snakeBody = new List<string>();
        public List<int> xRoutes = new List<int>();
        public List<int> yRoutes = new List<int>();

        public void PrintSnake(int x, int y, ConsoleKey currentKey)
        {
            if (currentKey == ConsoleKey.UpArrow)
            {
                RemoveSnakeTail();

                for (int i = 0; i < snakeBody.Count; i++)
                {
                    Console.SetCursorPosition(xRoutes[i], yRoutes[i]);
                    Console.WriteLine(snakeBody[i]);
                }
            }
            else if (currentKey == ConsoleKey.RightArrow)
            {
                RemoveSnakeTail();

                for (int i = 0; i < snakeBody.Count; i++)
                {
                    Console.SetCursorPosition(xRoutes[i], yRoutes[i]);
                    Console.WriteLine(snakeBody[i]);
                }
            }
            else if (currentKey == ConsoleKey.DownArrow)
            {
                RemoveSnakeTail();

                for (int i = 0; i < snakeBody.Count; i++)
                {
                    Console.SetCursorPosition(xRoutes[i], yRoutes[i]);
                    Console.WriteLine(snakeBody[i]);
                }
            }
            else if (currentKey == ConsoleKey.LeftArrow)
            {
                RemoveSnakeTail();

                for (int i = 0; i < snakeBody.Count; i++)
                {
                    Console.SetCursorPosition(xRoutes[i], yRoutes[i]);
                    Console.WriteLine(snakeBody[i]);
                }
            }
        }
        private void RemoveSnakeTail()
        {
            Console.SetCursorPosition(SnakeTailX, SnakeTailY);
            Console.WriteLine(" ");
        }
        private void AddRouteForNewSnakeBodyIfExtended(int x, int y, ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                xRoutes.Add(x);
                yRoutes.Add(y + yRoutes.Count);
            }
            else if (key == ConsoleKey.RightArrow)
            {
                xRoutes.Add(x - xRoutes.Count);
                yRoutes.Add(y);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                xRoutes.Add(x);
                yRoutes.Add(y - yRoutes.Count);
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                xRoutes.Add(x + xRoutes.Count);
                yRoutes.Add(y);
            }
        }
        public void ExtendSnake(int x, int y, ConsoleKey key)
        {
            snakeBody.Add("o");
            AddRouteForNewSnakeBodyIfExtended(x, y, key);
        }
    }
}
