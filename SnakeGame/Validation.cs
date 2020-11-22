using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Validation
    {
        public bool IsNotOppositeKey(ConsoleKey currentKey, ConsoleKey newKey, Snake snake)
        {
            if
            (
                (snake.snakeParts.Count != 1) &&
                (
                ((currentKey == ConsoleKey.LeftArrow || currentKey == ConsoleKey.A) && (newKey == ConsoleKey.D || newKey == ConsoleKey.RightArrow)) ||
                ((currentKey == ConsoleKey.RightArrow || currentKey == ConsoleKey.D) && (newKey == ConsoleKey.A || newKey == ConsoleKey.LeftArrow)) ||
                ((currentKey == ConsoleKey.UpArrow || currentKey == ConsoleKey.W) && (newKey == ConsoleKey.S || newKey == ConsoleKey.DownArrow)) ||
                ((currentKey == ConsoleKey.DownArrow || currentKey == ConsoleKey.S) && (newKey == ConsoleKey.W || newKey == ConsoleKey.UpArrow))
                )
            )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsValidKey(ConsoleKey key)
        {
            if
            (
                key != ConsoleKey.RightArrow &&
                key != ConsoleKey.UpArrow &&
                key != ConsoleKey.LeftArrow &&
                key != ConsoleKey.DownArrow &&
                key != ConsoleKey.D &&
                key != ConsoleKey.W &&
                key != ConsoleKey.A &&
                key != ConsoleKey.S
            )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RemovePrintedKey(int y)
        {
            const int VERTICAL_LENGHT = 23;
            for (int i = 0; i < VERTICAL_LENGHT; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(" ");
            }
        }
    }
}
