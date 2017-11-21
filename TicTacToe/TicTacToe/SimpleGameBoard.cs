using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class SimpleGameBoard
    {
        public List<Mark> BoardState { get; set; }

        public SimpleGameBoard()
        {
            BoardState = Enumerable.Repeat((Mark)'-', 9).ToList();
        }

        public void AddMarkToBoard(Mark mark, int x, int y)
        {
            if (BoardState[x + 3 * y] != Mark.Empty)
            {
                throw new MarkOccupiedException("Mark Occupied!");
            }
            BoardState[x + 3 * y] = mark;
        }
    }
}
