using System.Collections.Generic;
using TicTacToe.GameBoard;

namespace TicTacToe.StateChecker
{
    public interface IStateChecker
    {
        bool HasWon(List<Mark> boardState);
    }
}


