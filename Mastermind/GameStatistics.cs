using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class GameStatistics
    {
        protected bool Equals(GameStatistics other)
        {
            return Equals(_historyList, other._historyList);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GameStatistics) obj);
        }

        public override int GetHashCode()
        {
            return (_historyList != null ? _historyList.GetHashCode() : 0);
        }

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