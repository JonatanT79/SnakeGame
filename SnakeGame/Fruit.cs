﻿using System;

namespace SnakeGame
{
    class Fruit
    {
        public static int FruitXCoord { get; set; }
        public static int FruitYCoord { get; set; }

        public void SpawnFruit(Snake snake)
        {
            Random rnd = new Random();
            FruitXCoord = rnd.Next(11, 108);
            FruitYCoord = rnd.Next(1, 23);

            while (snake.xRoutes.Contains(FruitXCoord) && snake.yRoutes.Contains(FruitYCoord))
            {
                FruitXCoord = rnd.Next(11, 108);
                FruitYCoord = rnd.Next(1, 23);
            }

            Console.SetCursorPosition(FruitXCoord, FruitYCoord);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O");
            Console.ResetColor();
        }
    }
}