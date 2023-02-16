using Microsoft.Extensions.DependencyInjection;

namespace Battleships
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = Startup.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            Console.Write("Welcome to Battleships! Press any key to start.");
            Console.ReadLine();

            var game = serviceProvider?.GetService<Game>();

            if (game == null)
            {
                Console.WriteLine("There was a problem loading the game. Press any key to exit.");
                Console.ReadLine();
                return;
            }

            RunGame(game);
        }

        private static void RunGame(Game game)
        {
            game.Start();

            while (!game.IsOver())
            {
                game.ProcessPlayerMove();
            }

            game.End();
        }
    }
}