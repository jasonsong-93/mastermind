using System.Collections.Generic;
using System.Linq;
using Mastermind.IO;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameEngineTests
    {
        private readonly Mock<ICodeBreaker> _codeBreakerMock = new();
        private readonly Mock<ICodeMaker> _codeMakerMock = new();
        private readonly Mock<IUserInput> _userInputMock = new();
        private readonly Mock<IUserOutput> _userOutputMock = new();
        private readonly Mock<IGameState> _gameState = new();
        private readonly Color[] _mockSolution = {Color.Red, Color.Blue, Color.Green, Color.Yellow};
        private const int NumPegs = 4;

        [Fact]
        public void Run_ShouldReturnAValidGameStatistics()
        {
            var firstGuess = new[] {Color.Red, Color.Yellow, Color.Blue, Color.Green};
            var firstResult = new List<ResultColor>
                {ResultColor.White, ResultColor.White, ResultColor.White, ResultColor.Black};
            var finalGuess = new[] {Color.Red, Color.Blue, Color.Green, Color.Yellow};
            var finalResult = new List<ResultColor>
                {ResultColor.Black, ResultColor.Black, ResultColor.Black, ResultColor.Black};

            var attempt1 = new Attempt(firstGuess, firstResult);
            var attempt2 = new Attempt(finalGuess, finalResult);

            var historyList = new List<Attempt> {attempt1, attempt2};

            _gameState.Setup(g => g.MaxRounds).Returns(60);
            _gameState.Setup(g => g.NumCodePegs).Returns(4);
            _codeMakerMock.Setup(c => c.GetSolutionCode(4)).Returns(_mockSolution);
            _codeBreakerMock.SetupSequence(c => c.CodeBroken(_mockSolution, NumPegs)).Returns(false).Returns(false)
                .Returns(true);
            _codeBreakerMock.Setup(c => c.Attempts).Returns(historyList);
            // Act
            var ge = new GameEngine(_codeBreakerMock.Object, _codeMakerMock.Object, _userInputMock.Object,
                _userOutputMock.Object, _gameState.Object);
            var finalStats = ge.Run();
            // Assert
            Assert.Equal(new GameStatistics(historyList, _userOutputMock.Object), finalStats);
        }

        [Fact]
        public void Run_ShouldRunGameUntilCodeIsCracked()
        {
            _gameState.Setup(g => g.MaxRounds).Returns(60);
            _gameState.Setup(g => g.NumCodePegs).Returns(4);
            _codeMakerMock.Setup(c => c.GetSolutionCode(4)).Returns(_mockSolution);
            _codeBreakerMock.SetupSequence(c => c.CodeBroken(_mockSolution, NumPegs)).Returns(false).Returns(false)
                .Returns(true);
            var ge = new GameEngine(_codeBreakerMock.Object, _codeMakerMock.Object, _userInputMock.Object,
                _userOutputMock.Object, _gameState.Object);
            ge.Run();
            _codeBreakerMock.Verify(c => c.CodeBroken(_mockSolution, NumPegs), Times.Exactly(3));
        }

        [Fact]
        public void Run_ShouldStopGameIfCodeIsNotBrokenAfterMaxRounds()
        {
            _gameState.Setup(g => g.MaxRounds).Returns(2);
            _gameState.Setup(g => g.NumCodePegs).Returns(4);
            _codeMakerMock.Setup(c => c.GetSolutionCode(4)).Returns(_mockSolution);
            _codeBreakerMock.SetupSequence(c => c.CodeBroken(_mockSolution, NumPegs)).Returns(false).Returns(false);
            var ge = new GameEngine(_codeBreakerMock.Object, _codeMakerMock.Object, _userInputMock.Object,
                _userOutputMock.Object, _gameState.Object);
            ge.Run();
            _userOutputMock.Verify(u=>u.DisplayMaxRoundsExceeded(_mockSolution), Times.Once);
        }
    }
}