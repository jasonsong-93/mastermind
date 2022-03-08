using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class GameStatistics
    {
        protected bool Equals(GameStatistics other)
        {
            return Equals(HistoryList, other.HistoryList);
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
            return (HistoryList != null ? HistoryList.GetHashCode() : 0);
        }

        public List<Attempt> HistoryList { get; }

        public GameStatistics(List<Attempt> historyList)
        {
            HistoryList = historyList;
        }
        
        public override string ToString()
        {
            var result = "";
            var count = 0;
            foreach (var attempt in HistoryList)
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