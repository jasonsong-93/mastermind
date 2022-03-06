using Mastermind.Input;
using Mastermind.Output;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameStateTests
    {
        private readonly Mock<IUserInput> _userInputMock = new();
        private readonly Mock<IUserOutput> _userOutputMock = new();
        [Fact]
        public void Initialize_ShouldCorrectlySet()
        {
            _userInputMock.Setup(i => i.ValidateMaxRounds()).Returns(60);
            _userInputMock.Setup(i => i.ValidateNumCodePegs()).Returns(4);
            var gameState = new GameState();
            gameState.Initialize(_userInputMock.Object, _userOutputMock.Object);
            
            _userInputMock.Verify(i=>i.ValidateMaxRounds(), Times.Once);
            _userInputMock.Verify(i=>i.ValidateNumCodePegs(), Times.Once);
        }
    }
}