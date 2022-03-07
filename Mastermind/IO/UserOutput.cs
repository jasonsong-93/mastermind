using System;
using System.Collections.Generic;

namespace Mastermind.IO
{
    class UserOutput : IUserOutput
    {
        private readonly IConsoleIO _consoleIO;

        public UserOutput(IConsoleIO consoleIO)
        {
            _consoleIO = consoleIO;
        }

        public void DisplayIntroMessage()
        {
            _consoleIO.WriteLine("***WELCOME TO MASTERMIND!***");
        }

        public void DisplayFinished()
        {
            _consoleIO.WriteLine("AMAZING JOB");

        }

        public void DisplayIncorrect()
        {

            _consoleIO.WriteLine("Please try again");
        }

        public void DisplayResult(List<Color> result)
        {
            foreach (var color in result)
            {
                _consoleIO.Write(color + " ");
            }
        }
    }
}