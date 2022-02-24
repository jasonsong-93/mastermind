using System;

namespace Mastermind.Input
{
    class ConsoleInput : IConsoleInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}