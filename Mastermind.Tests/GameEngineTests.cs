using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameEngineTests
    {
        [Fact]
        public void Run_ShouldReturnGameStatisticsCorrectly() // 6 colours, 4 holes
        {
            // Arrange
            var userInputMock = new Mock<IUserInput>();
            var codeBreakerMock = new Mock<ICodeBreaker>();
            var codeMakerMock = new Mock<ICodeMaker>();
            var ge = new GameEngine(userInputMock.Object, codeBreakerMock.Object, codeMakerMock.Object);
            
            var firstGuess = new[] {Color.Red, Color.Yellow, Color.Blue, Color.Green}; 
            var firstResult = new List<Color> {Color.White, Color.White, Color.White, Color.Black};
            var finalGuess = new[] {Color.Red, Color.Blue, Color.Green, Color.Yellow};
            var finalResult = new List<Color> {Color.Black, Color.Black, Color.Black, Color.Black}; 

            var attempt1 = new Attempt(firstGuess, firstResult);
            var attempt2 = new Attempt(finalGuess, finalResult);

            var historyList = new List<Attempt>{attempt1, attempt2};

            codeBreakerMock.SetupSequence(c => c.CheckGuess()).Returns(false).Returns(true);
            codeBreakerMock.Setup(c => c.GetGuessHistory()).Returns(historyList); 
            // Act
            var finalStats = ge.Run();
            
            // Assert
            Assert.Equal(new GameStatistics(historyList), finalStats);
        }
        

    }
}