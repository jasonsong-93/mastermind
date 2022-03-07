﻿using System;

namespace Mastermind
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
            var colors = Enum.GetValues(typeof(Color)); // stores the enums into array type

            for (var i = 0; i < result.Length; i++)
                result[i] = (Color) colors.GetValue(_randomizer.GenerateRandomInt(colors.Length));
            return result;
        }
    }
}