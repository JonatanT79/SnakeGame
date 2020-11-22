using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class Score
    {
        public void DisplayTop10HighScore()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Top 10 Highcore");
        }
        public void HandleScore()
        {
            Console.SetCursorPosition(46, 14);
            int score = 0;
            Console.WriteLine($"Your Score: {score}");

            if (score >= 0)
            {
                Console.WriteLine("New Highscore!");
                Console.Write("Enter your name: ");
                string userName = Console.ReadLine();
            }
        }
    }
}
