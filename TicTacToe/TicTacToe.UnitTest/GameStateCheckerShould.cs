﻿using System.Linq;
using TicTacToe.GameBoard;
using TicTacToe.StateChecker;
using Xunit;

namespace TicTacToe.UnitTest
{
    public class GameStateCheckerShould
    {
        [Theory]
        [InlineData(false, new[] {
            '-', '-', '-',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(true, new[] {
            'X', 'X', 'X',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(true, new[] {
            'O', 'O', 'O',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(false, new[] {
            'O', 'X', 'O',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(true, new[] {
            '-', '-', '-',
            'X', 'X', 'X',
            '-', '-', '-'})]
        [InlineData(true, new[] {
            '-', '-', '-',
            '-', '-', '-',
            'X', 'X', 'X'})]
        public void CheckForWinOnRows(bool expected, char[] boardState)
        {
            var board = boardState.Select(token => (Mark) token).ToList();
            var gameStateChecker = new SimpleGameStateChecker();
            var actual = gameStateChecker.CheckRows(board);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, new[] {
            '-', '-', '-',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(true, new[] {
            'X', '-', '-',
            'X', '-', '-',
            'X', '-', '-'})]
        [InlineData(true, new[] {
            'O', '-', '-',
            'O', '-', '-',
            'O', '-', '-'})]
        [InlineData(false, new[] {
            'O', '-', '-',
            'X', '-', '-',
            'O', '-', '-'})]
        [InlineData(true, new[] {
            '-', 'X', '-',
            '-', 'X', '-',
            '-', 'X', '-'})]
        [InlineData(true, new[] {
            '-', '-', 'X',
            '-', '-', 'X',
            '-', '-', 'X'})]
        public void CheckForWinOnColumns(bool expected, char[] boardState)
        {
            var board = boardState.Select(token => (Mark)token).ToList();
            var gameStateChecker = new SimpleGameStateChecker();
            var actual = gameStateChecker.CheckColumns(board);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, new[] {
            '-', '-', '-',
            '-', '-', '-',
            '-', '-', '-'})]
        [InlineData(true, new[] {
            'X', '-', '-',
            '-', 'X', '-',
            '-', '-', 'X'})]
        [InlineData(true, new[] {
            'O', '-', '-',
            '-', 'O', '-',
            '-', '-', 'O'})]
        [InlineData(false, new[] {
            'O', '-', '-',
            '-', 'X', '-',
            '-', '-', 'O'})]
        [InlineData(true, new[] {
            '-', '-', 'X',
            '-', 'X', '-',
            'X', '-', '-'})]
        public void CheckForWinOnDiagrams(bool expected, char[] boardState)
        {
            var board = boardState.Select(token => (Mark)token).ToList();
            var gameStateChecker = new SimpleGameStateChecker();
            var actual = gameStateChecker.CheckDiagonals(board);
            Assert.Equal(expected, actual);
        }
    }
}
