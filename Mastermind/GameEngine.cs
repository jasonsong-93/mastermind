using System;
using Mastermind.IO;

namespace Mastermind
{
    public class GameEngine
    {
        private readonly ICodeBreaker _codeBreaker;
        private readonly ICodeMaker _codeMaker;
        private readonly IUserInput _userInput;
        private readonly IUserOutput _userOutput;
        private readonly IGameState _gameState;

        public GameEngine(ICodeBreaker codeBreaker, ICodeMaker codeMaker, IUserInput userInput, IUserOutput userOutput,
            IGameState gameState)
        {
            _codeBreaker = codeBreaker;
            _codeMaker = codeMaker;
            _userInput = userInput;
            _userOutput = userOutput;
            _gameState = gameState;
        }

        public GameStatistics Run()
        {
            var numRounds = 0;
            _userOutput.DisplayIntroMessage();
            _gameState.Initialize(_userInput, _userOutput);
            var maxPegs = _gameState.NumCodePegs;
            var maxRounds = _gameState.MaxRounds;
            
            var gameFinished = false;
            var solution = _codeMaker.GetSolutionCode(maxPegs);
            while (!gameFinished && (numRounds < maxRounds))
            {
                gameFinished = _codeBreaker.CodeBroken(solution);
                if (gameFinished)
                {
                    _userOutput.DisplayFinished();
                }
                else
                {
                    _userOutput.DisplayIncorrect();
                }
                numRounds++;
            }
            var guessHistory = _codeBreaker.Attempts;
            return new GameStatistics(guessHistory);
        }
    }
}