using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind;

public class CodeBreaker : ICodeBreaker
{
    private readonly IUserInput _userInput;
    public List<Attempt> Attempts { get; set; }

    public CodeBreaker(IUserInput userInput)
    {
        _userInput = userInput;
    }


    // Order is important
    public bool CodeBroken(Color[] solution)
    {
        var guess = _userInput.PlayerGuess();
        var result = checker.GetResult();
        Attempts.Add(guess, result);
        return solution.SequenceEqual(_userInput.PlayerGuess());
    }
}