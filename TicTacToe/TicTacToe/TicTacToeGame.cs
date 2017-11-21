using System.Security.Cryptography.X509Certificates;

namespace TicTacToe.UnitTest
{
    public class TicTacToeGame
    {
        public ConsoleRenderer Renderer { get; set; }
        public SimpleGameBoard GameBoard { get; set; }

        public TicTacToeGame()
        {
            GameBoard = new SimpleGameBoard();;
            Renderer = new ConsoleRenderer();
        }

        public void RenderBoard()
        {
            Renderer.RenderBoard(GameBoard.BoardState);
        }
    }
}