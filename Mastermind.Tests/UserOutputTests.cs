using System.Collections.Generic;
using Mastermind.IO;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class UserOutputTests
    {
        readonly Mock<IConsoleIO> _consoleIOMock = new();

        [Fact]
        public void DisplayIntroMessage_ShouldCorrectlyDisplayIntroMessage()
        {
            var s = @"

███╗   ███╗ █████╗ ███████╗████████╗███████╗██████╗ ███╗   ███╗██╗███╗   ██╗██████╗ 
████╗ ████║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔══██╗
██╔████╔██║███████║███████╗   ██║   █████╗  ██████╔╝██╔████╔██║██║██╔██╗ ██║██║  ██║
██║╚██╔╝██║██╔══██║╚════██║   ██║   ██╔══╝  ██╔══██╗██║╚██╔╝██║██║██║╚██╗██║██║  ██║
██║ ╚═╝ ██║██║  ██║███████║   ██║   ███████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║██████╔╝
╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═════╝ 
                                                                                    

";
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayMenu();
            _consoleIOMock.Verify(c=>c.WriteLine(s), Times.Once);
        }
        
        [Fact]
        public void DisplayFinished_ShouldCorrectlyDisplayFinished()
        {
            var s = "***Congratulations on cracking the code! Here are your results***";
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayFinished();
            _consoleIOMock.Verify(c=>c.WriteLine(s), Times.Once);
        }

        [Fact]
        public void DisplayResult_ShouldCorrectlyDisplayResult()
        {
            var fakeResultColor = new List<ResultColor>() {ResultColor.White, ResultColor.Black};
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayResult(fakeResultColor);
            foreach (var resultColor in fakeResultColor)
            {
                _consoleIOMock.Verify(c=>c.Write(resultColor + " "), Times.Once);
            }
        }

        [Fact]
        public void DisplayMaxRoundsExceeded_ShouldCorrectlyDisplayMaxRoundsExceeded()
        {
            var s = "You've reached the maximum allocated rounds, ending game.";
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayMaxRoundsExceeded();
            _consoleIOMock.Verify(c=>c.WriteLine(s));
        }
        //
        // [Fact]
        // public void DisplayAttempts_ShouldCorrectlyDisplayAttempts()
        // {
        //     var firstGuess = new[] {Color.Red, Color.Yellow, Color.Blue, Color.Green};
        //     var firstResult = new List<ResultColor>
        //         {ResultColor.White, ResultColor.White, ResultColor.White, ResultColor.Black};
        //     var finalGuess = new[] {Color.Red, Color.Blue, Color.Green, Color.Yellow};
        //     var finalResult = new List<ResultColor>
        //         {ResultColor.Black, ResultColor.Black, ResultColor.Black, ResultColor.Black};
        //
        //     var attempt1 = new Attempt(firstGuess, firstResult);
        //     var attempt2 = new Attempt(finalGuess, finalResult);
        //
        //     var attempts = new List<Attempt> {attempt1, attempt2};
        //     var s = "***PRINTING OUT DISPLAYATTEMPTS METHOD***";
        //     var uo = new UserOutput(_consoleIOMock.Object);
        //     uo.DisplayAttempts(attempts);
        //     foreach (var t in attempts)
        //     {
        //         foreach (var color in t.Guess)
        //         {
        //             _consoleIOMock.Verify(c=>c.Write(color + " "));
        //         }
        //     }
        //     _consoleIOMock.Verify(c=>c.WriteLine(""));
        // }
    }
}