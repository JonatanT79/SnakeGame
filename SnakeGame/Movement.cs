using System;

namespace SnakeGame
{
    class Movement
    {
        public void MoveSnake(Snake snake, Fruit fruit)
        {
            GameEvents gameEvents = new GameEvents();
            ConsoleKey currentKey = ConsoleKey.RightArrow;

            while (true)
            {
                if (currentKey == ConsoleKey.UpArrow || currentKey == ConsoleKey.W)
                {
                    snake.SnakeHeadY--;
                    UpdateSnakeRoute(snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.RightArrow || currentKey == ConsoleKey.D)
                {
                    snake.SnakeHeadX++;
                    UpdateSnakeRoute(snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.DownArrow || currentKey == ConsoleKey.S)
                {
                    snake.SnakeHeadY++;
                    UpdateSnakeRoute(snake);
                    snake.PrintSnake();
                }
                else if (currentKey == ConsoleKey.LeftArrow || currentKey == ConsoleKey.A)
                {
                    snake.SnakeHeadX--;
                    UpdateSnakeRoute(snake);
                    snake.PrintSnake();
                }

                gameEvents.ExecuteGameEvents(snake, fruit, ref currentKey);
            }
        }
        private void UpdateSnakeRoute(Snake snake)
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
                    snake.xRoutes[0] = snake.SnakeHeadX;
                    snake.yRoutes[0] = snake.SnakeHeadY;
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
