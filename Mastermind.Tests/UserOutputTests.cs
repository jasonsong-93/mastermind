using System.Collections.Generic;
using Mastermind.IO;
using Mastermind.IO.Interfaces;
using Mastermind.Model;
using Moq;
using Xunit;

namespace Mastermind.Tests
{
    public class UserOutputTests
    {
        private readonly Mock<IConsoleIO> _consoleIOMock = new();
        private readonly Color[] _mockSolution = {Color.Red, Color.Blue, Color.Green, Color.Yellow};

        [Fact]
        public void DisplayIntroMessage_ShouldCorrectlyDisplayIntroMessage()
        {
            const string? s = @"

███╗   ███╗ █████╗ ███████╗████████╗███████╗██████╗ ███╗   ███╗██╗███╗   ██╗██████╗ 
████╗ ████║██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗████╗ ████║██║████╗  ██║██╔══██╗
██╔████╔██║███████║███████╗   ██║   █████╗  ██████╔╝██╔████╔██║██║██╔██╗ ██║██║  ██║
██║╚██╔╝██║██╔══██║╚════██║   ██║   ██╔══╝  ██╔══██╗██║╚██╔╝██║██║██║╚██╗██║██║  ██║
██║ ╚═╝ ██║██║  ██║███████║   ██║   ███████╗██║  ██║██║ ╚═╝ ██║██║██║ ╚████║██████╔╝
╚═╝     ╚═╝╚═╝  ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚═════╝ 
                                                                                    

";
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayMenu();
            _consoleIOMock.Verify(c => c.WriteLine(s), Times.Once);
        }


        [Fact]
        public void DisplayMaxRoundsExceeded_ShouldCorrectlyDisplayMaxRoundsExceeded()
        {
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayMaxRoundsExceeded(_mockSolution);
            _consoleIOMock.Verify(c => c.WriteLine("\nBetter luck next time ...\n\n"), Times.Once);
        }

        [Fact]
        public void DisplayBoard_ShouldCorrectlyDisplayBoard()
        {
            var firstGuess = new[] {Color.Red, Color.Yellow, Color.Blue, Color.Green};
            var firstResult = new List<ResultColor>
                {ResultColor.White, ResultColor.White, ResultColor.White, ResultColor.Black};
            var finalGuess = new[] {Color.Red, Color.Blue, Color.Green, Color.Yellow};
            var finalResult = new List<ResultColor>
                {ResultColor.Black, ResultColor.Black, ResultColor.Black, ResultColor.Black};

            var attempt1 = new Attempt(firstGuess, firstResult);
            var attempt2 = new Attempt(finalGuess, finalResult);

            var attempts = new List<Attempt> {attempt1, attempt2};

            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayBoard(attempts);
            _consoleIOMock.Verify(c => c.WriteLine("Board"), Times.Once);
            for (var i = 0; i < attempts.Count; ++i)
            {
                var i1 = i;
                _consoleIOMock.Verify(c => c.Write("Attempt #" + (i1 + 1)), Times.Once);
                _consoleIOMock.Verify(c => c.Write("Guess: "), Times.Exactly(attempts.Count));
                _consoleIOMock.Verify(c => c.Write("   |   "), Times.Exactly(attempts.Count));
                _consoleIOMock.Verify(c => c.Write("Hint: "), Times.Exactly(attempts.Count));
                _consoleIOMock.Verify(c => c.WriteLine(""), Times.Exactly(attempts.Count + 1));
            }
        }

        [Fact]
        public void DisplayCodeBreaker_ShouldCorrectlyDisplayCodeBreaker()
        {
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayCodeBreaker();
            _consoleIOMock.Verify(c => c.WriteLine("*********"));
        }

        [Fact]
        public void DisplayWin_ShouldCorrectlyDisplayWin()
        {
            var uo = new UserOutput(_consoleIOMock.Object);
            uo.DisplayCodeBreaker();
            _consoleIOMock.Verify(c => c.WriteLine(""));
        }
    }
}