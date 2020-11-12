using System;

namespace SnakeGame
{
    class Movement
    {
        public void MoveSnake(int x, int y)
        {
            Snake snake = new Snake();
            Fruit fruit = new Fruit();
            GameOver gameOver = new GameOver();
            int score = 0;
            ConsoleKey keyInfo = ConsoleKey.RightArrow;

            fruit.SpawnFruit();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (keyInfo == ConsoleKey.UpArrow || keyInfo == ConsoleKey.W)
                {
                    y--;
                    snake.PrintWholeSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.RightArrow || keyInfo == ConsoleKey.D)
                {
                    x++;
                    snake.PrintWholeSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.DownArrow || keyInfo == ConsoleKey.S)
                {
                    y++;
                    snake.PrintWholeSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.LeftArrow || keyInfo == ConsoleKey.A)
                {
                    x--;
                    snake.PrintWholeSnake(x, y, keyInfo);
                }

                DateTime beginWait = DateTime.Now;
                while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < 0.3) { }

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
                    snake.ExtendSnake();
                    //Console.WriteLine($"Score: {++score}");
                    Console.SetCursorPosition(55, 24);
                    Console.WriteLine($"SnakeLenght: {snake.snakeLenght}");
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
