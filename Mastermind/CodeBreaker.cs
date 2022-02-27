﻿using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Input;

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
        return solution.SequenceEqual(guess);
    }
}