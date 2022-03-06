using System;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class CodeMakerTests
    {
        [Fact]
        public void GetSolutionCode_ShouldReturnAValidCodeWithCorrectSize()
        {
            var randomizerMock = new Mock<IRandomizer>(); // setup to return specific colours
            var codeMaker = new CodeMaker(randomizerMock.Object);
            var numPegs = 4;
            randomizerMock.SetupSequence(r => r.GenerateRandomInt(Enum.GetNames(typeof(Color)).Length)).Returns(0)
                .Returns(1).Returns(2).Returns(3);
            var result = codeMaker.GetSolutionCode(numPegs);
            Assert.Equal(new[] {Color.Red, Color.Blue, Color.Green, Color.Orange}, result);
        }
    }
}