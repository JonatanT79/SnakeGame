using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Snake
    {
        public int SnakeHeadX { get; set; }
        public int SnakeHeadY { get; set; }
        private int PrevX { get; set; }
        private int PrevY { get; set; }
        private ConsoleKey PrevKey { get; set; }

        public int snakeLenght = 1;

        public void PrintSnake(int x, int y, ConsoleKey currentKey)
        {
            const int SNAKE_MOVED_1_STEP = 1;

            if (currentKey == ConsoleKey.UpArrow)
            {
                CheckChangedDirectionBeforeRemovingSnake(x, y, currentKey);
                PrevX = x;
                PrevY = y - SNAKE_MOVED_1_STEP;

                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    y++;
                }
            }
            else if (currentKey == ConsoleKey.RightArrow)
            {
                CheckChangedDirectionBeforeRemovingSnake(x, y, currentKey);
                PrevX = x + SNAKE_MOVED_1_STEP;
                PrevY = y;

                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    x--;
                }
            }
            else if (currentKey == ConsoleKey.DownArrow)
            {
                CheckChangedDirectionBeforeRemovingSnake(x, y, currentKey);
                PrevX = x;
                PrevY = y + SNAKE_MOVED_1_STEP;

                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    y--;
                }
            }
            else if (currentKey == ConsoleKey.LeftArrow)
            {
                CheckChangedDirectionBeforeRemovingSnake(x, y, currentKey);
                PrevX = x - SNAKE_MOVED_1_STEP;
                PrevY = y;

                for (int i = 0; i < snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                    x++;
                }
            }

            PrevKey = currentKey;
        }
        private void CheckChangedDirectionBeforeRemovingSnake(int x, int y, ConsoleKey currentKey)
        {
            if (SnakeChangedDirection(currentKey, PrevKey))
            {
                RemoveSnake(PrevX, PrevY, PrevKey);
            }
            else
            {
                RemoveSnake(x, y, currentKey);
            }
        }
        private void RemoveSnake(int x, int y, ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                for (int i = 1; i <= snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y + i);
                    Console.WriteLine(" ");
                }
            }
            else if (key == ConsoleKey.RightArrow)
            {
                for (int i = 1; i <= snakeLenght; i++)
                {
                    Console.SetCursorPosition(x - i, y);
                    Console.WriteLine(" ");
                }
            }
            else if (key == ConsoleKey.DownArrow)
            {
                for (int i = 1; i <= snakeLenght; i++)
                {
                    Console.SetCursorPosition(x, y - i);
                    Console.WriteLine(" ");
                }
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                for (int i = 1; i <= snakeLenght; i++)
                {
                    Console.SetCursorPosition(x + i, y);
                    Console.WriteLine(" ");
                }
            }
        }
        private bool SnakeChangedDirection(ConsoleKey currentKey, ConsoleKey previousKey)
        {
            if ((currentKey != previousKey) && (previousKey != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ExtendSnake()
        {
            snakeLenght++;
        }
    }
}
