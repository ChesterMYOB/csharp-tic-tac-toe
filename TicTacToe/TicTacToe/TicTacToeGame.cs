using TicTacToe.Exceptions;
using TicTacToe.GameBoard;
using TicTacToe.Player;
using TicTacToe.Renderer;
using TicTacToe.StateChecker;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private bool _isPlaying = true;
        private bool _shouldPlayAnotherGame = true;

        public TicTacToeGame(int players)
        {
            StateChecker = new SimpleGameStateChecker();
            GameBoard = new SimpleGameBoard(StateChecker);
            Renderer = new ConsoleRenderer();
            switch (players)
            {
                case 1:
                    PlayerOne = new SolverWhichCanOnlyPlayIfItGoesFirst();
                    PlayerTwo = new HumanPlayer(Renderer, Mark.Naught);
                    break;
                case 2:
                    PlayerOne = new HumanPlayer(Renderer, Mark.Cross);
                    PlayerTwo = new HumanPlayer(Renderer, Mark.Naught);
                    break;
                default:
                    PlayerOne = new SolverWhichCanOnlyPlayIfItGoesFirst();
                    PlayerTwo = new SolverWhichCanOnlyPlayIfItGoesFirst();
                    break;
            }
        }

        public TicTacToeGame(IPlayer playerOne, IPlayer playerTwo)
        {
            StateChecker = new SimpleGameStateChecker();
            GameBoard = new SimpleGameBoard(StateChecker);
            Renderer = new ConsoleRenderer();
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }

        public IRenderer Renderer { get; set; }
        public IGameBoard GameBoard { get; set; }
        public IPlayer PlayerOne { get; set; }
        public IPlayer PlayerTwo { get; set; }
        public SimpleGameStateChecker StateChecker { get; set; }


        public void StartGame()
        {
            Renderer.RenderWelcomeMessage();

            while (_shouldPlayAnotherGame)
            {
                StartNewGame();
                _isPlaying = true;

                while (_isPlaying)
                    PlayRound();
                _shouldPlayAnotherGame = Renderer.QueryAboutAnotherGame();
            }
        }

        private void StartNewGame()
        {
            GameBoard.ResetBoard();
            Renderer.RenderNewGame(GameBoard.BoardState);
            PlayerTakeTurn(PlayerOne);
        }

        private void PlayRound()
        {
            PlayerTakeTurn(PlayerTwo);
            CheckForWin(PlayerTwo);
            if(_isPlaying)PlayerTakeTurn(PlayerOne);
            if(_isPlaying)CheckForWin(PlayerOne);
            if(_isPlaying)CheckForTie();
        }

        private void PlayerTakeTurn(IPlayer playersTurn)
        {
            var validPosition = false;
            while (!validPosition)
                try
                {
                    var position = playersTurn.TakeTurn(GameBoard.BoardState);
                    var location = GameBoard.MapPosition(position);
                    GameBoard.CheckValidMove(location.Item1, location.Item2);
                    GameBoard.AddMarkToBoard(playersTurn.PlayersMark, location.Item1, location.Item2);
                    validPosition = true;
                }
                catch (InvalidMarkPlacementException e)
                {
                    Renderer.RenderErrorMessage(e.Message);
                }
                catch (MarkOccupiedException e)
                {
                    Renderer.RenderErrorMessage(e.Message);
                }

            RenderBoard();
        }

        private void CheckForWin(IPlayer player)
        {
            if (!StateChecker.HasWon(GameBoard.BoardState)) return;
            Renderer.RenderWinGameScreen(player.PlayersMark);
            _isPlaying = false;
        }

        private void CheckForTie()
        {
            if (!StateChecker.HasDrawn(GameBoard.BoardState)) return;
            Renderer.RenderGameIsADrawScreen();
            _isPlaying = false;
        }

        public void RenderBoard()
        {
            Renderer.RenderBoard(GameBoard.BoardState);
        }
    }
}