using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using NUnit.Framework;
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

            Exception ex = Assert.Throws<MarkOccupiedException>(() => gameBoard.AddMarkToBoard(Mark.Cross, 1, 1));
            Assert.Equal("Mark Occupied!", ex.Message);
        }

        [Theory]
        [InlineData(Mark.Cross, -1, 0)]
        public void ReturnErrorWhenAddingMarkToNoneBoardArea(Mark mark, int x, int y)
        {
            var gameBoard = new SimpleGameBoard();

            Exception ex = Assert.Throws<InvalidMarkPlacementException>(() => gameBoard.AddMarkToBoard(mark, x, y));
            Assert.Equal("Mark ", ex.Message);
        }
    }
}
