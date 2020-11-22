using SnakeGame.Data;
using SnakeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    class Score
    {
        public void DisplayTop10HighScore()
        {
            HighScoreContext context = new HighScoreContext();
            Console.Clear();
            Console.SetCursorPosition(50, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Top 10 Highcore");

            var HighScoreTop10List = context.HighScore
                .OrderByDescending(s => s.Score)
                .Take(10)
                .ToList();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(49, 4);
            Console.WriteLine($"{"Name",-11} Score");

            int row = 5;
            foreach (var item in HighScoreTop10List)
            {
                Console.SetCursorPosition(49, row);
                Console.WriteLine($"{item.Name,-11} {item.Score}");
                row++;
            }
        }
        public void HandleScore(Snake snake)
        {
            HighScoreContext context = new HighScoreContext();

            Console.SetCursorPosition(50, 14);
            int score = snake.snakeParts.Count - 1;
            Console.WriteLine($"Your Score: {score}");
            int highScoreCount = context.HighScore.ToList().Count();
            int lowestHighScoreInTop10 = 0;

            if (highScoreCount >= 10)
            {
                lowestHighScoreInTop10 = context.HighScore
                .OrderByDescending(s => s.Score)
                .ToList()[10].Score;
            }
            else
            {
                lowestHighScoreInTop10 = context.HighScore
                .OrderByDescending(s => s.Score)
                .ToList()[highScoreCount - 1].Score;
            }

            if (score > lowestHighScoreInTop10)
            {
                AddNewHighScore(score);
                Console.Clear();
                DisplayTop10HighScore();
            }
        }
        private void AddNewHighScore(int score)
        {
            HighScoreContext context = new HighScoreContext();

            Console.WriteLine("New Highscore!");
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.WriteLine("You must enter a name");
                userName = Console.ReadLine();
            }

            HighScore highScore = new HighScore() { Name = userName, Score = score, Date = DateTime.Now };
            context.HighScore.Add(highScore);
            context.SaveChanges();
        }
    }
}
