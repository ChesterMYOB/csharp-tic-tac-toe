using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameStateChecker
    {
        public bool HasWon(List<Mark> boardState)
        {
            var checks = new List<bool>
            {
                CheckRows(boardState),
                CheckColumns(boardState),
                CheckDiagonals(boardState)
            };
            return checks.All(c => c);
        }

        public bool CheckRows(List<Mark> boardState)
        {
            var row1 = new List<Mark> { boardState[0], boardState[1], boardState[2] };
            var row2 = new List<Mark> { boardState[3], boardState[4], boardState[5] };
            var row3 = new List<Mark> { boardState[6], boardState[7], boardState[8] };
            return AllMarksTheSame(row1) || AllMarksTheSame(row2) || AllMarksTheSame(row3);
        }

        public bool CheckColumns(List<Mark> boardState)
        {
            var col1 = new List<Mark> { boardState[0], boardState[3], boardState[6] };
            var col2 = new List<Mark> { boardState[1], boardState[4], boardState[7] };
            var col3 = new List<Mark> { boardState[2], boardState[5], boardState[8] };
            return AllMarksTheSame(col1) || AllMarksTheSame(col2) || AllMarksTheSame(col3);
        }

        public bool CheckDiagonals(List<Mark> boardState)
        {
            var diag1 = new List<Mark> { boardState[0], boardState[4], boardState[8] };
            var diag2 = new List<Mark> { boardState[2], boardState[4], boardState[6] };
            return AllMarksTheSame(diag1) || AllMarksTheSame(diag2);
        }

        private static bool AllMarksTheSame(IReadOnlyCollection<Mark> marks)
        {
            return marks.All(x => x == Mark.Cross) || marks.All(x => x == Mark.Naught);
        }
    }
}


