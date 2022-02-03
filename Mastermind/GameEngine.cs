using Mastermind.Tests;

namespace Mastermind
{
    public class GameEngine
    {
        private readonly IGameSetup _gameSetup;
        private readonly ICodeBreaker _codeBreaker;

        public GameEngine(IGameSetup gameSetup, ICodeBreaker codeBreaker)
        {
            _gameSetup = gameSetup;
            _codeBreaker = codeBreaker;
        }

        public GameStatistics Run()
        {
            return null;
        }
    }
}