using System;
using System.Threading;

namespace SnakeGame
{
    class GameOver
    {
        public void CheckIfWallHit(int snakeXPosition, int snakeYPosition, Snake snake)
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
                DisplayGameOver(snake);
            }
        }
        public void CheckIfBodyHit(int headX, int headY, Snake snake)
        {
            for (int i = 1; i < snake.xRoutes.Count; i++)
            {
                if (headX == snake.xRoutes[i] && headY == snake.yRoutes[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(headX, headY);
                    Console.WriteLine("¤");
                    DisplayGameOver(snake);
                }
            }
        }
        private void DisplayGameOver(Snake snake)
        {
            Score score = new Score();
            Console.SetCursorPosition(10, 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.ResetColor();
            Thread.Sleep(TimeSpan.FromMilliseconds(2000));

            score.DisplayTop10HighScore();
            score.HandleScore(snake);
            CheckIfUserRestartsGame();
        }
        private void CheckIfUserRestartsGame()
        {
            Start start = new Start();
            Console.SetCursorPosition(46, 20);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Play Again? (Yes/No)");
            string input = Console.ReadLine().ToUpper();

            while (input != "YES" && input != "NO")
            {
                Console.WriteLine("You must enter either Yes or No");
                input = Console.ReadLine().ToUpper();
            }

            Console.ResetColor();

            if (input == "YES")
            {
                Console.Clear();
                start.StartGame();
            }
            else if (input == "NO")
            {
                Environment.Exit(0);
            }
        }
    }
}
