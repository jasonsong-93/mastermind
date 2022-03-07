using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class GameStatistics
    {
        private readonly List<Attempt> _historyList;

        public GameStatistics(List<Attempt> historyList)
        {
            _historyList = historyList;
        }
        
        public override string ToString()
        {
            var result = "";
            var count = 0;
            foreach (var attempt in _historyList)
            {
                Console.WriteLine(count);
                Console.Write("Attempts: ");
                for (var i = 0; i < attempt.Guess.Length; ++i)
                {
                    Console.Write(attempt.Guess[i] + ", ");
                }

                Console.WriteLine();
                Console.Write("Results: ");
                foreach (var attemptResult in attempt.Result)
                {
                    Console.Write(attemptResult + ", ");
                }

                Console.WriteLine();
                count++;
            }

            return result;
        }
    }
}