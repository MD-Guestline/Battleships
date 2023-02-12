namespace Battleships.Model
{
    public class ShipPlacement
	{
		public Orientation Orientation { get; set; }
        public int StartColumn { get; set; }
        public int StartRow { get; set; }

        public ShipPlacement(Orientation orientation, int startColumn, int startRow)
        {
            Orientation = orientation;
            StartColumn = startColumn;
            StartRow = startRow;
        }
    }
}