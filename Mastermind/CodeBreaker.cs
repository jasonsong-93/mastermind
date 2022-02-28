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

    public bool CodeBroken(Color[] solution)
    {
        var guess = _userInput.PlayerGuess();
        var result = CalculateResult(guess, solution);
        var newAttempt = new Attempt(guess, result);
        if (!solution.SequenceEqual(guess))
        {
            var thingToPrint = CalculateResult(guess, solution);
            return false;
        }
        return true;
    }

    private static List<Color> CalculateResult(Color[] guess, Color[] solution)
    {
        var solutionColorFrequencyDictionary = solution.GroupBy(x => x).ToDictionary(x => 
            x.Key, x => x.Count());
        var result = new List<Color>();
        for (var i = 0; i < guess.Length; ++i)
        {
            if (solution[i] == guess[i])
            {
                result.Add(Color.Black);
                solutionColorFrequencyDictionary[solution[i]]--;
            }
            else if (solutionColorFrequencyDictionary.ContainsKey(guess[i]) &&
                     solutionColorFrequencyDictionary[guess[i]] > 0)
            {
                result.Add(Color.White);
                solutionColorFrequencyDictionary[guess[i]]--;
            }
        }
        return result;
    }
}