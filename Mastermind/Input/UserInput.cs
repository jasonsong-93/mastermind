using System;

namespace Mastermind.Input
{
    public class UserInput : IUserInput
    {
        private readonly IConsoleInput _consoleInput;
        private const int MaxValues = 4;
        public UserInput(IConsoleInput consoleInput)
        {
            _consoleInput = consoleInput;
        }
        public Color[] PlayerGuess()
        {
            var colorArray = new Color[MaxValues];
            for (var i = 0; i < MaxValues; ++i)
            {
                var userInput = _consoleInput.ReadLine(); 
                var inputIsDefinedAndValid = Enum.TryParse(_consoleInput.ReadLine(), out Color color) && Enum.IsDefined(typeof(Color),userInput);
                if (inputIsDefinedAndValid)
                {
                    colorArray[i] = color;
                }
            }
            return colorArray;
        }

        public int ValidateNumCodePegs()
        {
            throw new NotImplementedException();
        }

        public int ValidateMaxRounds()
        {
            throw new NotImplementedException();
        }
    }
}