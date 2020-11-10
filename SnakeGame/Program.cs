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
            //Remove this when movement is fixed
            //Console.WriteLine("Press any key to begin");
            //Console.ReadKey();
            //Console.Clear();
            Movement movement = new Movement();
            Map.CreateMap();
            Player.PlayerStartPosition();
            movement.MoveSnake(54, 12);
            //Exit Text
            Console.SetCursorPosition(0, 25);
        }
    }
    class Player
    {
        public static void PlayerStartPosition()
        {
            Console.SetCursorPosition(54, 12);
            Console.WriteLine("@");
        }
    }
}

//Spawn Apples at random places
//Extend Snake when apple is eaten
//TODO: Remove "boost" when holding a key