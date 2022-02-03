using System.Collections.Generic;

namespace Mastermind
{
    public class GameStatistics : IGameStatistics
    {
        private readonly List<Attempt> _historyList;

        public GameStatistics(List<Attempt> historyList)
        {
            _historyList = historyList;
        }
    }
}