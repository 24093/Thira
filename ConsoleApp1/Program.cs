using System;
using Alkl.Thira;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            game.Init();
            game.Test();

            Console.ReadKey();
        }
    }
}
