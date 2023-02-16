using Battleships.Model;

namespace Battleships
{
    public class RandomGenerator : IRandomGenerator
	{
        private readonly Random _random;

		public RandomGenerator()
		{
            _random = new Random();
		}

        public Orientation NextOrientation()
        {
            return (Orientation)_random.Next(0, 2);
        }

        public int NextNumber(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
    }
}