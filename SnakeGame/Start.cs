using System;
using System.Collections.Generic;
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
            Console.SetCursorPosition(94, 24);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Highscore: {100}");
        }
    }
}
