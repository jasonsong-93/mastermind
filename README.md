
# Mastermind Kata

Jason Song - Quorum Review 1, MYOB. 



## Features

- Light/dark mode toggle
- Live previews
- Fullscreen mode
- Cross platform


## Acknowledgements
I would like to say a big thank you to my mentors, Luke Wang and Tuan Anh Le 
## Game Rules

Mastermind is a code-breaking game for two players. 

The game is played using:
- A decoding board, with a shield at one end covering a row of four large holes, and twelve (or ten, or eight, or six) additional rows containing four large holes next to a set of four small holes;
- Code pegs of six different colors (or more; see Variations below), with round heads, which will be placed in the large holes on the board

In our modified version, you are able to select the number of rounds you play against an AI which auto generates the solution you must break. The number of pegs/holes will be between 4 - 6.

Please note that the hint you receive is completely randomized (unlike Wordle for example), adding an additional layer of difficulty.

| Text             | Colour                                                                |
| ----------------- | ------------------------------------------------------------------ |
| Red | 🔴 |
| Blue | 🔵 |
| Green | 🟢 |
| Orange | 🟠 |
| Purple | 🟣 |
| Yellow | 🟡 |

## Authors

- [@jasonsong-93](https://www.github.com/jasonsong-93)



## Usage/Examples

To run the game, , navigate to the Mastermind folder and use the command:
```c#
dotnet run
```
To run the game, , navigate to the Mastermind.Tests folder and use the command:
```c#
dotnet test
```

## Optimizations

The main Optimizations in the codebase would be to the following:
- Implementing a better algorithm for code breaker
- Allow the input to be of any type by allowing the input data type to be flexible via the C# feature of Generic types
- Provide various modes so the user is able to use numbers, colours or even images (Wikipedia contains multiple various versions of the game)
