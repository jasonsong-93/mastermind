﻿using System;
using Mastermind.IO;

namespace Mastermind
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            var io = new ConsoleIO();
            var userInput = new UserInput(io);
            var userOutput = new UserOutput(io);
            var rand = new Randomizer();
            var maker = new CodeMaker(rand);
            var breaker = new CodeBreaker(userInput, userOutput);
            var gameState = new GameState();

            var ge = new GameEngine(breaker, maker, userInput, userOutput, gameState);
            var stats = ge.Run();
            io.Write(stats.ToString());
        }
    }
}