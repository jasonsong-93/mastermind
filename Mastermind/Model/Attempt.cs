using System;
using System.Collections.Generic;

namespace Mastermind.Model
{
    public class Attempt
    {
        public readonly Color[] Guess;
        public readonly List<ResultColor> Result;

        public Attempt(Color[] guess, List<ResultColor> result)
        {
            Guess = guess;
            Result = result;
        }

        private bool Equals(Attempt other)
        {
            return Equals(Guess, other.Guess) && Equals(Result, other.Result);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Attempt) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Guess, Result);
        }
    }
}