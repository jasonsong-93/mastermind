using System;
using System.Collections.Generic;
using Mastermind.IO;

namespace Mastermind
{
    public class GameStatistics
    {
        private readonly IUserOutput _userOutput;
        public List<Attempt> HistoryList { get; }

        public GameStatistics(List<Attempt> historyList, IUserOutput userOutput)
        {
            _userOutput = userOutput;
            HistoryList = historyList;
        }
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



        public void PrintToConsole()
        {
            _userOutput.DisplayStatistics(HistoryList);
        }

    }
}