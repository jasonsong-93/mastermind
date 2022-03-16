namespace Mastermind.IO.Interfaces
{
    public interface IConsoleIO
    {
        void WriteLine(string s);
        void Write(string s);
        string ReadLine();
        void Clear();
        void ReadKey();
    }
}