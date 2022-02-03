using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameEngineTests
    {
        [Fact]
        public void Run_ShouldReturnResults() // 6 colours, 4 holes
        {
            // Arrange
            var gameSetupMock = new Mock<IGameSetup>();
            var codeMakerMock = new Mock<ICodeMaker>();
            var codeBreakerMock = new Mock<ICodeBreaker>();
            var ge = new GameEngine(gameSetupMock.Object, codeBreakerMock.Object);

            var firstGuess = new[] {Color.Red, Color.Yellow, Color.Blue, Color.Green};
            var secondGuess = new[] {Color.Red, Color.Blue, Color.Green, Color.Yellow};

            var initialResult = new List<Color> {Color.White, Color.White, Color.White, Color.Black}; // 2 elements are in the wrong position
            var finalResult = new List<Color> {Color.Black, Color.Black, Color.Black, Color.Black}; // All elements correct

            var attempt1 = new Attempt(firstGuess, initialResult);
            var attempt2 = new Attempt(secondGuess, finalResult);

            var historyList = new List<Attempt>{attempt1, attempt2};
            

            gameSetupMock.Setup(g => g.GetMaximumAttempts()).Returns(60);
            gameSetupMock.Setup(g => g.GetNumberOfColors()).Returns(6);
            gameSetupMock.Setup(g => g.GetBoardSize()).Returns(4);
            gameSetupMock.Setup(g => g.DuplicatesAllowed()).Returns(false);
            gameSetupMock.Setup(g => g.SinglePlayerMode()).Returns(true);
            codeMakerMock.Setup(c => c.GetSolution()).Returns(new[]
            {
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Yellow
            });
            codeBreakerMock.SetupSequence(c => c.RunOneCheck()).Returns(false).Returns(true);
            codeBreakerMock.Setup(c => c.GetGuessHistory()).Returns(historyList); 
            // Act
            var result = ge.Run();
            
            // Assert
            
        }
    }
}