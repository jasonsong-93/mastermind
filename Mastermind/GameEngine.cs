namespace Mastermind
{
    public class GameEngine
    {
        private readonly ICodeBreaker _codeBreaker;
        private readonly ICodeMaker _codeMaker;

        public GameEngine(ICodeBreaker codeBreaker, ICodeMaker codeMaker)
        {
            _codeBreaker = codeBreaker;
            _codeMaker = codeMaker;
        }

        public GameStatistics Run()
        {
            var gameFinished = false;
            var solution = _codeMaker.GetSolutionCode();
            while (!gameFinished)
            {
                gameFinished = _codeBreaker.CodeBroken(solution);
            }
            var guessHistory = _codeBreaker.Attempts;
            return new GameStatistics(guessHistory);
        }
    }
}