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
            const int X_STARTPOSITION = 54, Y_STARTPOSITION = 12;
            movement.MoveSnake(X_STARTPOSITION, Y_STARTPOSITION);
        }
    }
}

//BuggFixar / New Functions
//Fix bugg 'removeprintedkey'

//Fix when currentKey = leftarrow: snake can still go back if user press 'D'
//Sometimes the snaketail will be negative number and wall is disapearing sometimes (happens when snake is near wall)
//Remove "boost" when holding a key
//Fix so user can choose which direction to begin moving
//Fixa så att score egentligen ska vara i db
//When game is done add: highscore (test without db, then do it with db)
//Add restart function
