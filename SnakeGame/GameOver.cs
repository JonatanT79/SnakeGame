using System;

namespace SnakeGame
{
    class GameOver
    {
        public void CheckIfWallHit(int snakeXPosition, int snakeYPosition)
        {
            const int MAP_TOP_MAX = 0, MAP_BOT_MAX = 23, MAP_LEFT_MAX = 10, MAP_RIGHT_MAX = 108;

            if
            (
                snakeYPosition == MAP_TOP_MAX ||
                snakeYPosition == MAP_BOT_MAX ||
                snakeXPosition == MAP_LEFT_MAX ||
                snakeXPosition == MAP_RIGHT_MAX
            )
            {
                DisplayGameOver();
            }
        }
        public void CheckIfBodyHit(int x, int y, Snake snake)
        {
            for (int i = 1; i < snake.xRoutes.Count; i++)
            {
                if((x == snake.xRoutes[i] && y == snake.yRoutes[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("¤");
                    DisplayGameOver();
                }
            }
        }
        private void DisplayGameOver()
        {
            Console.SetCursorPosition(0, 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
