using System.Collections.Generic;
using System.Linq;
using Mastermind.Input;
using Mastermind.Output;

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

        // Get the player's guess (this should be validated already)
        var guess = _userInput.PlayerGuess();
        
        // Get the result which will be printed out to the output
        var result = CalculateResult(guess, solution);
        
        // Create and store this as an attempt
        var newAttempt = new Attempt(guess, result);
        
        // Return the result if the code has been broken
        // If it's not true, we need to give a hint
        if (!solution.SequenceEqual(guess))
        {
            // Need to output this
            var thingToPrint = CalculateResult(guess, solution);
            return false;
        }
        return true;
    }

    public static List<Color> CalculateResult(Color[] guess, Color[] solution)
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