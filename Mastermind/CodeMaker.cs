using System;

namespace Mastermind
{
    public class CodeMaker : ICodeMaker
    {
        private readonly IRandomizer _randomizer;
        private const int MaxNumColors = 4;

        public CodeMaker(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public Color[] GetSolutionCode()
        {
            var result = new Color[MaxNumColors];
            var colors = Enum.GetValues(typeof(Color)); // stores the enums into array type

            for (var i = 0; i < result.Length; i++)
                result[i] = (Color) colors.GetValue(_randomizer.GenerateRandomInt(colors.Length));
            return result;
        }
    }
}