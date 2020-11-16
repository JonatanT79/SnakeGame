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
            snake.snakeBody.Add("¤");
            snake.xRoutes.Add(x);
            snake.yRoutes.Add(y);
            //int score = 0;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                if (keyInfo == ConsoleKey.UpArrow || keyInfo == ConsoleKey.W)
                {
                    y--;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.RightArrow || keyInfo == ConsoleKey.D)
                {
                    x++;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.DownArrow || keyInfo == ConsoleKey.S)
                {
                    y++;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake(x, y, keyInfo);
                }
                else if (keyInfo == ConsoleKey.LeftArrow || keyInfo == ConsoleKey.A)
                {
                    x--;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake(x, y, keyInfo);
                }

                gameOver.CheckIfWallHit(x, y);
                SnakeMayChangeDirection(ref keyInfo);
                RemovePrintedKey(y);
                FruitIsEaten(x, y, keyInfo, snake, fruit);
            }
        }
        private void UpdateSnakeRoute(int x, int y, Snake snake)
        {
            snake.SnakeTailX = snake.xRoutes[snake.snakeBody.Count - 1];
            snake.SnakeTailY = snake.yRoutes[snake.snakeBody.Count - 1];

            for (int i = snake.snakeBody.Count - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    snake.xRoutes[i] = snake.xRoutes[i - 1];
                    snake.yRoutes[i] = snake.yRoutes[i - 1];
                }
                else
                {
                    snake.xRoutes[0] = x;
                    snake.yRoutes[0] = y;
                }
            }
        }
        private void SnakeMayChangeDirection(ref ConsoleKey keyInfo)
        {
            DateTime beginWait = DateTime.Now;

            while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < 0.05)
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
        private void FruitIsEaten(int x, int y, ConsoleKey key, Snake snake, Fruit fruit)
        {
            if (x == Fruit.FruitXCoord && y == Fruit.FruitYCoord)
            {
                snake.ExtendSnake(x, y, key);
                //Console.WriteLine($"Score: {++score}");
                Console.SetCursorPosition(55, 24);
                Console.WriteLine($"SnakeLenght: {snake.snakeBody.Count}");
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
