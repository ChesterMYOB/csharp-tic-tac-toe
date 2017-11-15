﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TicTacToe.UnitTest
{
    public class GameStateCheckerShould
    {
        //[Theory]
        //[InlineData(false, new[] {
        //    '-', '-', '-',
        //    '-', '-', '-',
        //    '-', '-', '-'})]
        //public void CheckForWin(bool winStatus, char[] boardState)
        //{
        //    var stateChecker = new GameStateChecker();
        //    var winStatus = stateChecker.HasWon();
        //}

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
            var stateChecker = new GameStateChecker();
            var actual = stateChecker.CheckRows(board);
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
            var stateChecker = new GameStateChecker();
            var actual = stateChecker.CheckColumns(board);
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
            var stateChecker = new GameStateChecker();
            var actual = stateChecker.CheckDiagonals(board);
            Assert.Equal(expected, actual);
        }
    }
}