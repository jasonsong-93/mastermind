using System;

namespace Mastermind.Input
{
    class UserInput : IUserInput
    {
        // Parses the user input and converts it to a Color[] 
        public Color[] PlayerGuess()
        {
            return new[] {Color.Black};
        }
    }
}