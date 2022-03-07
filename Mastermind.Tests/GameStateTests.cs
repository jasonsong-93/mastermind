using Mastermind.IO;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameStateTests
    {
        private readonly Mock<IUserInput> _userInputMock = new();

        [Fact]
        public void Initialize_ShouldCorrectlySet()
        {
            _userInputMock.Setup(i => i.GetValidMaxRounds()).Returns(60);
            _userInputMock.Setup(i => i.ValidateNumCodePegs()).Returns(4);
            var gameState = new GameState();
            gameState.Initialize(_userInputMock.Object);

            _userInputMock.Verify(i => i.GetValidMaxRounds(), Times.Once);
            _userInputMock.Verify(i => i.ValidateNumCodePegs(), Times.Once);
        }

        [Fact]
        public void NumCodePegs_ShouldReturnValidNumPegs()
        {
            var numPegs = 4;
            _userInputMock.Setup(i => i.ValidateNumCodePegs()).Returns(numPegs);
            var gameState = new GameState();
            gameState.Initialize(_userInputMock.Object);
            Assert.Equal(numPegs, gameState.NumCodePegs);
        }
        [Fact]
        public void MaxRounds_ShouldReturnValidMaxRounds()
        {
            var maxRounds = 10;
            _userInputMock.Setup(i => i.GetValidMaxRounds()).Returns(maxRounds);
            var gameState = new GameState();
            gameState.Initialize(_userInputMock.Object);
            Assert.Equal(maxRounds, gameState.MaxRounds);
        }
    }
}