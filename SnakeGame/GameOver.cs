﻿using System;
using System.Threading;

namespace SnakeGame
{
    class GameOver
    {
        public void CheckIfWallHit(Snake snake)
        {
            const int MAP_TOP_MAX = 0, MAP_BOT_MAX = 23, MAP_LEFT_MAX = 10, MAP_RIGHT_MAX = 108;

            if
            (
                snake.SnakeHeadY == MAP_TOP_MAX ||
                snake.SnakeHeadY == MAP_BOT_MAX ||
                snake.SnakeHeadX == MAP_LEFT_MAX ||
                snake.SnakeHeadX == MAP_RIGHT_MAX
            )
            {
                DisplayGameOver(snake);
            }
        }
        public void CheckIfBodyHit(Snake snake)
        {
            for (int i = 1; i < snake.xRoutes.Count; i++)
            {
                if (snake.SnakeHeadX == snake.xRoutes[i] && snake.SnakeHeadY == snake.yRoutes[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(snake.SnakeHeadX, snake.SnakeHeadY);
                    Console.WriteLine("¤");
                    DisplayGameOver(snake);
                }
            }
        }
        private void DisplayGameOver(Snake snake)
        {
            Score score = new Score();
            Console.SetCursorPosition(11, 24);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game Over!");
            Console.ResetColor();
            Thread.Sleep(TimeSpan.FromMilliseconds(1500));

            score.DisplayTop10HighScore();
            score.HandleScore(snake);
            CheckIfUserRestartsGame();
        }
        private void CheckIfUserRestartsGame()
        {
            Start start = new Start();
            Console.SetCursorPosition(46, 19);
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
