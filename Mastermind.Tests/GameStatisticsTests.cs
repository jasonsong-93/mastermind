using System.Collections.Generic;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameStatisticsTests
    {

        [Fact]
        public void ToString_ShouldCreateCorrectString()
        {
            var firstGuess = new[] {Color.Red, Color.Yellow, Color.Blue, Color.Green};
            var firstResult = new List<ResultColor>
                {ResultColor.White, ResultColor.White, ResultColor.White, ResultColor.Black};
            var finalGuess = new[] {Color.Red, Color.Blue, Color.Green, Color.Yellow};
            var finalResult = new List<ResultColor>
                {ResultColor.Black, ResultColor.Black, ResultColor.Black, ResultColor.Black};

            var attempt1 = new Attempt(firstGuess, firstResult);
            var attempt2 = new Attempt(finalGuess, finalResult);

            var historyList = new List<Attempt> {attempt1, attempt2};

            var gameStats = new GameStatistics(historyList);
            var s = gameStats.ToString();
            Assert.Equal("hello", s);
        }
    }
}