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
//Remove "boost" when holding a key
