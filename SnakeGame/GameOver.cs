using System;

namespace SnakeGame
{
    class GameOver
    {
        public void WallHit(int snakeXPosition, int snakeYPosition)
        {
            const int mapTopMax = 0, mapBotMax = 23, mapLeftMax = 10, mapRightMax = 108;
            if
            (
            snakeYPosition == mapTopMax ||
            snakeYPosition == mapBotMax ||
            snakeXPosition == mapLeftMax ||
            snakeXPosition == mapRightMax
            )
            {
                DisplayGameOver();
            }
        }
        private void DisplayGameOver()
        {
            Console.SetCursorPosition(0, 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over");
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
