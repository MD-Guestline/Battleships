using Battleships.Factories;
using Battleships.Model;
using Battleships.View;
using Microsoft.Extensions.DependencyInjection;

namespace Battleships
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<Game>();
            services.AddScoped<IGrid, Grid>();
            services.AddScoped<IGameView, GameView>();
            services.AddSingleton<IShipPlacementFactory, ShipPlacementFactory>();
            services.AddSingleton<IRandomGenerator, RandomGenerator>();

            return services;
        }
    }
}