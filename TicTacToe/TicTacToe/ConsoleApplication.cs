using System;
using System.Linq;

namespace TicTacToe
{
    internal class ConsoleApplication
    {
        private static void Main()
        {
            var selectingGameMode = true;
            var players = -1;

            while (selectingGameMode)
            {
                Console.WriteLine("Number of players: (0-2)");
                var line = Console.ReadLine();
                var parsed = int.TryParse(line, out players);

                if (parsed && Enumerable.Range(0, 3).Contains(players))
                    selectingGameMode = false;
            }
            new TicTacToeGame(players).StartGame();
        }
    }
}