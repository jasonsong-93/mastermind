using System;

namespace Mastermind
{
    class UserInput : IUserInput
    {
        public int BoardSize()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public int MaximumAttempts()
        {
            throw new System.NotImplementedException();
        }

        public int NumberOfColors()
        {
            throw new System.NotImplementedException();
        }

        public bool DuplicatesAllowed()
        {
            throw new System.NotImplementedException();
        }

        public bool SinglePlayerMode()
        {
            throw new System.NotImplementedException();
        }
    }
}