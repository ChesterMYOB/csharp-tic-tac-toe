
using System.Collections.Generic;
using System.Linq;
using TicTacToe.GameBoard;
using TicTacToe.Player;
using Xunit;

namespace TicTacToe.UnitTest
{
    public class AISolverShould
    {
        private readonly AISolver _brokenAi;
        public AISolverShould()
        {
            _brokenAi = new AISolver();
        }


        [Theory]
        [InlineData(5, new[] {
            '-', '-', '-',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(9, new[] {
            'O', '-', '-',
            '-', 'X', '-',
            '-', '-', '-'})]
        [InlineData(3, new[] {
            '-', 'O', '-',
            '-', 'X', '-',
            '-', '-', '-'})]
        [InlineData(7, new[] {
            '-', '-', 'O',
            '-', 'X', '-',
            '-', '-', '-'})]
        [InlineData(9, new[] {
            '-', '-', '-',
            '-', 'X', 'O',
            '-', '-', '-'})]
        [InlineData(1, new[] {
            '-', '-', '-',
            '-', 'X', '-',
            '-', '-', 'O'})]
        [InlineData(7, new[] {
            '-', '-', '-',
            '-', 'X', '-',
            '-', 'O', '-'})]
        [InlineData(3, new[] {
            '-', '-', '-',
            '-', 'X', '-',
            'O', '-', '-'})]
        [InlineData(1, new[] {
            '-', '-', '-',
            'O', 'X', '-',
            '-', '-', '-'})]
        public void ComputeTheSecondMoveGivenTheCurrentBoardState(int expectedMove, char[] currentGameBoardState)
        {
            var board = currentGameBoardState.Select(token => (Mark)token).ToList();
            var move = _brokenAi.ComputeNextMove(board);
            Assert.Equal(expectedMove, move);
        }

        [Theory]
        [InlineData(7, new[] {
            '-', 'O', 'X',
            '-', 'X', 'O',
            '-', '-', '-'})]
        [InlineData(9, new[] {
            'X', 'O', '-',
            '-', 'X', 'O',
            '-', '-', '-'})]
        [InlineData(1, new[] {
            '-', 'O', '-',
            '-', 'X', 'O',
            '-', '-', 'X'})]
        [InlineData(3, new[] {
            '-', 'O', '-',
            '-', 'X', 'O',
            'X', '-', '-'})]
        public void ComputeTheFourthMoveWhenYouCanWinTheGame(int expectedMove, char[] currentGameBoardState)
        {
            var board = currentGameBoardState.Select(token => (Mark)token).ToList();
            var move = _brokenAi.CheckForWin(board);
            Assert.Equal(expectedMove, move);
        }

        [Theory]
        [InlineData(9, new[] {
            '-', '-', 'X',
            '-', 'X', '-',
            'O', 'O', '-'})]
        [InlineData(1, new[] {
            '-', '-', 'X',
            'O', 'X', '-',
            'O', '-', '-'})]
        [InlineData(3, new[] {
            'X', '-', '-',
            '-', 'X', 'O',
            '-', '-', 'O'})]
        [InlineData(7, new[] {
            'X', '-', '-',
            '-', 'X', '-',
            '-', 'O', 'O'})]
        [InlineData(1, new[] {
            '-', 'O', 'O',
            '-', 'X', '-',
            'X', '-', '-'})]
        [InlineData(9, new[] {
            '-', '-', 'O',
            '-', 'X', 'O',
            'X', '-', '-'})]
        [InlineData(3, new[] {
            'O', 'O', '-',
            '-', 'X', '-',
            '-', '-', 'X'})]
        [InlineData(7, new[] {
            'O', '-', '-',
            'O', 'X', '-',
            '-', '-', 'X'})]
        public void ComputeTheFourthMoveAndBlockTheOpponent(int expectedMove, char[] currentGameBoardState)
        {
            var board = currentGameBoardState.Select(token => (Mark)token).ToList();
            var move = _brokenAi.ComputeNextMove(board);
            Assert.Equal(expectedMove, move);
        }



        public void ComputeTheFourthMoveGivenTheBoardState(int expectedMove, char[] currentGameBoardState)
        {
            var board = currentGameBoardState.Select(token => (Mark)token).ToList();
            var move = _brokenAi.ComputeNextMove(board);
            Assert.Equal(expectedMove, move);
        }
    }
}
