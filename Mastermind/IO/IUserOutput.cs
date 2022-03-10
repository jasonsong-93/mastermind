using System.Collections.Generic;

namespace Mastermind.IO
{
    public interface IUserOutput
    {
        void DisplayMenu();
        void DisplayFinished();
        void DisplayResult(List<ResultColor> result);
        void DisplayMaxRoundsExceeded();
        void DisplayCodeBreaker();
        void DisplayBoard(List<Attempt> attempts);
        void PromptUserForColor();
        void PromptUserForMaxRounds();
        void Countdown();
        void DisplayGameState(int maxRounds, int maxPegs);
        void PromptUserForNumPegs();
        void DisplayCurrentRound(int numRounds, int maxRounds);
        void ClearOutput();
        void DisplayInvalidRounds();
        void DisplayInvalidNumPegs();
    }
}