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

        public List<string> snakeParts = new List<string>();
        public List<int> xRoutes = new List<int>();
        public List<int> yRoutes = new List<int>();

        public Snake()
        {
            SnakeHeadX = 54;
            SnakeHeadY = 12;
        }

        public void PrintSnake()
        {
            RemoveSnakeTail();
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < snakeParts.Count; i++)
            {
                Console.SetCursorPosition(xRoutes[i], yRoutes[i]);
                Console.WriteLine(snakeParts[i]);
            }
            Console.SetCursorPosition(0, 0);
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
        public void ExtendSnake()
        {
            snakeParts.Add("o");
            xRoutes.Add(0);
            yRoutes.Add(0);
        }
    }
}
