using System;
using Mastermind.IO.Interfaces;

namespace Mastermind.IO
{
    internal class ConsoleIO : IConsoleIO
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public void Write(string s)
        {
            Console.Write(s);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}