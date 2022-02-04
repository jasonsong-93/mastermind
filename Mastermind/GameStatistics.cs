using System.Collections.Generic;

namespace Mastermind
{
    public class GameStatistics : IGameStatistics
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
    }
}