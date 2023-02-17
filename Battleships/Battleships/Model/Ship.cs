namespace Battleships.Model
{
    public class Ship : IShip
    {
        public int Size { get; private set; }
        public int Health { get; private set; }

        public Ship(ShipSize size)
        {
            Size = (int)size;
            Health = (int)size;
        }

        public void Hit()
        {
            if (Health == 0)
            {
                return;
            }

            Health--;
        }

        public bool IsSunk()
        {
            return Health == 0;
        }
    }
}