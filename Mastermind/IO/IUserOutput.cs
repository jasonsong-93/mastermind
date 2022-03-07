using System.Collections.Generic;

namespace Mastermind.IO
{
    public interface IUserOutput
    {
        void DisplayIntroMessage();
        void DisplayFinished();
        void DisplayIncorrect();
        void DisplayResult(List<Color> result);
        void DisplayMaxRoundsExceeded();
    }
}