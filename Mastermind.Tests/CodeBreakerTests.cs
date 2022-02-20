using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class CodeBreakerTests
    {
        [Fact]
        public void CodeBroken_ShouldReturnTrueIfTheCodeFromUserAndSolutionAreSame()
        {
            // Arrange
            var mockSolution = new[] {Color.Black, Color.Blue, Color.Green, Color.Purple};
            var userInputMock = new Mock<IUserInput>();
            // Act
            var codeBreaker = new CodeBreaker(userInputMock.Object);
            // Assert
        }
    }
}