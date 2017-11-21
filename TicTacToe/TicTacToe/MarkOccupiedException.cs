using System;

namespace TicTacToe
{
    public class MarkOccupiedException : Exception
    {
        public MarkOccupiedException(string message) : base(message)
        {
        }
    }
}