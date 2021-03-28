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
            Snake snake = new Snake();
            Fruit fruit = new Fruit();

            map.CreateMap();
            DisplayCurrentScore(0);
            DisplayTop1HighScore();
            PrepareGameBeforeMovement(snake, fruit);
            movement.MoveSnake(snake, fruit);
        }
        public void DisplayCurrentScore(int snakeLenght)
        {
            Console.SetCursorPosition(51, 24);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Score: {snakeLenght}");
        }
        private void DisplayTop1HighScore()
        {
            HighScoreContext context = new HighScoreContext();
            var top1HighScore = context.HighScore
                .OrderByDescending(s => s.Score)
                .ThenByDescending(d => d.Date)
                .ToList()[0];

            Console.SetCursorPosition(82, 24);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"#1 Name: {top1HighScore.Name}, Score: {top1HighScore.Score}");
        }
        private void PrepareGameBeforeMovement(Snake snake, Fruit fruit)
        {
            snake.snakeParts.Add("¤");
            snake.xRoutes.Add(snake.SnakeHeadX);
            snake.yRoutes.Add(snake.SnakeHeadY);
            fruit.SpawnFruit(snake);
        }
    }
}
