using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class ConsoleRenderer
    {
        public void RenderBoard(List<Mark> boardState)
        {
            var board = new StringBuilder();
            board.Append("    |     |     ");
            var b1 = (" {0}  |  {1}  |  {2}  ");
            string.Format(b1, boardState[0], boardState[1], boardState[2]);
            board.Append("____|_____|_____");
            board.Append("    |     |     ");
            var b2 = (" {0}  |  {1}  |  {2}  ");
            string.Format(b2, boardState[3], boardState[4], boardState[5]);
            board.Append("____|_____|_____");
            board.Append("    |     |     ");
            var b3 = (" {0}  |  {1}  |  {2}  ");
            string.Format(b3, boardState[6], boardState[7], boardState[8]);
            board.Append("    |     |     ");
            Console.WriteLine(board.ToString());
        }
    }
}