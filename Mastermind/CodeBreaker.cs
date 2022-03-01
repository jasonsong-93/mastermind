using System;
using System.Collections.Generic;
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

        public bool CodeBroken(Color[] solution)
        {
            var guess = _userInput.PlayerGuess();
            var result = CalculateResult(guess, solution);
            if (!solution.SequenceEqual(guess))
            {
                Console.WriteLine("NOT BROKEN");
                Console.WriteLine(result);
                return false;
            }

            Console.WriteLine("BROKEN");
            Console.WriteLine(result);

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