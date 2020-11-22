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

            Console.WriteLine($"Name       Score");

            foreach (var item in HighScoreTop10List)
            {
                Console.WriteLine($"{item.Name}        {item.Score}");
            }
        }
        public void HandleScore(Snake snake)
        {
            HighScoreContext context = new HighScoreContext();
            int index = context.HighScore.ToList().Count();
            int lowestHighScoreInTop10 = context.HighScore.ToList()[index - 1].Score;

            Console.SetCursorPosition(46, 14);
            int score = snake.snakeParts.Count - 1;
            Console.WriteLine($"Your Score: {score}");

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
