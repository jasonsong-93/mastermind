using Mastermind.IO;
using Mastermind.IO.Interfaces;
using Mastermind.Model;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class UserInputTests
    {
        private readonly Mock<IConsoleIO> _mockConsole = new();
        private readonly Mock<IUserOutput> _userOutputMock = new();
        private const int NumPegs = 4;


        [Theory]
        [InlineData("Green", "Red", "Yellow", "Yellow", new[]
        {
            Color.Green, Color.Red, Color.Yellow, Color.Yellow
        })]
        [InlineData("Blue", "Red", "Yellow", "Yellow", new[]
        {
            Color.Blue, Color.Red, Color.Yellow, Color.Yellow
        })]
        [InlineData("Blue", "Red", "Orange", "Yellow", new[]
        {
            Color.Blue, Color.Red, Color.Orange, Color.Yellow
        })]
        [InlineData("Blue", "Purple", "Yellow", "Yellow", new[]
        {
            Color.Blue, Color.Purple, Color.Yellow, Color.Yellow
        })]
        public void PlayerGuess_ShouldReturnThePlayerInputGuess(string first, string second, string third,
            string fourth, Color[] expected)
        {
            _mockConsole.SetupSequence(c => c.ReadLine()).Returns(first).Returns(second).Returns(third).Returns(fourth);
            var ui = new UserInput(_mockConsole.Object, _userOutputMock.Object);
            var result = ui.PlayerGuess(NumPegs);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("4", 4)]
        [InlineData("6", 6)]
        public void ValidateNumCodePegs_ShouldCorrectlyReturnValidCodePegs(string input, int expected)
        {
            Mock<IConsoleIO> mockConsole = new();
            mockConsole.Setup(c => c.ReadLine()).Returns(input);
            var ui = new UserInput(mockConsole.Object, _userOutputMock.Object);
            var result = ui.ValidateNumCodePegs();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("4", 4)]
        [InlineData("6", 6)]
        [InlineData("10", 10)]
        public void GetValidMaxRounds_ShouldCorrectlyReturnValidMaxRounds(string input, int expected)
        {
            Mock<IConsoleIO> mockConsole = new();
            mockConsole.Setup(c => c.ReadLine()).Returns(input);
            var ui = new UserInput(mockConsole.Object, _userOutputMock.Object);
            var result = ui.GetValidMaxRounds();
            Assert.Equal(expected, result);
        }
    }
}