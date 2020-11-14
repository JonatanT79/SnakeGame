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
            ConsoleKey keyInfo = ConsoleKey.RightArrow;
            fruit.SpawnFruit();
            //int score = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (keyInfo == ConsoleKey.UpArrow || keyInfo == ConsoleKey.W)
                {
                    y--;
                    snake.PrintSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.RightArrow || keyInfo == ConsoleKey.D)
                {
                    x++;
                    snake.PrintSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.DownArrow || keyInfo == ConsoleKey.S)
                {
                    y++;
                    snake.PrintSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.LeftArrow || keyInfo == ConsoleKey.A)
                {
                    x--;
                    snake.PrintSnake(x, y, keyInfo);
                }

                gameOver.CheckIfWallHit(x, y);
                SnakeMayChangeDirection(ref keyInfo);
                RemovePrintedKey(y);
                FruitIsEaten(x, y, snake, fruit);
            }
        }
        private void SnakeMayChangeDirection(ref ConsoleKey keyInfo)
        {
            DateTime beginWait = DateTime.Now;

            while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < 5)
            {

            }

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (IsValidKey(key))
                {
                    keyInfo = key;
                }
            }
        }
        private void FruitIsEaten(int x, int y, Snake snake, Fruit fruit)
        {
            if (x == Fruit.FruitXCoord && y == Fruit.FruitYCoord)
            {
                snake.ExtendSnake();
                //Console.WriteLine($"Score: {++score}");
                Console.SetCursorPosition(55, 24);
                Console.WriteLine($"SnakeLenght: {snake.snakeLenght}");
                fruit.SpawnFruit();
            }
        }
        private bool IsValidKey(ConsoleKey key)
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
        private void RemovePrintedKey(int y)
        {
            Console.SetCursorPosition(0, y + 1);
            Console.WriteLine(" ");
        }
    }
}
