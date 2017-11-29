using System;
using System.Collections.Generic;
using TicTacToe.GameBoard;
using TicTacToe.Renderer;

namespace TicTacToe.Player
{
    internal class HumanPlayer : IPlayer
    {
        public HumanPlayer(IRenderer renderer, Mark mark)
        {
            Renderer = renderer;
            PlayersMark = mark;
        }

        private IRenderer Renderer { get; }
        public Mark PlayersMark { get; set; }


        public int TakeTurn(List<Mark> boardState)
        {
            Renderer.RenderSimpleMessage("Your turn player " + (char) PlayersMark + ":");

            Renderer.RenderSelectorBoard(boardState);

            var validSelection = false;
            var location = -1;
            while (!validSelection)
            {
                var line = Console.ReadLine();
                var parsed = int.TryParse(line, out location);
                if (!parsed)
                    Renderer.RenderSimpleMessage("Please enter a number! (1-" + boardState.Count + ")");
                else
                    validSelection = true;
            }

            return location;
        }
    }
}