using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class CodeMakerTests
    {
        [Fact]
        public void GenerateRandomCode_ShouldReturnAValidRandomCode()
        {
            var randomizerMock = new Mock<IRandomizer>();
        }
    }
}