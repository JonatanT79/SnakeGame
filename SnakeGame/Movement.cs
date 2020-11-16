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
            snake.snakeParts.Add("¤");
            snake.xRoutes.Add(x);
            snake.yRoutes.Add(y);
            fruit.SpawnFruit();

            while (true)
            {
                gameOver.CheckIfBodyHit(x, y, snake);
                gameOver.CheckIfWallHit(x, y);

                if (keyInfo == ConsoleKey.UpArrow || keyInfo == ConsoleKey.W)
                {
                    y--;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }
                else if (keyInfo == ConsoleKey.RightArrow || keyInfo == ConsoleKey.D)
                {
                    x++;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }
                else if (keyInfo == ConsoleKey.DownArrow || keyInfo == ConsoleKey.S)
                {
                    y++;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }
                else if (keyInfo == ConsoleKey.LeftArrow || keyInfo == ConsoleKey.A)
                {
                    x--;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }

                CheckIfSnakeChangesDirection(ref keyInfo);
                RemovePrintedKey(y);
                CheckIfFruitIsEaten(x, y, keyInfo, snake, fruit);
            }
        }
        private void UpdateSnakeRoute(int x, int y, Snake snake)
        {
            SetSnakeTailCoords(snake);

            for (int i = snake.snakeParts.Count - 1; i >= 0; i--)
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
        private void SetSnakeTailCoords(Snake snake)
        {
            snake.SnakeTailX = snake.xRoutes[snake.snakeParts.Count - 1];
            snake.SnakeTailY = snake.yRoutes[snake.snakeParts.Count - 1];
        }
        private void CheckIfSnakeChangesDirection(ref ConsoleKey keyInfo)
        {
            DateTime beginWait = DateTime.Now;
            double snakeSpeed = 0.1;

            while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < snakeSpeed)
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
        private void CheckIfFruitIsEaten(int x, int y, ConsoleKey key, Snake snake, Fruit fruit)
        {
            if (x == Fruit.FruitXCoord && y == Fruit.FruitYCoord)
            {
                snake.ExtendSnake(x, y, key);
                fruit.SpawnFruit();
                Console.SetCursorPosition(55, 24);
                Console.WriteLine($"Score: {snake.snakeParts.Count}");
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
