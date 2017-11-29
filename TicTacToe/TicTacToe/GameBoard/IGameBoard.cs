using System;
using System.Collections.Generic;

namespace TicTacToe.GameBoard
{
    public interface IGameBoard
    {
        List<Mark> BoardState { get; set; }
        void ResetBoard();
        Tuple<int, int> MapPosition(int positionChosenOnBoard);
        bool CheckValidMove(int x, int y);
        void AddMarkToBoard(Mark mark, int x, int y);
    }
}