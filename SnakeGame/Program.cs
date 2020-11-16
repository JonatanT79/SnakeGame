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
//Add Gameover if snake hits its own body
//Fix bugg with wasd
//Fix bugg 'removeprintedkey'
//Add if: if snakehead = fruit x & y coord;
//fix so user can choose which direction to begin moving
//Remove "boost" when holding a key
//When game is done add: highscore (test without db, then do it with db)