using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace SnakeGame
{
    class Snake
    {
        public int snakeLenght = 1;
        public ConsoleKey PrevKey { get; set; }
        public int PrevX { get; set; }
        public int PrevY { get; set; }
        public int SnakeHeadX { get; set; }
        public int SnakeHeadY { get; set; }
        public void SnakeStartPosition()
        {
            Console.SetCursorPosition(54, 12);
            Console.WriteLine("@");
        }

        public void PrintSnake(int x, int y, ConsoleKey currentKey)
        {
            const int SnakeMoved1Step = 1;

            if (currentKey == ConsoleKey.UpArrow)
            {
                CheckChangedDirectionBeforeRemovingSnake(x, y, currentKey);
                PrevX = x;
                PrevY = y - SnakeMoved1Step;

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
                PrevX = x + SnakeMoved1Step;
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
                PrevY = y + SnakeMoved1Step;

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
                PrevX = x - SnakeMoved1Step;
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
        public void CheckChangedDirectionBeforeRemovingSnake(int x, int y, ConsoleKey currentKey)
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
        public void RemoveSnake(int x, int y, ConsoleKey key)
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
        public bool SnakeChangedDirection(ConsoleKey currentKey, ConsoleKey previousKey)
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
