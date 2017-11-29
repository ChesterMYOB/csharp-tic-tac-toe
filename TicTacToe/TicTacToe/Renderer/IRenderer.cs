using System.Collections.Generic;
using TicTacToe.GameBoard;

namespace TicTacToe.Renderer
{
    public interface IRenderer
    {
        void RenderWelcomeMessage();

        void RenderNewGame(List<Mark> boardState);

        void RenderBoard(List<Mark> boardState);

        void RenderSelectorBoard(List<Mark> boardState);

        bool QueryAboutAnotherGame();

        void RenderGameIsADrawScreen();

        void RenderWinGameScreen(Mark mark);

        void RenderSimpleMessage(string message);
        void RenderErrorMessage(string message);
    }
}