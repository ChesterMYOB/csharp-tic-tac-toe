using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe.GameBoard;

namespace TicTacToe.Renderer
{
    public class ConsoleRenderer : IRenderer
    {
        public void RenderWelcomeMessage()
        {
            Console.WriteLine("Welcome to TicTacToe!");
        }

        public void RenderNewGame(List<Mark> boardState)
        {
            Console.WriteLine("New game:");
            RenderBoard(boardState);
        }

        public void RenderBoard(List<Mark> boardState)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            var board = new StringBuilder();
            board.Append("    |     |     ").AppendLine();
            var b1 = " {0}  |  {1}  |  {2}  ";
            board.Append(string.Format(b1, (char) boardState[0], (char) boardState[1], (char) boardState[2]))
                .AppendLine();
            board.Append("____|_____|_____").AppendLine();
            board.Append("    |     |     ").AppendLine();
            var b2 = " {0}  |  {1}  |  {2}  ";
            board.Append(string.Format(b2, (char) boardState[3], (char) boardState[4], (char) boardState[5]))
                .AppendLine();
            board.Append("____|_____|_____").AppendLine();
            board.Append("    |     |     ").AppendLine();
            var b3 = " {0}  |  {1}  |  {2}  ";
            board.Append(string.Format(b3, (char) boardState[6], (char) boardState[7], (char) boardState[8]))
                .AppendLine();
            board.Append("    |     |     ").AppendLine();
            Console.WriteLine(board.ToString());
            Console.ResetColor();
        }

        public void RenderSelectorBoard(List<Mark> boardState)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            var charBoard = boardState.Select(mark => ((char) mark).ToString()).ToArray();
            for (var i = 0; i < charBoard.Length; i++)
                if (charBoard[i].Equals("-")) charBoard[i] = (i + 1).ToString();

            var board = new StringBuilder();
            board.Append("    |     |     ").AppendLine();
            var b1 = " {0}  |  {1}  |  {2}  ";
            board.Append(string.Format(b1, charBoard[0], charBoard[1], charBoard[2])).AppendLine();
            board.Append("____|_____|_____").AppendLine();
            board.Append("    |     |     ").AppendLine();
            var b2 = " {0}  |  {1}  |  {2}  ";
            board.Append(string.Format(b2, charBoard[3], charBoard[4], charBoard[5])).AppendLine();
            board.Append("____|_____|_____").AppendLine();
            board.Append("    |     |     ").AppendLine();
            var b3 = " {0}  |  {1}  |  {2}  ";
            board.Append(string.Format(b3, charBoard[6], charBoard[7], charBoard[8])).AppendLine();
            board.Append("    |     |     ").AppendLine();
            Console.WriteLine(board.ToString());
            Console.ResetColor();
        }

        public bool QueryAboutAnotherGame()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var response = "";
            Console.WriteLine("Do you want to play again?");
            while (response?.ToUpper() != "Y" && response?.ToUpper() != "N")
            {
                Console.WriteLine("(Y)es or (N)o");
                response = Console.ReadLine();
            }
            Console.ResetColor();
            return response.ToUpper().Equals("Y");
        }

        public void RenderGameIsADrawScreen()
        {
            Console.WriteLine("IT'S A DRAW!");
        }

        public void RenderWinGameScreen(Mark mark)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("YOU WIN PLAYER " + (char) mark);
            Console.ResetColor();
        }

        public void RenderSimpleMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void RenderErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}