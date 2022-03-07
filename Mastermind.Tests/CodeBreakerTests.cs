using Mastermind.IO;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class CodeBreakerTests
    {
        private readonly Mock<IUserInput> _userInputMock = new();
        private readonly Mock<IUserOutput> _userOutputMock = new();
        private readonly Color[] _mockSolution = {Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Purple};
    
        [Theory]
        [InlineData(new []{Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Purple}, true)]
        [InlineData(new []{Color.Black, Color.Black, Color.Green, Color.Orange, Color.Purple}, false)]
        public void CodeBroken_ShouldReturnTrueOrFalseDependingOnGuess(Color[] guess, bool result)
        {
            _userInputMock.Setup(u => u.PlayerGuess()).Returns(guess);
            var codeBreaker = new CodeBreaker(_userInputMock.Object, _userOutputMock.Object);
            var broken = codeBreaker.CodeBroken(_mockSolution);
            Assert.Equal(result, broken);
        }
    }
}