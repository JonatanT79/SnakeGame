using System;

namespace SnakeGame
{
    class Fruit
    {
        public static int FruitXCoord { get; set; }
        public static int FruitYCoord { get; set; }
        public void SpawnFruit()
        {
            Random rnd = new Random();
            FruitXCoord = rnd.Next(11, 108);
            FruitYCoord = rnd.Next(1, 22);
            Console.SetCursorPosition(FruitXCoord, FruitYCoord);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("O");
            Console.ResetColor();
        }
    }
}