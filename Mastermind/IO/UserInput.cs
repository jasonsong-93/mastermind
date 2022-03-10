using System;
using System.Threading;

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

        public int GetValidMaxRounds()
        {
            var valid = false;
            var result = 0;
            while (!valid)
            {
                _userOutput.PromptUserForMaxRounds();
                var input = _consoleIO.ReadLine();
                if (!int.TryParse(input, out var numRounds) || !(numRounds > 0))
                {
                    _userOutput.DisplayInvalidRounds();
                }
                else
                {
                    valid = true;
                    result = numRounds;
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
                _userOutput.PromptUserForNumPegs();
                var input = _consoleIO.ReadLine();
                if (!int.TryParse(input, out var numPegs) || numPegs is not (4 or 6))
                {
                    _userOutput.DisplayInvalidNumPegs();
                }
                else
                {
                    valid = true;
                    result = numPegs;
                }
            }

            return result;
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
    }
}