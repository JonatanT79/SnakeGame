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
            Map.CreateMap();
            Player.PlayerStartPosition();
            movement.MoveSnake(54, 12);

            //Exit Text
            Console.SetCursorPosition(0, 25);
        }
    }
}

//Extend Snake when fruit is eaten
//TODO: Remove "boost" when holding a key
//When game is done add: highscore (test without db, then do it with db)
//Standard Conventions (variable name, access modifiers)