using System;
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
            var codeBreakerMock = new Mock<ICodeBreaker>();
            var ge = new GameEngine(gameSetupMock.Object, codeBreakerMock.Object);
            gameSetupMock.Setup(c => c.GetSolution()).Returns(new[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow
            });
            codeBreakerMock.SetupSequence(c => c.RunOneGame()).Returns(false).Returns(true);
            // Act
            var result = ge.Run();
            
        }
    }
}