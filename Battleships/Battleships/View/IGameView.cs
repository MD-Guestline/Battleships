using Battleships.Model;

namespace Battleships.View
{
    public interface IGameView
    {
        void DisplayGrid(IGrid grid);
        string GetPlayerMove();
        void DisplayErrorMessage(string errorMessage);
        void DisplayGameOverMessage();
    }
}