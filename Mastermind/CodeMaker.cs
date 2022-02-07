using System;
using static Mastermind.Constants;

namespace Mastermind
{
    public class CodeMaker : ICodeMaker
    {
        private readonly IRandomizer _randomizer;

        public CodeMaker(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public Color[] GetSolutionCode()    // randomly generates an array with 4 colours
        {
            var result = new Color[ColoursToSelect];
            var colors = Enum.GetValues(typeof(Color)); // stores the enums into array type

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (Color) colors.GetValue(_randomizer.GenerateRandomInt(colors.Length));
            }
            return result;
        }
    }
}