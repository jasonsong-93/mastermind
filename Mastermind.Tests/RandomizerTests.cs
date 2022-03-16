using System;
using Mastermind.Model;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class RandomizerTests
    {
        [Fact]
        public void GenerateRandomInt_ShouldCallTheRandNextFunction()
        {
            Mock<Random> randomMock = new();
            randomMock.Setup(r => r.Next(5)).Returns(2);
            var result = new Randomizer(randomMock.Object);
            result.GenerateRandomInt(5);
            randomMock.Verify(r => r.Next(5), Times.Once);
        }
    }
}