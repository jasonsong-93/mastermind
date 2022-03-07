namespace Mastermind.IO
{
    public interface IUserOutput
    {
        void DisplayIntroMessage();
        void DisplayFinished();
        void DisplayIncorrect();
    }
}