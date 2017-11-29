using System;

namespace TicTacToe.Exceptions
{
    public class InvalidMarkPlacementException : Exception
    {
        public InvalidMarkPlacementException(string message) : base(message)
        {
        }
    }
}