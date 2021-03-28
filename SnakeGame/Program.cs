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
            Start start = new Start();
            start.StartGame();
        }
    }
}

//BuggFixar / New Functions
//Clean code / Refactor
//Max 3 argument, en metod ska vara kort, regel 2 ännu kortare om det går
//Remove "boost" when holding a key
