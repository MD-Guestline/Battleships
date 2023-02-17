## Battleships Game

This is a simple one-sided Battleships game console application built with C\# and .NET 7.0. The game randomly places three ships (a Battleship of size 5, and two Destroyers of size 4) on a 10 x 10 grid. The player then takes turns shooting at coordinates (by entering coordinates of the form A5, where A is the column and 5 is the row). Each shot either results in a hit, a miss, or a sink. The game ends when all the placed ships have been sunk.

## Prerequisites

To build and run the source code, you will need:

- [Visual Studio 2022 version 17.4 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the .NET desktop development workload installed. The .NET 7 SDK is automatically installed when you select this workload.

For more information, see [Install the .NET SDK with Visual Studio.](https://learn.microsoft.com/en-us/dotnet/core/install/windows#install-with-visual-studio)

## Building and Running

1. Clone the repository
2. Open the solution file (`Battleships.sln`) in Visual Studio.
3. Build the solution.
4. Run the `Battleships` project.

## Running Tests

This project uses [NUnit](https://nunit.org/) for unit testing and [Moq](https://github.com/moq/moq4) for mocking.

1. Open the solution file (`Battleships.sln`) in Visual Studio.
2. Build the solution.
3. In Visual Studio, go to Test > Run All Tests.

## Running the Game without .NET Installation

For users who do not have .NET installed, there is a `windows-x64` executable available in the [releases section](https://github.com/MD-Guestline/Battleships/releases) of this repository. Simply download and run the executable to play the game.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.
