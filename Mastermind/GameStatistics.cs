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

        protected bool Equals(GameStatistics other)
        {
            return Equals(_historyList, other._historyList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((GameStatistics) obj);
        }

        public override int GetHashCode()
        {
            return _historyList != null ? _historyList.GetHashCode() : 0;
        }

        // Refactor this
        public override string ToString()
        {
            var result = "";
            var count = 0;
            foreach (var attempt in _historyList)
            {
                // For an attempt, it contains 2 lists
                // Print out first list
                Console.WriteLine(count);
                Console.Write("Attempts: ");
                for (var i = 0; i < attempt._guess.Length; ++i)
                {
                    Console.Write(attempt._guess[i] + ", ");
                }
                Console.WriteLine();
                Console.Write("Results: ");
                foreach (var attemptResult in attempt._result)
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