using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameEngineTests
    {
        private readonly Mock<ICodeBreaker> _codeBreakerMock = new();
        private readonly Mock<ICodeMaker> _codeMakerMock = new();
        private readonly Color[] _mockSolution = {Color.Red, Color.Blue, Color.Green, Color.Yellow};

        [Fact]
        public void Run_ShouldReturnGameStatisticsCorrectly()
        {

            var firstGuess = new[] {Color.Red, Color.Yellow, Color.Blue, Color.Green};
            var firstResult = new List<Color> {Color.White, Color.White, Color.White, Color.Black};
            var finalGuess = new[] {Color.Red, Color.Blue, Color.Green, Color.Yellow};
            var finalResult = new List<Color> {Color.Black, Color.Black, Color.Black, Color.Black};

            var attempt1 = new Attempt(firstGuess, firstResult);
            var attempt2 = new Attempt(finalGuess, finalResult);

            var historyList = new List<Attempt> {attempt1, attempt2};

            _codeMakerMock.Setup(c => c.GetSolutionCode()).Returns(_mockSolution);
            _codeBreakerMock.SetupSequence(c => c.CodeBroken(_mockSolution)).Returns(false).Returns(false).Returns(true);
            _codeBreakerMock.Setup(c => c.Attempts).Returns(historyList);
            // Act
            var ge = new GameEngine(_codeBreakerMock.Object, _codeMakerMock.Object);
            var finalStats = ge.Run();
            // Assert
            Assert.Equal(new GameStatistics(historyList), finalStats);
        }

        [Fact]
        public void Run_ShouldRunGameUntilCodeIsCracked()
        {
            _codeMakerMock.Setup(c => c.GetSolutionCode()).Returns(_mockSolution);
            _codeBreakerMock.SetupSequence(c => c.CodeBroken(_mockSolution)).Returns(false).Returns(false).Returns(true);
            var ge = new GameEngine(_codeBreakerMock.Object, _codeMakerMock.Object);
            ge.Run();
            _codeBreakerMock.Verify(c => c.CodeBroken(_mockSolution), Times.Exactly(3));
        }
    }
}