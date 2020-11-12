using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Xml.Schema;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Movement movement = new Movement();
            Snake snake = new Snake();
            Map.CreateMap();
            snake.SnakeStartPosition();
            movement.MoveSnake(54, 12);
        }
    }
}

//Fix extend snake bugg
//Standard Conventions (variable name, access modifiers)
//fix so user can choose which direction to begin moving
//Remove "boost" when holding a key
//When game is done add: highscore (test without db, then do it with db)