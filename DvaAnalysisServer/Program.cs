using DvaCore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DvaAnalysisServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server");
            Listener listener = new Listener();
            listener.SetupServer();

            Console.ReadKey();
        }
    }
}
