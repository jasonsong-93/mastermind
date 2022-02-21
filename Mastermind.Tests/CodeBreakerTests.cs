using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class CodeBreakerTests
    {
        [Fact]
        public void CodeBroken_ShouldReturnTrueIfTheCodeFromUserAndSolutionAreSame()
        {
            var mockSolution = new[] {Color.Black, Color.Blue, Color.Green, Color.Purple};
            var userGuess = new[] {Color.Black, Color.Blue, Color.Green, Color.Purple};
            var userInputMock = new Mock<IUserInput>();
            userInputMock.Setup(u => u.GetUserGuess()).Returns(userGuess);
            var codeBreaker = new CodeBreaker(userInputMock.Object);
            var result = codeBreaker.CodeBroken(mockSolution);
            Assert.True(result);
        }
    }
}