using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Mastermind.Input;

namespace Mastermind
{
    public class CodeBreaker : ICodeBreaker
    {
        private readonly IUserInput _userInput;
        public List<Attempt> Attempts { get; set; }

        public CodeBreaker(IUserInput userInput)
        {
            _userInput = userInput;
        }

        // Checks if the code is broken
        public bool CodeBroken(Color[] solution)
        {
            var guess = _userInput.PlayerGuess();
            var result = CalculateResult(guess, solution);
            var attempt = new Attempt(guess, result);
            Attempts.Add(attempt);
            if (!solution.SequenceEqual(guess))
            {
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
                var frequencyGreaterThanZero = solutionColorFrequencyDictionary[guess[i]] > 0;
                if (frequencyGreaterThanZero)
                {
                    if (solution[i] == guess[i])
                    {
                        result.Add(Color.Black);
                        DecrementFrequency(solutionColorFrequencyDictionary, guess[i]);
                    }
                    else
                    {
                        result.Add(Color.White);
                        DecrementFrequency(solutionColorFrequencyDictionary, guess[i]);
                    }
                }
            }
            return result;
        }

        private static void DecrementFrequency(Dictionary<Color, int> dictionary, Color keyToDecrement)
        {
            dictionary[keyToDecrement]--;
        }
    }
}