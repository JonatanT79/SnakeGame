using System;

namespace SnakeGame
{
    class Movement
    {
        public void MoveSnake(int x, int y)
        {
            Fruit fruit = new Fruit();
            GameOver gameOver = new GameOver();
            //TODO: fix so user can choose which direction to begin moving
            int score = 0;
            ConsoleKey keyInfo = ConsoleKey.UpArrow;

            fruit.SpawnFruit();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (keyInfo == ConsoleKey.UpArrow || keyInfo == ConsoleKey.W)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    y--;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo == ConsoleKey.RightArrow || keyInfo == ConsoleKey.D)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    x++;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo == ConsoleKey.DownArrow || keyInfo == ConsoleKey.S)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    y++;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                else if (keyInfo == ConsoleKey.LeftArrow || keyInfo == ConsoleKey.A)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" ");
                    x--;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("@");
                }
                DateTime beginWait = DateTime.Now;
                while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < 0.2) { }

                Console.ResetColor();
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    RemovePrintedKey(y);

                    if (IsValidKey(key))
                    {
                        keyInfo = key;
                    }
                }
                gameOver.WallHit(x, y);

                if (FruitIsEaten(x, y))
                {
                    Console.SetCursorPosition(55, 24);
                    Console.WriteLine("Score: " + ++score);
                    fruit.SpawnFruit();
                }
            }
        }
        public bool FruitIsEaten(int x, int y)
        {
            if (x == Fruit.FruitXCoord && y == Fruit.FruitYCoord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RemovePrintedKey(int y)
        {
            Console.SetCursorPosition(0, y + 1);
            Console.WriteLine(" ");
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
    }
}
