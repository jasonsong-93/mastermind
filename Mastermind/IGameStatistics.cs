using System.Collections.Generic;

namespace Mastermind
{
    public interface IGameStatistics
    {
        public List<Attempt> GetAttemptHistory();
    }
}