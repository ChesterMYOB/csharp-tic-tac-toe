using System;

namespace TicTacToe.Exceptions
{
    public class MarkOccupiedException : Exception
    {
        public MarkOccupiedException(string message) : base(message)
        {
        }
    }
}