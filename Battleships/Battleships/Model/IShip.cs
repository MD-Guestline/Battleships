namespace Battleships.Model
{
	public interface IShip
	{
        int Size { get; }

        void Hit();
		bool IsSunk(); 
	}
}