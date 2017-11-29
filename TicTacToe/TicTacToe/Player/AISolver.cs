using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TicTacToe.GameBoard;
using TicTacToe.StateChecker;

namespace TicTacToe.Player
{
    public class AISolver : IPlayer
    {
        private readonly IStateChecker _simpleGameStateChecker;
        public Mark PlayersMark { get; set; }


        public AISolver()
        {
            PlayersMark = Mark.Cross;
            _simpleGameStateChecker = new SimpleGameStateChecker();
        }
        public AISolver(Mark mark)
        {
            PlayersMark = mark;
            _simpleGameStateChecker = new SimpleGameStateChecker();
        }

        public int TakeTurn(List<Mark> boardState)
        {
            AIThinking();
            return ComputeNextMove(boardState);
        }

        public int ComputeNextMove(List<Mark> gameBoardState)
        {
            var totalMarks = gameBoardState.Count(name => name != Mark.Empty);
            switch (totalMarks)
            {
                case 0:
                    return MakeFirstMove(gameBoardState);
                case 2:
                    return MakeSecondMove(gameBoardState);
                default:
                    return MakeRandomMove(gameBoardState);
            }
        }

        public int MakeFirstMove(List<Mark> gameBoardState)
        {
            return 5;
        }

        private int MakeSecondMove(List<Mark> gameBoardState)
        {
            var index = gameBoardState.FindIndex(a => a == Mark.Naught) + 1;
            if (index % 2 != 0) return 10 - index;
            if (index > 5) return 15 - index;
            return 5 - index;
        }

        private int MakeRandomMove(List<Mark> gameBoardState)
        {
            var move = CheckForWin(gameBoardState);
            if (move != null) return (int) move;
            move = CheckForPotentialBlock(gameBoardState);
            if (move != null) return (int) move;
            return RandomMove(gameBoardState);
        }

        public int? CheckForWin(List<Mark> gameBoardState)
        {
            for (var i = 0; i < gameBoardState.Count; i++)
                if (gameBoardState[i].Equals(Mark.Empty))
                {
                    gameBoardState[i] = Mark.Cross;
                    var won = _simpleGameStateChecker.HasWon(gameBoardState);
                    gameBoardState[i] = Mark.Empty;
                    if (won) return i + 1;
                }
            return null;
        }

        public int? CheckForPotentialBlock(List<Mark> gameBoardState)
        {
            for (var i = 0; i < gameBoardState.Count; i++)
                if (gameBoardState[i].Equals(Mark.Empty))
                {
                    gameBoardState[i] = Mark.Naught;
                    var won = _simpleGameStateChecker.HasWon(gameBoardState);
                    gameBoardState[i] = Mark.Empty;
                    if (won) return i + 1;
                }
            return null;
        }

        private int RandomMove(List<Mark> gameBoardState)
        {
            var random = new Random();
            while (true)
            {
                var i = random.Next(0, 9);
                if (gameBoardState[i].Equals(Mark.Empty))
                    return i + 1;
            }
        }

        public void AIThinking()
        {
            Console.WriteLine("AI turn:");
            Console.WriteLine("Thinking...");
            var spin = new ConsoleSpinner();

            for (var i = 0; i < 20; i++)
            {
                Thread.Sleep(100);
                spin.Turn();
            }
        }
    }
}