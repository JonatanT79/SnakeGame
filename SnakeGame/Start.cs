using SnakeGame.Data;
using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    class Start
    {
        public void StartGame()
        {
            Movement movement = new Movement();
            Map map = new Map();
            map.CreateMap();
            DisplayCurrentScore(0);
            DisplayTop1HighScore();
            Console.ResetColor();
            movement.MoveSnake();
        }
        public void DisplayCurrentScore(int snakeLenght)
        {
            Console.SetCursorPosition(54, 24);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Score: {snakeLenght}");
        }
        private void DisplayTop1HighScore()
        {
            HighScoreContext context = new HighScoreContext();
            var top1HighScore = context.HighScore
                .OrderByDescending(s => s.Score)
                .ToList()[0].Score;

            Console.SetCursorPosition(94, 24);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Top1 Highscore: {top1HighScore}");
        }
    }
}
