using System;

namespace Mastermind.IO
{
    public class UserInput : IUserInput
    {
        private readonly IConsoleIO _consoleIO;
        private readonly IUserOutput _userOutput;
        private const int MaxValues = 4;

        public UserInput(IConsoleIO consoleIO, IUserOutput userOutput)
        {
            _consoleIO = consoleIO;
            _userOutput = userOutput;
        }

        public Color[] PlayerGuess()
        {
            var colorArray = new Color[MaxValues];
            for (var i = 0; i < MaxValues; ++i)
            {
                var successfullyAddedColor = false;
                while (!successfullyAddedColor)
                {
                    _userOutput.PromptUserForColor();
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



        public int GetValidMaxRounds()
        {
            var valid = false;
            var result = 0;
            while (!valid)
            {
                _userOutput.PromptUserForMaxRounds();
                var input = _consoleIO.ReadLine();
                if (Int32.TryParse(input, out var numRounds))
                {
                    valid = true;
                    result = numRounds;
                    _consoleIO.WriteLine("");
                }
                else
                {
                    _consoleIO.WriteLine("Error: Invalid number of rounds, please try again.");
                }
            }
            return result;
        }
        
        public int ValidateNumCodePegs()
        {
            var result = 0;
            var valid = false;
            while (!valid)
            {
                _consoleIO.WriteLine("Would you like to play with 4 or 6 pegs? (pegs are the total number of colours you need to guess)");
                var readInt = int.Parse(_consoleIO.ReadLine());
                if (readInt == 4 || readInt == 6)
                {
                    valid = true;
                    result = readInt;
                    _consoleIO.WriteLine("Starting the game with " + readInt + " pegs.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    _consoleIO.WriteLine("Error: Invalid number of pegs, please try again.");
                    Console.ResetColor();
                }
            }
            return result;
        }
    }
}