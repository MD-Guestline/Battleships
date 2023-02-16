namespace Battleships.View
{
    public static class ConsoleHelper
	{
		public static void WriteInColor(string text, ConsoleColor colour)
		{
			var defaultColour = Console.ForegroundColor;

			Console.ForegroundColor = colour;
			Console.Write(text);
            Console.ForegroundColor = defaultColour;
        }

        public static void WriteLineInColor(string text, ConsoleColor colour)
        {
            var defaultColour = Console.ForegroundColor;

            Console.ForegroundColor = colour;
            Console.Write(text);
            Console.ForegroundColor = defaultColour;
        }

        public static void ClearLine()
		{
            Console.Write("\r" + new string(' ', Console.BufferWidth - 1) + "\r");
        }
	}
}