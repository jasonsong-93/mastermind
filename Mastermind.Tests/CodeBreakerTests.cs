using Mastermind.Input;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class CodeBreakerTests
    {
        private readonly Mock<IUserInput> _userInputMock = new();

        private readonly Color[] _mockSolution = {Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Purple};
        private readonly Color[] _playerGuessCorrect = {Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Purple};
        private readonly Color[] _playerGuessIncorrect = {Color.Black, Color.Black, Color.Green, Color.Orange, Color.Purple};

        [Fact]
        public void CodeBroken_ShouldReturnTrueIfGuessIsCorrect()
        {
            _userInputMock.Setup(u => u.PlayerGuess()).Returns(_playerGuessCorrect);
            var codeBreaker = new CodeBreaker(_userInputMock.Object);
            var result = codeBreaker.CodeBroken(_mockSolution);
            Assert.True(result);
        }
    
        [Fact]
        public void CodeBroken_ShouldReturnFalseIfGuessIsIncorrect()
        {
            _userInputMock.Setup(u => u.PlayerGuess()).Returns(_playerGuessIncorrect);
            var codeBreaker = new CodeBreaker(_userInputMock.Object);
            var result = codeBreaker.CodeBroken(_mockSolution);
            Assert.False(result);
        }

    }
}