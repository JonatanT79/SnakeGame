using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeGame
{
    class GameEvents
    {
        public void ExecuteGameEvents(Snake snake, Fruit fruit, ref ConsoleKey currentKey)
        {
            GameOver gameOver = new GameOver();
            Validation validation = new Validation();

            gameOver.CheckIfBodyHit(snake);
            gameOver.CheckIfWallHit(snake);
            CheckIfSnakeChangesDirection(snake, ref currentKey);
            CheckIfFruitIsEaten(snake, fruit);
            validation.RemovePrintedKey(snake.SnakeHeadY);
        }
        private void CheckIfSnakeChangesDirection(Snake snake, ref ConsoleKey currentKey)
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

                if (validation.IsValidKey(newKey) && validation.IsNotOppositeKey(snake, currentKey, newKey))
                {
                    currentKey = newKey;
                }
            }
        }
        private void CheckIfFruitIsEaten(Snake snake, Fruit fruit)
        {
            Start start = new Start();

            if (snake.SnakeHeadX == Fruit.FruitXCoord && snake.SnakeHeadY == Fruit.FruitYCoord)
            {
                snake.ExtendSnake();
                fruit.SpawnFruit(snake);
                start.DisplayCurrentScore(snake.snakeParts.Count - 1);
            }
        }
    }
}
