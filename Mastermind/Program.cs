using System;
using Mastermind.Input;
using Mastermind.Output;

namespace Mastermind
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // var rand = new Randomizer();
            // var ci = new ConsoleInput();
            // var ui = new UserInput(ci);
            // var maker = new CodeMaker(rand);
            // var breaker = new CodeBreaker(ui);
            // var ge = new GameEngine(breaker, maker);
            var gameState = new GameState();
            // ge.Run();
            Console.WriteLine("Hello World!");
        }
    }
}