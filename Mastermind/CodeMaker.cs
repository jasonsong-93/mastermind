using System;

namespace Mastermind;

public class CodeMaker : ICodeMaker
{
    private readonly IRandomizer _randomizer;

    public CodeMaker(IRandomizer randomizer)
    {
        _randomizer = randomizer;
    }

    public Color[] GetSolutionCode()
    {
    }
}