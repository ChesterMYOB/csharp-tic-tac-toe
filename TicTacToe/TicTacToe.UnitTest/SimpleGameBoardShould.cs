using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TicTacToe.Exceptions;
using TicTacToe.GameBoard;
using TicTacToe.StateChecker;
using Xunit;
using Assert = Xunit.Assert;
using Theory = Xunit.TheoryAttribute;

namespace TicTacToe.UnitTest
{
    public class SimpleGameBoardShould
    {
        [Theory]
        [InlineData(Mark.Naught, 0, 0, new[] {
            'O', '-', '-',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(Mark.Cross, 0, 0, new[] {
            'X', '-', '-',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(Mark.Cross, 1, 0, new[] {
            '-', 'X', '-',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(Mark.Cross, 2, 0, new[] {
            '-', '-', 'X',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(Mark.Cross, 0, 1, new[] {
            '-', '-', '-',
            'X', '-', '-',
            '-', '-', '-'})]
        [InlineData(Mark.Cross, 1, 1, new[] {
            '-', '-', '-',
            '-', 'X', '-',
            '-', '-', '-'})]
        [InlineData(Mark.Cross, 2, 1, new[] {
            '-', '-', '-',
            '-', '-', 'X',
            '-', '-', '-'})]
        [InlineData(Mark.Cross, 0, 2, new[] {
            '-', '-', '-',
            '-', '-', '-',
            'X', '-', '-'})]
        [InlineData(Mark.Cross, 1, 2, new[] {
            '-', '-', '-',
            '-', '-', '-',
            '-', 'X', '-'})]
        [InlineData(Mark.Cross, 2, 2, new[] {
            '-', '-', '-',
            '-', '-', '-',
            '-', '-', 'X'})]
        public void AddMarkToTheBoard(Mark mark, int x, int y, char[] expectedState)
        {
            var gameBoard = new SimpleGameBoard();
            gameBoard.AddMarkToBoard(mark, x, y);

            var expected = expectedState.Select(token => (Mark)token).ToList();
            CollectionAssert.AreEqual(expected, gameBoard.BoardState);
        }

        [Fact]
        public void ReturnErrorWhenAddingMarkToOccupiedArea()
        {
            var gameBoard = new SimpleGameBoard
            {
                BoardState = new List<Mark>
                {
                    Mark.Empty,Mark.Empty,Mark.Empty,
                    Mark.Empty,Mark.Cross,Mark.Empty,
                    Mark.Empty,Mark.Empty,Mark.Empty
                }
            };

            System.Exception ex = Assert.Throws<MarkOccupiedException>(() => gameBoard.AddMarkToBoard(Mark.Cross, 1, 1));
            Assert.Equal("Mark occupied!", ex.Message);
        }

        [Theory]
        [InlineData(Mark.Cross, -1, -1)]
        [InlineData(Mark.Cross, -1, 0)]
        [InlineData(Mark.Cross, -1, 1)]
        [InlineData(Mark.Cross, 0, -1)]
        [InlineData(Mark.Cross, 1, -1)]
        [InlineData(Mark.Cross, 3, 3)]
        [InlineData(Mark.Cross, 3, 2)]
        [InlineData(Mark.Cross, 3, 1)]
        [InlineData(Mark.Cross, 2, 3)]
        [InlineData(Mark.Cross, 1, 3)]
        public void ReturnErrorWhenAddingMarkToNoneBoardArea(Mark mark, int x, int y)
        {
            var gameBoard = new SimpleGameBoard();

            System.Exception ex = Assert.Throws<InvalidMarkPlacementException>(() => gameBoard.AddMarkToBoard(mark, x, y));
            Assert.Equal("Mark placed wrongly!", ex.Message);
        }

        [Fact]
        public void ReturnTrueForTie_WhenAllCellsAreOccupied()
        {
            var gameBoard = new SimpleGameBoard
            {
                BoardState = new List<Mark>
                {
                    Mark.Cross,Mark.Cross,Mark.Cross,
                    Mark.Cross,Mark.Cross,Mark.Cross,
                    Mark.Naught,Mark.Naught,Mark.Naught
                }
            };

            var gameStateChecker = new SimpleGameStateChecker();
            var actual = gameStateChecker.HasDrawn(gameBoard.BoardState);
            Assert.True(actual);
        }

        [Fact]
        public void ReturnFalseForTie_WhenAllCellsAreUnoccupied()
        {
            var gameBoard = new SimpleGameBoard
            {
                BoardState = new List<Mark>
                {
                    Mark.Empty,Mark.Empty,Mark.Empty,
                    Mark.Empty,Mark.Empty,Mark.Empty,
                    Mark.Empty,Mark.Empty,Mark.Empty
                }
            };

            var gameStateChecker = new SimpleGameStateChecker();
            var actual = gameStateChecker.HasDrawn(gameBoard.BoardState);
            Assert.False(actual);
        }

        [Fact]
        public void ReturnFalseForTie_WhenAllButOneCellsAreUnoccupied()
        {
            var gameBoard = new SimpleGameBoard
            {
                BoardState = new List<Mark>
                {
                    Mark.Empty,Mark.Empty,Mark.Empty,
                    Mark.Empty,Mark.Cross,Mark.Empty,
                    Mark.Empty,Mark.Empty,Mark.Empty
                }
            };

            var gameStateChecker = new SimpleGameStateChecker();
            var actual = gameStateChecker.HasDrawn(gameBoard.BoardState);
            Assert.False(actual);
        }
    }
}
