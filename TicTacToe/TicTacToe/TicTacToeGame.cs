using System.Security.Cryptography.X509Certificates;

namespace TicTacToe.UnitTest
{
    public class TicTacToeGame
    {
        public ConsoleRenderer renderer { get; set; }
        public SimpleGameBoard gameBoard { get; set; }

        public TicTacToeGame()
        {
            renderer = new ConsoleRenderer();


        }

        public void RenderBoard()
        {
            renderer.Render();
        }
    }
}