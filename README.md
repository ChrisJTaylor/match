# Instructions

## Prerequisites

The solution is written in C# and uses .Net 6, so you will need to install this if you don't already have it.

[Install .Net 6 here](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
### How to build

Type `dotnet build` in the solution root to restore the packages and build the solution.

### How to run tests

Type `dotnet test` in the solution root to run all the unit tests in the solution.

## How to run the game

Navigate to the `Match` application folder, then type `dotnet run`.

The game will ask you how many packs of cards you would like to build the game deck from, in a range of 1 to 9.

The game will then ask you to select the matching condition to be used, from the following:
- 1: Card Value
- 2: Card Suit
- 3: Card Value and Card Suit

After the selections are complete, the game will run a simulation of a game between Jack and Jill.
When they have played through all the cards in the Deck, the result will be displayed.
