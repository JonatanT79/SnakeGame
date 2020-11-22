using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class GameEvents
    {
        public void CheckIfSnakeChangesDirection(ref ConsoleKey currentKey, Snake snake)
        {
            Validation validation = new Validation();
            DateTime beginWait = DateTime.Now;
            double snakeSpeed = 0.1;

            while (!Console.KeyAvailable && DateTime.Now.Subtract(beginWait).TotalSeconds < snakeSpeed)
            {

            }

            if (Console.KeyAvailable)
            {
                ConsoleKey newKey = Console.ReadKey().Key;

                if (validation.IsValidKey(newKey) && validation.IsNotOppositeKey(currentKey, newKey, snake))
                {
                    currentKey = newKey;
                }
            }
        }
        public void CheckIfFruitIsEaten(int headX, int headY, ConsoleKey key, Snake snake, Fruit fruit)
        {
            Start start = new Start();

            if (headX == Fruit.FruitXCoord && headY == Fruit.FruitYCoord)
            {
                snake.ExtendSnake(headX, headY, key);
                fruit.SpawnFruit(snake);
                start.DisplayCurrentScore(snake.snakeParts.Count - 1);
            }
        }
    }
}
