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
            Map map = new Map();
            map.CreateMap();
            movement.MoveSnake();
        }
    }
}

//BuggFixar / New Functions
//Remove "boost" when holding a key

//Fixa så att score egentligen ska vara i db
//When game is done add: highscore (test without db, then do it with db)
//Fix so user can choose which direction to begin moving
//Add restart function
