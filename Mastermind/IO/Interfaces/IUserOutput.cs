using System.Collections.Generic;
using Mastermind.Model;

namespace Mastermind.IO.Interfaces
{
    public interface IUserOutput
    {
        void DisplayMenu();
        void DisplayWin(Color[] solution);
        void DisplayNotMatchingResult(List<ResultColor> result);
        void DisplayMaxRoundsExceeded(Color[] solution);
        void DisplayCodeBreaker();
        void DisplayBoard(List<Attempt> attempts);
        void PromptUserForColor();
        void PromptUserForMaxRounds();
        void Countdown();
        void DisplayGameState(int maxRounds, int maxPegs);
        void PromptUserForNumPegs();
        void DisplayCurrentRound(int numRounds, int maxRounds);
        void DisplayInvalidRounds();
        void DisplayInvalidNumPegs();
        void DisplayValidColorFromUser(Color color);
        void DisplayInvalidColorFromUser();
        void DisplayStatistics(List<Attempt> historyOfAttempts);
    }
}