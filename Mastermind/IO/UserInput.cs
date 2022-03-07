using System;

namespace Mastermind.IO
{
    public class UserInput : IUserInput
    {
        private readonly IConsoleIO _consoleIO;
        private const int MaxValues = 4;

        public UserInput(IConsoleIO consoleIO)
        {
            _consoleIO = consoleIO;
        }

        public Color[] PlayerGuess()
        {
            var colorArray = new Color[MaxValues];
            for (var i = 0; i < MaxValues; ++i)
            {
                var successfullyAddedColor = false;
                while (!successfullyAddedColor)
                {
                    _consoleIO.WriteLine("Please enter a colour: ");
                    var validInput = Enum.TryParse(_consoleIO.ReadLine(), out Color color);
                    if (validInput)
                    {
                        colorArray[i] = color;
                        successfullyAddedColor = true;
                    }
                }
            }

            return colorArray;
        }

        public int ValidateNumCodePegs()
        {
            var result = 0;
            var valid = false;
            while (!valid)
            {
                _consoleIO.WriteLine("Would you like to play with 4 or 6 pegs?");
                var readInt = int.Parse(_consoleIO.ReadLine());
                if (readInt == 4 || readInt == 6)
                {
                    valid = true;
                    result = readInt;
                    _consoleIO.WriteLine("Starting the game with " + readInt + " pegs.");
                }
                else
                {
                    _consoleIO.WriteLine("Error: Invalid number of pegs, please try again.");
                }
            }

            return result;
        }

        public int GetValidMaxRounds()
        {
            var valid = false;
            var result = 0;
            while (!valid)
            {
                _consoleIO.WriteLine("Please enter an even number of rounds you would like to play!");
                var readInt = int.Parse(_consoleIO.ReadLine());
                if (readInt % 2 == 0)
                {
                    valid = true;
                    result = readInt;
                    _consoleIO.WriteLine("Starting the game with " + readInt + " rounds.");
                }
                else
                {
                    _consoleIO.WriteLine("Error: Invalid number of rounds, please try again.");
                }
            }

            return result;
        }
    }
}