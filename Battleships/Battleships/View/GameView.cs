using Battleships.Model;

namespace Battleships.View
{
    public class GameView : IGameView
	{
        public void DisplayGrid(IGrid grid)
        {
            Console.Clear();
            Console.WriteLine(@"
      __    ______    __ __      __  
     |__) /\ |  | |  |_ (_ |__|||__) 
     |__)/--\|  | |__|____)|  |||  
            ");
            Console.WriteLine();
            Console.WriteLine("     [A][B][C][D][E][F][G][H][I][J]");
            Console.WriteLine("     ------------------------------");

            for (var rowIndex = 0; rowIndex < Grid.Size; rowIndex++)
            {
                Console.Write(string.Format("{0,5}", $"[{rowIndex + 1}]|"));

                for (var colIndex = 0; colIndex < Grid.Size; colIndex++)
                {
                    PrintGridSquare(grid.GetSquare(colIndex, rowIndex));
                }

                Console.WriteLine($"|[{rowIndex + 1}]");
            }

            Console.WriteLine("     ------------------------------");
            Console.WriteLine("     [A][B][C][D][E][F][G][H][I][J]");
            Console.WriteLine();
            PrintLegend();
        }

        public string GetPlayerMove()
        {
            ConsoleHelper.ClearLine();
            Console.Write("Enter the coordinates you want to target (e.g. A5): ");
            string? playerMove = null;

            while (playerMove == null)
            {
                playerMove = Console.ReadLine();
            }

            return playerMove;
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            ConsoleHelper.ClearLine();
            ConsoleHelper.WriteLineInColor($"Error: {errorMessage}", ConsoleColor.Red);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
        }

        public void DisplayGameOverMessage()
        {
            Console.WriteLine("Congratulations, you sunk all the enemy ships! Press any key to exit.");
            Console.ReadLine();
        }

        private static void PrintGridSquare(GridSquare gridSquare)
        {
            if (!gridSquare.IsShot)
            {
                ConsoleHelper.WriteInColor("[ ]", ConsoleColor.Blue);
                return;
            }

            if (gridSquare.Ship == null)
            {
                ConsoleHelper.WriteInColor("[M]", ConsoleColor.DarkGray);
                return;
            }

            if (gridSquare.Ship != null && !gridSquare.Ship.IsSunk())
            {
                ConsoleHelper.WriteInColor("[H]", ConsoleColor.Red);
                return;
            }

            if (gridSquare.Ship != null && gridSquare.Ship.IsSunk())
            {
                ConsoleHelper.WriteInColor("[S]", ConsoleColor.DarkYellow);
                return;
            }
        }

        private static void PrintLegend()
        {
            ConsoleHelper.WriteInColor("[ ]", ConsoleColor.Blue);
            Console.Write(" - Untargeted, ");
            ConsoleHelper.WriteInColor("[M]", ConsoleColor.DarkGray);
            Console.Write(" - Miss, ");
            ConsoleHelper.WriteInColor("[H]", ConsoleColor.Red);
            Console.Write(" - Hit, ");
            ConsoleHelper.WriteInColor("[S]", ConsoleColor.DarkYellow);
            Console.Write(" - Sunk");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}