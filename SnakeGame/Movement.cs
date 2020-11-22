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

            ConsoleKey currentKey = ConsoleKey.RightArrow;
            snake.snakeParts.Add("¤");
            snake.xRoutes.Add(x);
            snake.yRoutes.Add(y);
            fruit.SpawnFruit(snake);

            while (true)
            {
                gameOver.CheckIfBodyHit(x, y, snake);
                gameOver.CheckIfWallHit(x, y);

                if (currentKey == ConsoleKey.UpArrow || currentKey == ConsoleKey.W)
                {
                    y--;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.RightArrow || currentKey == ConsoleKey.D)
                {
                    x++;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.DownArrow || currentKey == ConsoleKey.S)
                {
                    y++;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.LeftArrow || currentKey == ConsoleKey.A)
                {
                    x--;
                    UpdateSnakeRoute(x, y, snake);
                    snake.PrintSnake();
                }

                CheckIfSnakeChangesDirection(ref currentKey, snake);
                RemovePrintedKey(y);
                CheckIfFruitIsEaten(x, y, currentKey, snake, fruit);
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
            snake.SnakeTailX = snake.xRoutes[snake.xRoutes.Count - 1];
            snake.SnakeTailY = snake.yRoutes[snake.yRoutes.Count - 1];
        }
        private void CheckIfSnakeChangesDirection(ref ConsoleKey currentKey, Snake snake)
        {
            DateTime beginWait = DateTime.Now;
            double snakeSpeed = 0.1;

            while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < snakeSpeed)
            {

            }

            if (Console.KeyAvailable)
            {
                ConsoleKey newKey = Console.ReadKey().Key;

                if (IsValidKey(newKey) && IsNotOppositeKey(currentKey, newKey, snake))
                {
                    currentKey = newKey;
                }
            }
        }
        private void CheckIfFruitIsEaten(int x, int y, ConsoleKey key, Snake snake, Fruit fruit)
        {
            if (x == Fruit.FruitXCoord && y == Fruit.FruitYCoord)
            {
                snake.ExtendSnake(x, y, key);
                fruit.SpawnFruit(snake);
                Console.SetCursorPosition(55, 24);
                Console.WriteLine($"Score: {snake.snakeParts.Count}");
            }
        }
        private bool IsNotOppositeKey(ConsoleKey currentKey, ConsoleKey newKey, Snake snake)
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
        private void RemovePrintedKey(int y)
        {
            const int VERTICAL_LENGHT = 23;
            for (int i = 0; i < VERTICAL_LENGHT; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(" ");
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
    }
}
