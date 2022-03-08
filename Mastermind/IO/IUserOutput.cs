using System.Collections.Generic;

namespace Mastermind.IO
{
    public interface IUserOutput
    {
        void DisplayMenu();
        void DisplayFinished();
        void DisplayResult(List<ResultColor> result);
        void DisplayMaxRoundsExceeded();
        void DisplayAttempts(List<Attempt> attempts);
        void DisplayCodeBreaker();
        void PromptUserForColor();
        void PromptUserForMaxRounds();
    }
}