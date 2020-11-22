using System;

namespace SnakeGame
{
    class Movement
    {
        public void MoveSnake()
        {
            Snake snake = new Snake();
            Fruit fruit = new Fruit();
            GameEvents gameEvents = new GameEvents();
            GameOver gameOver = new GameOver();
            Validation validation = new Validation();

            ConsoleKey currentKey = ConsoleKey.RightArrow;
            snake.snakeParts.Add("¤");
            snake.xRoutes.Add(snake.SnakeHeadX);
            snake.yRoutes.Add(snake.SnakeHeadY);
            fruit.SpawnFruit(snake);

            while (true)
            {
                gameOver.CheckIfBodyHit(snake.SnakeHeadX, snake.SnakeHeadY, snake);
                gameOver.CheckIfWallHit(snake.SnakeHeadX, snake.SnakeHeadY, snake);

                if (currentKey == ConsoleKey.UpArrow || currentKey == ConsoleKey.W)
                {
                    snake.SnakeHeadY--;
                    UpdateSnakeRoute(snake.SnakeHeadX, snake.SnakeHeadY, snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.RightArrow || currentKey == ConsoleKey.D)
                {
                    snake.SnakeHeadX++;
                    UpdateSnakeRoute(snake.SnakeHeadX, snake.SnakeHeadY, snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.DownArrow || currentKey == ConsoleKey.S)
                {
                    snake.SnakeHeadY++;
                    UpdateSnakeRoute(snake.SnakeHeadX, snake.SnakeHeadY, snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.LeftArrow || currentKey == ConsoleKey.A)
                {
                    snake.SnakeHeadX--;
                    UpdateSnakeRoute(snake.SnakeHeadX, snake.SnakeHeadY, snake);
                    snake.PrintSnake();
                }

                gameEvents.CheckIfSnakeChangesDirection(ref currentKey, snake);
                validation.RemovePrintedKey(snake.SnakeHeadY);
                gameEvents.CheckIfFruitIsEaten(snake.SnakeHeadX, snake.SnakeHeadY, currentKey, snake, fruit);
            }
        }
        private void UpdateSnakeRoute(int headX, int headY, Snake snake)
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
                    snake.xRoutes[0] = headX;
                    snake.yRoutes[0] = headY;
                }
            }
        }
        private void SetSnakeTailCoords(Snake snake)
        {
            snake.SnakeTailX = snake.xRoutes[snake.xRoutes.Count - 1];
            snake.SnakeTailY = snake.yRoutes[snake.yRoutes.Count - 1];
        }
    }
}
