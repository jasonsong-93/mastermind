using Mastermind.IO.Interfaces;
using Mastermind.Model;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class CodeBreakerTests
    {
        private readonly Mock<IUserInput> _userInputMock = new();
        private readonly Mock<IUserOutput> _userOutputMock = new();
        private readonly Color[] _mockSolutionFourPegs = {Color.Blue, Color.Blue, Color.Green, Color.Orange};

        [Theory]
        [InlineData(new[] {Color.Blue, Color.Blue, Color.Green, Color.Orange}, true, 4)]
        [InlineData(new[] {Color.Blue, Color.Yellow, Color.Green, Color.Orange}, false, 4)]
        [InlineData(new[] {Color.Blue, Color.Blue, Color.Blue, Color.Blue}, false, 4)]
        [InlineData(new[] {Color.Blue, Color.Blue, Color.Blue, Color.Purple}, false, 4)]
        [InlineData(new[] {Color.Yellow, Color.Blue, Color.Blue, Color.Purple}, false, 4)]
        [InlineData(new[] {Color.Blue, Color.Purple, Color.Blue, Color.Purple}, false, 4)]
        [InlineData(new[] {Color.Blue, Color.Purple, Color.Orange, Color.Purple}, false, 4)]
        [InlineData(new[] {Color.Yellow, Color.Yellow, Color.Yellow, Color.Yellow}, false, 4)]
        public void CodeBroken_ShouldReturnTrueOrFalseDependingOnGuess(Color[] guess, bool result, int numPegs)
        {
            _userInputMock.Setup(u => u.PlayerGuess(numPegs)).Returns(guess);
            var codeBreaker = new CodeBreaker(_userInputMock.Object, _userOutputMock.Object);
            var broken = codeBreaker.CodeBroken(_mockSolutionFourPegs, numPegs);
            Assert.Equal(result, broken);
            _userInputMock.Verify(u => u.PlayerGuess(numPegs), Times.Once);
        }
    }
}