using System;
using Mastermind.Input;

namespace Mastermind
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rand = new Randomizer();
            var ui = new UserInput();
            var maker = new CodeMaker(rand);
            var breaker = new CodeBreaker(ui);
            var ge = new GameEngine(breaker, maker);
            ge.Run();
            Console.WriteLine("Hello World!");
        }
    }
}