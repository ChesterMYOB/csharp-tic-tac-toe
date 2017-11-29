using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToe.StateChecker;

namespace TicTacToe.GameBoard
{
    public class SimpleGameBoard : IGameBoard
    {
        private readonly int _boardHeight;
        private readonly int _boardWidth;

        public SimpleGameStateChecker SimpleGameStateChecker { get; set; }
        public List<Mark> BoardState { get; set; }

        public SimpleGameBoard(SimpleGameStateChecker stateChecker)
        {
            SimpleGameStateChecker = stateChecker;
            _boardWidth = 3;
            _boardHeight = 3;
            ResetBoard();
        }

        public void ResetBoard()
        {
            BoardState = Enumerable.Repeat((Mark) '-', _boardHeight * _boardWidth).ToList();
        }

        public Tuple<int, int> MapPosition(int positionChosenOnBoard)
        {
            positionChosenOnBoard--;
            var x = positionChosenOnBoard % _boardWidth;
            var y = positionChosenOnBoard / _boardWidth;
            return new Tuple<int, int>(x, y);
        }

        public bool CheckValidMove(int x, int y)
        {
            var location = x + _boardHeight * y;
            SimpleGameStateChecker.CheckLocationValidity(x, y, _boardWidth, _boardHeight);
            SimpleGameStateChecker.CheckAvalability(BoardState, location);
            return true;
        }

        public void AddMarkToBoard(Mark mark, int x, int y)
        {
            var location = x + _boardHeight * y;
            BoardState[location] = mark;
        }
    }
}