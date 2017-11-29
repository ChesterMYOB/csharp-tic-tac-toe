using System.Collections.Generic;
using System.Linq;
using TicTacToe.Exceptions;
using TicTacToe.GameBoard;

namespace TicTacToe.StateChecker
{
    public class SimpleGameStateChecker : IStateChecker
    {
        public bool HasWon(List<Mark> boardState)
        {
            var checks = new List<bool>
            {
                CheckRows(boardState),
                CheckColumns(boardState),
                CheckDiagonals(boardState)
            };
            return checks.Any(c => c);
        }

        public bool HasDrawn(List<Mark> boardState)
        {
            return boardState.All(o => o != Mark.Empty);
        }

        public bool CheckRows(List<Mark> boardState)
        {
            var row1 = new List<Mark> {boardState[0], boardState[1], boardState[2]};
            var row2 = new List<Mark> {boardState[3], boardState[4], boardState[5]};
            var row3 = new List<Mark> {boardState[6], boardState[7], boardState[8]};
            return CheckForIdenticalMarks(row1) || CheckForIdenticalMarks(row2) || CheckForIdenticalMarks(row3);
        }

        public bool CheckColumns(List<Mark> boardState)
        {
            var col1 = new List<Mark> {boardState[0], boardState[3], boardState[6]};
            var col2 = new List<Mark> {boardState[1], boardState[4], boardState[7]};
            var col3 = new List<Mark> {boardState[2], boardState[5], boardState[8]};
            return CheckForIdenticalMarks(col1) || CheckForIdenticalMarks(col2) || CheckForIdenticalMarks(col3);
        }

        public bool CheckDiagonals(List<Mark> boardState)
        {
            var diag1 = new List<Mark> {boardState[0], boardState[4], boardState[8]};
            var diag2 = new List<Mark> {boardState[2], boardState[4], boardState[6]};
            return CheckForIdenticalMarks(diag1) || CheckForIdenticalMarks(diag2);
        }

        private static bool CheckForIdenticalMarks(IReadOnlyCollection<Mark> marks)
        {
            return marks.All(x => x == Mark.Cross) || marks.All(x => x == Mark.Naught);
        }

        public void CheckLocationValidity(int x, int y, int width, int height)
        {
            if (0 > x || x > width - 1 || 0 > y || y > height - 1)
                throw new InvalidMarkPlacementException("Mark placed wrongly!");
        }

        public void CheckAvalability(List<Mark> board, int location)
        {
            if (board[location] != Mark.Empty)
                throw new MarkOccupiedException("Mark occupied!");
        }
    }
}