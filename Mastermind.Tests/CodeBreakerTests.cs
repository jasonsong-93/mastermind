using Moq;
using Xunit;

namespace Mastermind.Tests;

public class CodeBreakerTests
{
    // Refactor this later
    [Fact]
    public void CodeBroken_ShouldReturnTrueIfGuessIsCorrect()
    {
        var userInputMock = new Mock<IUserInput>();
        var mockSolution = new []{Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Purple};
        var playerGuess = new []{Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Purple};

        userInputMock.Setup(u => u.PlayerGuess()).Returns(playerGuess);
        
        var codeBreaker = new CodeBreaker(userInputMock.Object);
        var result = codeBreaker.CodeBroken(mockSolution);
        
        Assert.True(result);
    }
    
    [Fact]
    public void CodeBroken_ShouldReturnFalseIfGuessIsIncorrect()
    {
        var userInputMock = new Mock<IUserInput>();
        var mockSolution = new []{Color.Black, Color.Blue, Color.Green, Color.Orange, Color.Purple};
        var playerGuess = new []{Color.Black, Color.Blue, Color.Blue, Color.Orange, Color.Purple};

        userInputMock.Setup(u => u.PlayerGuess()).Returns(playerGuess);
        
        var codeBreaker = new CodeBreaker(userInputMock.Object);
        var result = codeBreaker.CodeBroken(mockSolution);
        
        Assert.False(result);
    }
}