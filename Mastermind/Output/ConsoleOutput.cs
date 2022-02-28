using System;

namespace Mastermind.Output;

class ConsoleOutput : IConsoleOutput
{
    public void WriteLine(string s)
    {
        Console.WriteLine(s);
    }
}