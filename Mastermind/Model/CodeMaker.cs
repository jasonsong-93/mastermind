using System;
using Mastermind.Model.Interfaces;

namespace Mastermind.Model
{
    public class CodeMaker : ICodeMaker
    {
        private readonly IRandomizer _randomizer;

        public CodeMaker(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public Color[] GetSolutionCode(int numPegs)
        {
            var result = new Color[numPegs];
            var colors = Enum.GetValues(typeof(Color));
            for (var i = 0; i < result.Length; i++)
                result[i] = (Color) colors.GetValue(_randomizer.GenerateRandomInt(colors.Length));
            return result;
        }
    }
}