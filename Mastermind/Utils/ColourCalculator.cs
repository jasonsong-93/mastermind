using System;
using System.Collections.Generic;
using System.Linq;
using Mastermind.Model;

namespace Mastermind.Utils
{
    public static class ColourCalculator
    {
        public static List<ResultColor> CalculateResult(Color[] guess, Color[] solution)
        {
            var solutionColorFrequencyDictionary = solution.GroupBy(x => x).ToDictionary(x =>
                x.Key, x => x.Count());

            var guessColorFrequencyDictionary = guess.GroupBy(x => x).ToDictionary(x =>
                x.Key, x => x.Count());
            var result = new List<ResultColor>();

            var resultSize = solution.Length;

            // Resolve all the black elements first
            for (var i = 0; i < resultSize; ++i)
            {
                // iterate through both the solution and guess
                // arrays, add black values in and decrement corresponding values from both dictionaries
                if (guess[i] != solution[i]) continue;
                DecrementFrequency(solutionColorFrequencyDictionary, guess[i]);
                DecrementFrequency(guessColorFrequencyDictionary, guess[i]);
                result.Add(ResultColor.Black);
            }

            // Resolve white elements that exist afterwards
            // Firstly check which dictionary has more keys for efficiency
            var lessKeys = GetDictionaryWithLessKeys(solutionColorFrequencyDictionary, guessColorFrequencyDictionary);
            var moreKeys = GetDictionaryWithMoreKeys(solutionColorFrequencyDictionary, guessColorFrequencyDictionary);
            foreach (var numWhites in from kvp in lessKeys
                select kvp.Key
                into keyToCheck
                where moreKeys.ContainsKey(keyToCheck)
                select Math.Min(solutionColorFrequencyDictionary[keyToCheck],
                    guessColorFrequencyDictionary[keyToCheck]))
            {
                for (var i = 0; i < numWhites; i++)
                {
                    result.Add(ResultColor.White);
                }
            }

            result.ShuffleMe();
            return result;
        }

        private static void DecrementFrequency(IDictionary<Color, int> dictionary, Color keyToDecrement)
        {
            dictionary[keyToDecrement]--;
        }

        private static Dictionary<Color, int> GetDictionaryWithLessKeys(Dictionary<Color, int> dictionary1,
            Dictionary<Color, int> dictionary2)
        {
            return dictionary1.Count >= dictionary2.Count ? dictionary1 : dictionary2;
        }

        private static Dictionary<Color, int> GetDictionaryWithMoreKeys(Dictionary<Color, int> dictionary1,
            Dictionary<Color, int> dictionary2)
        {
            return dictionary1.Count < dictionary2.Count ? dictionary1 : dictionary2;
        }
    }
}