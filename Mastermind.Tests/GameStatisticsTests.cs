using System.Collections.Generic;
using Mastermind.IO;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class GameStatisticsTests
    {
        private static readonly Color[] FirstGuess = {Color.Red, Color.Yellow, Color.Blue, Color.Green};
        private static readonly List<ResultColor> FirstResult = new() {ResultColor.White, ResultColor.White, ResultColor.White, ResultColor.Black};
        private static readonly Attempt Attempt1 = new(FirstGuess, FirstResult);
        private static readonly Color[] FinalGuess = {Color.Red, Color.Blue, Color.Green, Color.Yellow};
        private static readonly List<ResultColor> FinalResult = new() {ResultColor.Black, ResultColor.Black, ResultColor.Black, ResultColor.Black};
        private static readonly Attempt Attempt2 = new(FinalGuess, FinalResult);
        private readonly List<Attempt> _historyList = new() {Attempt1, Attempt2};

        [Fact]
        public void Display_ShouldCallTheOutputToDisplay()
        {
            Mock<IUserOutput> mockOutput = new ();
            mockOutput.Setup(o => o.DisplayStatistics(_historyList));
            var gameStats = new GameStatistics(_historyList, mockOutput.Object);
            gameStats.Display();
            mockOutput.Verify(o=>o.DisplayStatistics(_historyList), Times.Once);
        }  
    }
}