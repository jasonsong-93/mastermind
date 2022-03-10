using System;
using Mastermind.IO;

namespace Mastermind
{
    public class GameEngine : IGameEngine
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
            _userOutput.DisplayMenu();
            _gameState.Initialize(_userInput);
            var maxPegs = _gameState.NumCodePegs;
            var maxRounds = _gameState.MaxRounds;
            _userOutput.DisplayGameState(maxRounds, maxPegs);
            _userOutput.Countdown();
            var codeSuccessfullyBroken = false;
            var numRounds = 0;
            var solution = _codeMaker.GetSolutionCode(maxPegs);
            while (!codeSuccessfullyBroken && (numRounds < maxRounds))
            {
                _userOutput.ClearOutput();
                _userOutput.DisplayCurrentRound(numRounds + 1, maxRounds);
                codeSuccessfullyBroken = _codeBreaker.CodeBroken(solution, maxPegs);
                if (codeSuccessfullyBroken)
                {
                    _userOutput.DisplayWin();
                }
                numRounds++;
                if (numRounds == maxRounds && !codeSuccessfullyBroken)
                {
                    _userOutput.DisplayMaxRoundsExceeded();
                }
            }
            _userOutput.DisplaySolution(solution);
            var guessHistory = _codeBreaker.Attempts;
            return new GameStatistics(guessHistory, _userOutput);
        }
    }
}