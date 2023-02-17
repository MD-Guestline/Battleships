using Battleships.Model;

namespace Battleships
{
    public interface IRandomGenerator
    {
        Orientation NextOrientation();
        int NextNumber(int minValue, int maxValue);
    }
}