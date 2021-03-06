using System;
using Mastermind.IO;
using Mastermind.Model;

var io = new ConsoleIO();
var userOutput = new UserOutput(io);
var userInput = new UserInput(io, userOutput);
var rand = new Random();
var randomizer = new Randomizer(rand);
var maker = new CodeMaker(randomizer);
var breaker = new CodeBreaker(userInput, userOutput);
var gameState = new GameState();

var ge = new GameEngine(breaker, maker, userInput, userOutput, gameState);
var stats = ge.Run();
stats.Display();