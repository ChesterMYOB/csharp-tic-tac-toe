using System.Collections.Generic;
using TicTacToe.GameBoard;

namespace TicTacToe.Player
{
    public interface IPlayer
    {
        Mark PlayersMark { get; set; }
        int TakeTurn(List<Mark> boardState);
    }
}
