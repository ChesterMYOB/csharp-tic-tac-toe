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
            if (row1.All(x => x == Mark.Cross) || row1.All(x => x == Mark.Naught)) return true;

            var row2 = new List<Mark> { boardState[3], boardState[4], boardState[5] };
            if (row2.All(x => x == Mark.Cross) || row2.All(x => x == Mark.Naught)) return true;

            var row3 = new List<Mark> { boardState[6], boardState[7], boardState[8] };
            if (row3.All(x => x == Mark.Cross) || row3.All(x => x == Mark.Naught)) return true;

            return false;
        }

        public bool CheckColumns(List<Mark> boardState)
        {
            var col1 = new List<Mark> { boardState[0], boardState[3], boardState[6] };
            if (col1.All(x => x == Mark.Cross) || col1.All(x => x == Mark.Naught)) return true;

            var col2 = new List<Mark> { boardState[1], boardState[4], boardState[7] };
            if (col2.All(x => x == Mark.Cross) || col2.All(x => x == Mark.Naught)) return true;

            var col3 = new List<Mark> { boardState[2], boardState[5], boardState[8] };
            if (col3.All(x => x == Mark.Cross) || col3.All(x => x == Mark.Naught)) return true;

            return false;
        }

        public bool CheckDiagonals(List<Mark> boardState)
        {
            var diag1 = new List<Mark> { boardState[0], boardState[4], boardState[8] };
            if (diag1.All(x => x == Mark.Cross) || diag1.All(x => x == Mark.Naught)) return true;

            var diag2 = new List<Mark> { boardState[2], boardState[4], boardState[6] };
            if (diag2.All(x => x == Mark.Cross) || diag2.All(x => x == Mark.Naught)) return true;

            return false;
        }
    }
}


